using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.Kusto.v2022_12_29.AttachedDatabaseConfigurations;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum AttachedDatabaseTypeConstant
{
    [Description("Microsoft.Kusto/clusters/attachedDatabaseConfigurations")]
    MicrosoftPointKustoClustersAttachedDatabaseConfigurations,
}
