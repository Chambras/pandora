using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.Insights.v2018_03_01.MetricAlerts;


internal class MetricAlertPropertiesPatchModel
{
    [JsonPropertyName("actions")]
    public List<MetricAlertActionModel>? Actions { get; set; }

    [JsonPropertyName("autoMitigate")]
    public bool? AutoMitigate { get; set; }

    [JsonPropertyName("criteria")]
    public MetricAlertCriteriaModel? Criteria { get; set; }

    [JsonPropertyName("description")]
    public string? Description { get; set; }

    [JsonPropertyName("enabled")]
    public bool? Enabled { get; set; }

    [JsonPropertyName("evaluationFrequency")]
    public string? EvaluationFrequency { get; set; }

    [JsonPropertyName("isMigrated")]
    public bool? IsMigrated { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastUpdatedTime")]
    public DateTime? LastUpdatedTime { get; set; }

    [JsonPropertyName("scopes")]
    public List<string>? Scopes { get; set; }

    [JsonPropertyName("severity")]
    public int? Severity { get; set; }

    [JsonPropertyName("targetResourceRegion")]
    public string? TargetResourceRegion { get; set; }

    [JsonPropertyName("targetResourceType")]
    public string? TargetResourceType { get; set; }

    [JsonPropertyName("windowSize")]
    public string? WindowSize { get; set; }
}
