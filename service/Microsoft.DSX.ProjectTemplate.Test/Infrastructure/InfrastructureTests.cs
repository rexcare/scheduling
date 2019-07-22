using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.DSX.ProjectTemplate.Test.Infrastructure
{
    [TestClass]
    public class InfrastructureTests : UnitTest
    {
        [TestMethod]
        public async Task Infrastructure_AutoMapper_ConfigurationIsValid()
        {
            Mapper.ConfigurationProvider.AssertConfigurationIsValid();

            await Task.CompletedTask;
        }
    }
}
