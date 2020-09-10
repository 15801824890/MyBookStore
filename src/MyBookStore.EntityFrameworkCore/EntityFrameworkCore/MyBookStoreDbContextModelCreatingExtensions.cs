using Microsoft.EntityFrameworkCore;
using Volo.Abp;

namespace MyBookStore.EntityFrameworkCore
{
    public static class MyBookStoreDbContextModelCreatingExtensions
    {
        public static void ConfigureMyBookStore(this ModelBuilder builder)
        {
            Check.NotNull(builder, nameof(builder));

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(MyBookStoreConsts.DbTablePrefix + "YourEntities", MyBookStoreConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});
        }
    }
}