using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AppPlatform.v2023_05_01_preview.AppPlatform;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum KPackBuildStageProvisioningStateConstant
{
    [Description("Failed")]
    Failed,

    [Description("NotStarted")]
    NotStarted,

    [Description("Running")]
    Running,

    [Description("Succeeded")]
    Succeeded,
}
