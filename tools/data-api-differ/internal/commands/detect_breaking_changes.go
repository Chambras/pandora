// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package commands

import (
	"context"
	"fmt"
	v1 "github.com/hashicorp/pandora/tools/data-api-sdk/v1"
	"log"
	"os"
	"strings"

	"github.com/hashicorp/pandora/tools/data-api-sdk/v1/models"

	"github.com/hashicorp/go-hclog"
	"github.com/hashicorp/pandora/tools/data-api-differ/internal/differ"
	internalLog "github.com/hashicorp/pandora/tools/data-api-differ/internal/log"
	"github.com/hashicorp/pandora/tools/data-api-differ/internal/views"
	"github.com/mitchellh/cli"
)

var _ cli.Command = &DetectBreakingChangesCommand{}

type DetectBreakingChangesCommand struct {
	logger         hclog.Logger
	sourceDataType models.SourceDataType
}

func NewDetectBreakingChangesCommand(sourceDataType models.SourceDataType) func() (cli.Command, error) {
	return func() (cli.Command, error) {
		return &DetectBreakingChangesCommand{
			logger:         internalLog.Logger,
			sourceDataType: sourceDataType,
		}, nil
	}
}

func (DetectBreakingChangesCommand) Help() string {
	sourceDataTypes := make([]string, 0)
	for _, item := range v1.AvailableSourceDataTypes() {
		sourceDataTypes = append(sourceDataTypes, fmt.Sprintf("* %s", string(item)))
	}
	return fmt.Sprintf(`data-api-differ {source-data-type} detect-breaking-changes

Where '{source-data-type}' is one of:

%s

This command detects any breaking changes that exist between the existing and an updated set of API Definitions - output as a report.
`, strings.Join(sourceDataTypes, "\n"))
}

func (c DetectBreakingChangesCommand) Run(args []string) int {
	c.logger.Info("Running `detect-breaking-changes` command..")
	ctx := context.Background()

	a := arguments{}
	c.logger.Debug("Parsing arguments..")
	if err := a.parse(args); err != nil {
		c.logger.Error(fmt.Sprintf("parsing arguments: %+v", err))
		return 1
	}

	if err := a.validate(); err != nil {
		c.logger.Error(fmt.Sprintf("validating arguments: %+v", err))
		return 1
	}

	c.logger.Info(fmt.Sprintf("Data API Binary located at %q", a.dataApiBinaryPath))
	c.logger.Info(fmt.Sprintf("Initial API Definitions located at: %q", a.initialApiDefinitionsPath))
	c.logger.Info(fmt.Sprintf("Updated API Definitions located at: %q", a.updatedApiDefinitionsPath))

	if a.outputFilePath != nil {
		c.logger.Info(fmt.Sprintf("Output will be rendered to the file located at: %q", *a.outputFilePath))
	} else {
		c.logger.Info("Output will be rendered to the console since no output file was specified")
	}

	c.logger.Debug("Performing diff of the two data sources..")
	includeNestedChangesWhenNew := false // not necessary since this is only tracking breaking changes
	result, err := differ.Diff(ctx, a.dataApiBinaryPath, a.initialApiDefinitionsPath, a.updatedApiDefinitionsPath, c.sourceDataType, includeNestedChangesWhenNew)
	if err != nil {
		c.logger.Error(fmt.Sprintf("performing diff: %+v", err))
		return 1
	}

	// then render the output
	c.logger.Debug("Rendering the Breaking Changes..")
	view := views.NewBreakingChangesView(result.Changes)
	rendered, err := view.RenderMarkdown()
	if err != nil {
		c.logger.Error(fmt.Sprintf("rendering markdown: %+v", err))
		return 1
	}

	// Finally determine how to output that
	if a.outputFilePath != nil {
		c.logger.Trace(fmt.Sprintf("Writing output to %q..", *a.outputFilePath))
		if err := os.WriteFile(*a.outputFilePath, []byte(*rendered), 0644); err != nil {
			c.logger.Error(fmt.Sprintf("writing output to %q: %+v", *a.outputFilePath, err))
		}
	} else {
		c.logger.Trace("Rendering output to Terminal since no output file was specified..")
		log.Print(*rendered)
	}

	return 0
}

func (DetectBreakingChangesCommand) Synopsis() string {
	return "Retrieves two sets of API Definitions from the Data API and determines if there are any breaking changes"
}
