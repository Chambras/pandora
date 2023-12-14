using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2023_03_01_preview.OpenidConnectProvider;


internal class OpenidConnectProviderUpdateContractPropertiesModel
{
    [JsonPropertyName("clientId")]
    public string? ClientId { get; set; }

    [JsonPropertyName("clientSecret")]
    public string? ClientSecret { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }

    [JsonPropertyName("metadataEndpoint")]
    public string? MetadataEndpoint { get; set; }

    [JsonPropertyName("useInApiDocumentation")]
    public bool? UseInApiDocumentation { get; set; }

    [JsonPropertyName("useInTestConsole")]
    public bool? UseInTestConsole { get; set; }
}
