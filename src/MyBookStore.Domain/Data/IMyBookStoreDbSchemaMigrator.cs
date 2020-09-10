using System.Threading.Tasks;

namespace MyBookStore.Data
{
    public interface IMyBookStoreDbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
