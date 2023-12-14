using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.Attributes.Validation;
using Pandora.Definitions.CustomTypes;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2023_03_01_preview.PortalConfig;


internal class PortalConfigPropertiesModel
{
    [JsonPropertyName("cors")]
    public PortalConfigCorsPropertiesModel? Cors { get; set; }

    [JsonPropertyName("csp")]
    public PortalConfigCspPropertiesModel? Csp { get; set; }

    [JsonPropertyName("delegation")]
    public PortalConfigDelegationPropertiesModel? Delegation { get; set; }

    [JsonPropertyName("enableBasicAuth")]
    public bool? EnableBasicAuth { get; set; }

    [JsonPropertyName("signin")]
    public PortalConfigPropertiesSigninModel? Signin { get; set; }

    [JsonPropertyName("signup")]
    public PortalConfigPropertiesSignupModel? Signup { get; set; }
}
