using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.DSX.ProjectTemplate.API;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Microsoft.DSX.ProjectTemplate.Test
{
    /// <summary>
    /// Each integration test is truly isolated because the test has private instances of:
    /// - <see cref="Microsoft.AspNetCore.Mvc.Testing.WebApplicationFactory{TEntryPoint}"/>
    /// - <see cref="Microsoft.AspNetCore.TestHost.TestServer"/>
    /// - <see cref="Microsoft.EntityFrameworkCore.InMemory"/> database
    /// </summary>
    [TestCategory("Integration")]
    [TestClass]
    public abstract class IntegrationTest : BaseTest
    {
        /// <summary>
        /// Gets factory that creates <see cref="System.Net.Http.HttpClient"/> instances for sending HTTP requests to.
        /// </summary>
        protected WebApplicationFactory<TestStartup> Factory { get; }

        protected IntegrationTest()
        {
            Factory = new CustomWebApplicationFactory<TestStartup>();
        }
    }
}
