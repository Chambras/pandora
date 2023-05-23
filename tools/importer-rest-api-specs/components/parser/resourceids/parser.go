package resourceids

import (
	"fmt"
)

// Parse takes a list of Swagger Resources and returns a ParseResult, containing
// a list of ResourceIDs found within the Swagger Resources.
func (p *Parser) Parse() (*ParseResult, error) {
	// TODO: replacing static segments, detecting hidden scopes
	// TODO: tests for segments

	p.logger.Trace("Parsing Resource IDs from Operations..")
	resourceIdsToSegments, err := p.parseResourceIdsFromOperations()
	if err != nil {
		return nil, fmt.Errorf("parsing Segments from Resource IDs: %+v", err)
	}

	p.logger.Trace("Identifying Distinct Resource IDs..")
	uniqueResourceIds := p.distinctResourceIds(*resourceIdsToSegments)

	p.logger.Trace("Detecting any Common Resource Ids")
	resourceIds := switchOutCommonResourceIDsAsNeeded(uniqueResourceIds)

	p.logger.Trace("Generating Names for Resource IDs..")
	namesToResourceIds, err := p.generateNamesForResourceIds(resourceIds, nil)
	if err != nil {
		return nil, fmt.Errorf("generating Names for Resource IDs: %+v", err)
	}

	p.logger.Trace("Mapping the Parsed Resource IDs into the originally-processed URIs..")
	originalUrisToResourceIds, err := p.mapProcessedResourceIdsToInputResourceIDs(*resourceIdsToSegments, *namesToResourceIds)
	if err != nil {
		return nil, fmt.Errorf("mapping Processed Resource IDs to the Input Resource IDs: %+v", err)
	}

	p.logger.Trace("Finding Distinct Constants for Resource IDs..")
	distinctConstants, err := p.findDistinctConstants(*namesToResourceIds)
	if err != nil {
		return nil, fmt.Errorf("finding Distinct Constants for Resource IDs: %+v", err)
	}

	return &ParseResult{
		OriginalUrisToResourceIDs: *originalUrisToResourceIds,
		NamesToResourceIDs:        *namesToResourceIds,
		Constants:                 *distinctConstants,
	}, nil
}
