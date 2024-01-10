using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StorageSync.v2022_09_01.CloudEndpointResource;


internal class CloudEndpointCreateParametersPropertiesModel
{
    [JsonPropertyName("azureFileShareName")]
    public string? AzureFileShareName { get; set; }

    [JsonPropertyName("friendlyName")]
    public string? FriendlyName { get; set; }

    [JsonPropertyName("storageAccountResourceId")]
    public string? StorageAccountResourceId { get; set; }

    [JsonPropertyName("storageAccountTenantId")]
    public string? StorageAccountTenantId { get; set; }
}
