using Microsoft.EntityFrameworkCore;
using MyBookStore.Books;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore.Modeling;

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

            //ConfigureByConvention() 方法优雅的配置/映射继承的属性,应始终对你所有的实体使用它.
            builder.Entity<Book>(b =>
            {
                b.ToTable(MyBookStoreConsts.DbTablePrefix + "Books",
                    MyBookStoreConsts.DbSchema);
                b.ConfigureByConvention(); //auto configure for the base class props
                b.Property(x => x.Name).IsRequired().HasMaxLength(128);
            });
        }
    }
}