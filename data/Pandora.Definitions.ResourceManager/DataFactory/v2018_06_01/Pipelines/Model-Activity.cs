using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.DataFactory.v2018_06_01.Pipelines;


internal class ActivityModel
{
    [JsonPropertyName("dependsOn")]
    public List<ActivityDependencyModel>? DependsOn { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("name")]
    [Required]
    public string Name { get; set; }

    [JsonPropertyName("onInactiveMarkAs")]
    public ActivityOnInactiveMarkAsConstant? OnInactiveMarkAs { get; set; }

    [JsonPropertyName("state")]
    public ActivityStateConstant? State { get; set; }

    [JsonPropertyName("type")]
    [Required]
    public string Type { get; set; }

    [JsonPropertyName("userProperties")]
    public List<UserPropertyModel>? UserProperties { get; set; }
}
