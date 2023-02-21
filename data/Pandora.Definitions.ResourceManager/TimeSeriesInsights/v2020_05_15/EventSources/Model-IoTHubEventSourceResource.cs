using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.TimeSeriesInsights.v2020_05_15.EventSources;

[ValueForType("Microsoft.IoTHub")]
internal class IoTHubEventSourceResourceModel : EventSourceResourceModel
{
    [JsonPropertyName("properties")]
    [Required]
    public IoTHubEventSourceCommonPropertiesModel Properties { get; set; }
}