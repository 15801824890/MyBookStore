using MyBookStore.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace MyBookStore.Permissions
{
    public class MyBookStorePermissionDefinitionProvider : PermissionDefinitionProvider
    {
        public override void Define(IPermissionDefinitionContext context)
        {
            //var myGroup = context.AddGroup(MyBookStorePermissions.GroupName);

            //Define your own permissions here. Example:
            //myGroup.AddPermission(MyBookStorePermissions.MyPermission1, L("Permission:MyPermission1"));
            var bookStoreGroup = context.AddGroup(MyBookStorePermissions.GroupName, L("Permission:BookStore"));

            var booksPermission = bookStoreGroup.AddPermission(MyBookStorePermissions.Books.Default, L("Permission:Books"));
            booksPermission.AddChild(MyBookStorePermissions.Books.Create, L("Permission:Books.Create"));
            booksPermission.AddChild(MyBookStorePermissions.Books.Edit, L("Permission:Books.Edit"));
            booksPermission.AddChild(MyBookStorePermissions.Books.Delete, L("Permission:Books.Delete"));

        }

        private static LocalizableString L(string name)
        {
            return LocalizableString.Create<MyBookStoreResource>(name);
        }
    }
}
