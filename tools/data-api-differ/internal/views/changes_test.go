package views

import (
	"testing"

	"github.com/hashicorp/pandora/tools/data-api-differ/internal/changes"
	"github.com/hashicorp/pandora/tools/sdk/testhelpers"
)

// Since we're relying on the output to be clear, it's worth sanity-checking what we're outputting here.

func TestChangesView_Markdown_NoChanges(t *testing.T) {
	actual, err := NewChangesView(make([]changes.Change, 0)).RenderMarkdown()
	if err != nil {
		t.Fatalf(err.Error())
	}
	expected := "No Breaking or Non-Breaking Changes were found 👍"
	testhelpers.AssertTemplatedCodeMatches(t, expected, *actual)
}
