// Copyright (c) HashiCorp, Inc.
// SPDX-License-Identifier: MPL-2.0

package changes

var _ Change = CommonTypesApiVersionRemoved{}

// CommonTypesApiVersionRemoved defines information about a new API Version for CommonTypes.
type CommonTypesApiVersionRemoved struct {
	// ApiVersion specifies the API Version (e.g. `2023-01-01-preview`) for which CommonTypes have been removed.
	ApiVersion string
}

// IsBreaking returns whether this Change is considered a Breaking Change.
func (CommonTypesApiVersionRemoved) IsBreaking() bool {
	return true
}
