using Pandora.Definitions.Attributes;
using Pandora.Definitions.Interfaces;
using Pandora.Definitions.Operations;
using System.Collections.Generic;
using System.Net;

namespace Pandora.Definitions.ResourceManager.EventHub.v2021_01_01_preview.NamespacesPrivateEndpointConnections
{
	internal class PrivateEndpointConnectionsCreateOrUpdate : PutOperation
	{
		public override object? RequestObject()
		{
			return new PrivateEndpointConnection();
		}

		public override ResourceID? ResourceId()
		{
			return new PrivateEndpointConnectionId();
		}

		public override object? ResponseObject()
		{
			return new PrivateEndpointConnection();
		}
	}
}
