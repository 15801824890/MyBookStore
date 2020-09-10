using System.Threading.Tasks;
using Shouldly;
using Xunit;

namespace MyBookStore.Pages
{
    public class Index_Tests : MyBookStoreWebTestBase
    {
        [Fact]
        public async Task Welcome_Page()
        {
            var response = await GetResponseAsStringAsync("/");
            response.ShouldNotBeNull();
        }
    }
}
