using Kampus.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Kampus.Permissions;

public class KampusPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(KampusPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(KampusPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<KampusResource>(name);
    }
}
