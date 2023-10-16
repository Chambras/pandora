using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StorageSync.v2022_09_01.SyncGroupResource;


internal class SyncGroupPropertiesModel
{
    [JsonPropertyName("syncGroupStatus")]
    public string? SyncGroupStatus { get; set; }

    [JsonPropertyName("uniqueId")]
    public string? UniqueId { get; set; }
}
