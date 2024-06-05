using Volo.Abp.Settings;

namespace Kampus.Settings;

public class KampusSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(KampusSettings.MySetting1));
    }
}
