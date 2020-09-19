using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using MyBookStore.Localization;
using MyBookStore.MultiTenancy;
using MyBookStore.Permissions;
using Volo.Abp.TenantManagement.Web.Navigation;
using Volo.Abp.UI.Navigation;

namespace MyBookStore.Web.Menus
{
    public class MyBookStoreMenuContributor : IMenuContributor
    {
        public async Task ConfigureMenuAsync(MenuConfigurationContext context)
        {
            if (context.Menu.Name == StandardMenus.Main)
            {
                await ConfigureMainMenuAsync(context);
            }
        }

        private async Task ConfigureMainMenuAsync(MenuConfigurationContext context)
        {
            if (!MultiTenancyConsts.IsEnabled)
            {
                var administration = context.Menu.GetAdministration();
                administration.TryRemoveMenuItem(TenantManagementMenuNames.GroupName);
            }

            var l = context.GetLocalizer<MyBookStoreResource>();

            context.Menu.Items.Insert(0, new ApplicationMenuItem(MyBookStoreMenus.Home, l["Menu:Home"], "~/"));
            // context.Menu.AddItem(
            //     new ApplicationMenuItem(
            //         "BooksStore",
            //         l["Menu:BookStore"],
            //         icon: "fa fa-book"
            //     ).AddItem(
            //         new ApplicationMenuItem(
            //             "BooksStore.Books",
            //             l["Menu:Books"],
            //             url: "/Books"
            //         )
            //     )
            // );

            var bookStoreMenu = new ApplicationMenuItem(
                "BooksStore",
                l["Menu:BookStore"],
                icon: "fa fa-book"
            );

            context.Menu.AddItem(bookStoreMenu);

            //CHECK the PERMISSION
            if (await context.IsGrantedAsync(MyBookStorePermissions.Books.Default))
            {
                bookStoreMenu.AddItem(new ApplicationMenuItem(
                    "BooksStore.Books",
                    l["Menu:Books"],
                    url: "/Books"
                ));
            }

            context.Menu.AddItem(
                new ApplicationMenuItem(
                    "JobSchedule",
                    l["Menu:JobSchedule"]
                ).AddItem(
                    new ApplicationMenuItem(
                        "JobSchedule.JobInfo",
                        l["Menu:JobInfo"],
                        url: "/JobSchedule"
                    )
                )
            );
        }
    }
}