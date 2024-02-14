package v1

import (
	"context"
	"fmt"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"
)

type LoadAllDataResult struct {
	// CommonTypes specifies the Common Types which exist across the entire API, rather than being scoped to an
	// APIResource (within an APIVersion within a Service).
	// This allows for Common Types which are defined in _every_ package to be sourced from a single location,
	// reducing the size of each APIResource - particularly where circular references exist in the Types.
	CommonTypes models.CommonTypes

	// Services specifies a map of Service Name (key) to Service (value) representing the available Services for
	// this SourceDataType.
	// The Service Name is a valid Identifier.
	Services map[string]models.Service
}

// LoadAllData is a helper function which returns all information for a given SourceDataType from the Data API.
// This allows implementations to rely on the entire set of source data being available, and means they don't
// need to reimplement this logic.
// This function assumes that the Data API is online and available, which can be checked via the Health function.
//
// serviceNamesToLimitTo is an optional value allowing limiting the returned result to a subset of the available
// services, primarily intended for debugging purposes.
func (c *Client) LoadAllData(ctx context.Context, serviceNamesToLimitTo []string) (*LoadAllDataResult, error) {
	allServices, err := c.GetAvailableServices(ctx)
	if err != nil {
		return nil, fmt.Errorf("loading available services: %+v", err)
	}

	result := LoadAllDataResult{
		CommonTypes: models.CommonTypes{
			Constants: make(map[string]models.SDKConstant),
			Models:    make(map[string]models.SDKModel),
		},
		Services: make(map[string]models.Service),
	}

	c.logger.Debug("Retrieving any Common Types..")
	commonTypes, err := c.GetCommonTypes(ctx)
	if err != nil {
		return nil, fmt.Errorf("retrieving Common Types: %+v", err)
	}
	result.CommonTypes.Constants = commonTypes.Model.Constants
	result.CommonTypes.Models = commonTypes.Model.Models

	c.logger.Debug("Retrieving All Services..")
	for serviceName, serviceSummary := range *allServices.Model {
		if len(serviceNamesToLimitTo) > 0 && !filteredServiceListContains(serviceNamesToLimitTo, serviceName) {
			c.logger.Trace(fmt.Sprintf("Skipping Service %q since it's not in the list of services to retrieve data from", serviceName))
			continue
		}

		c.logger.Trace(fmt.Sprintf("Retrieving details for Service %q..", serviceName))
		serviceDetails, err := c.loadAllDetailsForService(ctx, serviceSummary)
		if err != nil {
			return nil, fmt.Errorf("retrieving details for Service %q: %+v", serviceName, err)
		}

		result.Services[serviceName] = *serviceDetails
	}

	return &result, nil
}

func (c *Client) loadAllDetailsForService(ctx context.Context, summary AvailableServiceSummary) (*models.Service, error) {
	serviceDetails, err := c.GetDetailsForServiceResponse(ctx, summary)
	if err != nil {
		return nil, fmt.Errorf("retrieving details : %+v", err)
	}

	apiVersions := make(map[string]models.APIVersion)
	for version, versionSummary := range serviceDetails.Model.Versions {
		c.logger.Trace(fmt.Sprintf("Retrieving details for API Version %q..", version))
		versionDetails, err := c.loadAllDetailsForAPIVersion(ctx, versionSummary)
		if err != nil {
			return nil, fmt.Errorf("retrieving details for API Version: %+v", err)
		}

		apiVersions[version] = *versionDetails
	}

	c.logger.Trace("Retrieving Terraform Details for this Service..")
	terraformDetails, err := c.GetTerraformDetailsForService(ctx, *serviceDetails.Model)
	if err != nil {
		return nil, fmt.Errorf("retrieving the Terraform Details: %+v", err)
	}

	return &models.Service{
		APIVersions:         apiVersions,
		Generate:            summary.Generate,
		ResourceProvider:    serviceDetails.Model.ResourceProvider,
		TerraformDefinition: terraformDetails.Model,
	}, nil
}

func (c *Client) loadAllDetailsForAPIVersion(ctx context.Context, summary ServiceAPIVersionSummary) (*models.APIVersion, error) {
	versionDetails, err := c.DetailsForAPIVersion(ctx, summary)
	if err != nil {
		return nil, fmt.Errorf("retrieving details: %+v", err)
	}

	apiResources := make(map[string]models.APIResource)
	for resourceName, resourceSummary := range versionDetails.Model.Resources {
		c.logger.Trace(fmt.Sprintf("Retrieving the SDK Operations for API Resource %q..", resourceName))
		sdkOperations, err := c.GetSDKOperationsForAPIResource(ctx, resourceSummary)
		if err != nil {
			return nil, fmt.Errorf("retrieving the SDK Operations for API Resource %q: %+v", resourceName, err)
		}

		c.logger.Trace(fmt.Sprintf("Retrieving the SDK Schema for API Resource %q..", resourceName))
		sdkSchema, err := c.GetSDKSchemaForAPIResource(ctx, resourceSummary)
		if err != nil {
			return nil, fmt.Errorf("retrieving the SDK Schema for API Resource %q: %+v", resourceName, err)
		}

		apiResources[resourceName] = models.APIResource{
			Constants:   sdkSchema.Model.Constants,
			Models:      sdkSchema.Model.Models,
			Operations:  sdkOperations.Model.Operations,
			ResourceIDs: sdkSchema.Model.ResourceIDs,
		}
	}

	return &models.APIVersion{
		Generate:  summary.Generate,
		Preview:   summary.Preview,
		Resources: apiResources,
		Source:    versionDetails.Model.Source,
	}, nil
}

func filteredServiceListContains(serviceNamesToLimitTo []string, serviceName string) bool {
	for _, item := range serviceNamesToLimitTo {
		if item == serviceName {
			return true
		}
	}

	return false
}
