using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.SecurityInsights.v2023_02_01.Metadata;


internal class MetadataCategoriesModel
{
    [JsonPropertyName("domains")]
    public List<string>? Domains { get; set; }

    [JsonPropertyName("verticals")]
    public List<string>? Verticals { get; set; }
}
