using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.ContainerService.v2023_01_01.ManagedClusters;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum KeyVaultNetworkAccessTypesConstant
{
    [Description("Private")]
    Private,

    [Description("Public")]
    Public,
}