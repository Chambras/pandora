using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.StorageSync.v2022_09_01.WorkflowResource;


internal class WorkflowPropertiesModel
{
    [JsonPropertyName("commandName")]
    public string? CommandName { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("createdTimestamp")]
    public DateTime? CreatedTimestamp { get; set; }

    [JsonPropertyName("lastOperationId")]
    public string? LastOperationId { get; set; }

    [DateFormat(DateFormatAttribute.DateFormat.RFC3339)]
    [JsonPropertyName("lastStatusTimestamp")]
    public DateTime? LastStatusTimestamp { get; set; }

    [JsonPropertyName("lastStepName")]
    public string? LastStepName { get; set; }

    [JsonPropertyName("operation")]
    public OperationDirectionConstant? Operation { get; set; }

    [JsonPropertyName("status")]
    public WorkflowStatusConstant? Status { get; set; }

    [JsonPropertyName("steps")]
    public string? Steps { get; set; }
}
