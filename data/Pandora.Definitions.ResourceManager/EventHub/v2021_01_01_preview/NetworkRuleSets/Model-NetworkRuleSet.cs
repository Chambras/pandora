using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using Pandora.Definitions.Attributes;
using Pandora.Definitions.CustomTypes;

namespace Pandora.Definitions.ResourceManager.EventHub.v2021_01_01_preview.NetworkRuleSets
{

	internal class NetworkRuleSet
	{
		[JsonPropertyName("id")]
		public string? Id { get; set; }

		[JsonPropertyName("name")]
		public string? Name { get; set; }

		[JsonPropertyName("properties")]
		public NetworkRuleSetProperties? Properties { get; set; }

		[JsonPropertyName("systemData")]
		public SystemData? SystemData { get; set; }

		[JsonPropertyName("type")]
		public string? Type { get; set; }
	}
}
