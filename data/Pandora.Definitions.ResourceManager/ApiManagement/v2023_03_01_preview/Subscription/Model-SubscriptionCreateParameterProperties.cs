using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2023_03_01_preview.Subscription;


internal class SubscriptionCreateParameterPropertiesModel
{
    [JsonPropertyName("allowTracing")]
    public bool? AllowTracing { get; set; }

    [JsonPropertyName("displayName")]
    [Required]
    public string DisplayName { get; set; }

    [JsonPropertyName("ownerId")]
    public string? OwnerId { get; set; }

    [JsonPropertyName("primaryKey")]
    public string? PrimaryKey { get; set; }

    [JsonPropertyName("scope")]
    [Required]
    public string Scope { get; set; }

    [JsonPropertyName("secondaryKey")]
    public string? SecondaryKey { get; set; }

    [JsonPropertyName("state")]
    public SubscriptionStateConstant? State { get; set; }
}
