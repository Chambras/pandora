using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.AlertsManagement.v2023_03_01.PrometheusRuleGroups;


internal class PrometheusRuleResolveConfigurationModel
{
    [JsonPropertyName("autoResolved")]
    public bool? AutoResolved { get; set; }

    [JsonPropertyName("timeToResolve")]
    public string? TimeToResolve { get; set; }
}