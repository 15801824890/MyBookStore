using Volo.Abp.Settings;

namespace MyBookStore.Settings
{
    public class MyBookStoreSettingDefinitionProvider : SettingDefinitionProvider
    {
        public override void Define(ISettingDefinitionContext context)
        {
            //Define your own settings here. Example:
            //context.Add(new SettingDefinition(MyBookStoreSettings.MySetting1));
        }
    }
}
