using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;


// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See NOTICE.txt in the project root for license information.


namespace Pandora.Definitions.ResourceManager.ApiManagement.v2022_08_01.NamedValue;

internal class CreateOrUpdateOperation : Operations.PutOperation
{
    public override IEnumerable<HttpStatusCode> ExpectedStatusCodes() => new List<HttpStatusCode>
        {
                HttpStatusCode.Accepted,
                HttpStatusCode.Created,
                HttpStatusCode.OK,
        };

    public override bool LongRunning() => true;

    public override Type? RequestObject() => typeof(NamedValueCreateContractModel);

    public override ResourceID? ResourceId() => new NamedValueId();

    public override Type? ResponseObject() => typeof(NamedValueContractModel);

    public override Type? OptionsObject() => typeof(CreateOrUpdateOperation.CreateOrUpdateOptions);

    internal class CreateOrUpdateOptions
    {
        [HeaderName("If-Match")]
        [Optional]
        public string IfMatch { get; set; }
    }
}
