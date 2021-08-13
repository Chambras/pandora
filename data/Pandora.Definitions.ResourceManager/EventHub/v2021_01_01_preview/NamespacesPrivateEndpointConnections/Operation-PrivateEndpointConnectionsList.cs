using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventHub.v2021_01_01_preview.NamespacesPrivateEndpointConnections
{
    internal class PrivateEndpointConnectionsListOperation : Operations.ListOperation
    {
        public override string? FieldContainingPaginationDetails()
        {
            return "nextLink";
        }

        public override ResourceID? ResourceId()
        {
            return new NamespaceId();
        }

        public override Type NestedItemType()
        {
            return typeof(PrivateEndpointConnectionModel);
        }

        public override string? UriSuffix()
        {
            return "/privateEndpointConnections";
        }


    }
}
