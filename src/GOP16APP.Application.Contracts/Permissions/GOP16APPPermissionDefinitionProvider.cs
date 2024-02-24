using GOP16APP.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace GOP16APP.Permissions;

public class GOP16APPPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(GOP16APPPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(GOP16APPPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<GOP16APPResource>(name);
    }
}
