using System.Collections.Generic;
using Pandora.Definitions.Interfaces;

namespace Pandora.Definitions.ResourceManager.EventHub.v2018_01_01_preview.AuthorizationRulesDisasterRecoveryConfigs
{
    internal class Definition : ApiDefinition
    {
        // Generated from Swagger revision "fd7603f9a8acb1decf94f7770a0bfe7b78df9b20" 

        public string ApiVersion => "2018-01-01-preview";
        public string Name => "AuthorizationRulesDisasterRecoveryConfigs";
        public IEnumerable<Interfaces.ApiOperation> Operations => new List<Interfaces.ApiOperation>
        {
            new DisasterRecoveryConfigsGetAuthorizationRuleOperation(),
            new DisasterRecoveryConfigsListAuthorizationRulesOperation(),
            new DisasterRecoveryConfigsListKeysOperation(),
        };
    }
}
