using Pandora.Definitions.Attributes;
using System.ComponentModel;

namespace Pandora.Definitions.ResourceManager.AppPlatform.v2023_05_01_preview.AppPlatform;

[ConstantType(ConstantTypeAttribute.ConstantType.String)]
internal enum MonitoringSettingStateConstant
{
    [Description("Failed")]
    Failed,

    [Description("NotAvailable")]
    NotAvailable,

    [Description("Succeeded")]
    Succeeded,

    [Description("Updating")]
    Updating,
}
