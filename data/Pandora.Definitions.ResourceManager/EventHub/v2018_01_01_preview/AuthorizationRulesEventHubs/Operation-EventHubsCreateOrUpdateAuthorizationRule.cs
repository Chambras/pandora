using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.AuthorizationRulesEventHubs
{
    internal class EventHubsCreateOrUpdateAuthorizationRuleOperation : Operations.PutOperation
    {
        public override IEnumerable<HttpStatusCode> ExpectedStatusCodes()
        {
            return new List<HttpStatusCode>
            {
                HttpStatusCode.OK,
            };
        }

        public override Type? RequestObject()
        {
            return typeof(AuthorizationRuleModel);
        }

        public override ResourceID? ResourceId()
        {
            return new AuthorizationRuleId();
        }

        public override Type? ResponseObject()
        {
            return typeof(AuthorizationRuleModel);
        }


    }
}
