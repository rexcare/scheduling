using Microsoft.DSX.ProjectTemplate.Command.Group;
using Microsoft.DSX.ProjectTemplate.Data.Events;
using Microsoft.DSX.ProjectTemplate.Data.Utilities;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;

namespace Microsoft.DSX.ProjectTemplate.Test.Group
{
    [TestClass]
    [TestCategory("Group")]
    public class GroupCreatedEventHandlerTests : UnitTest
    {
        [DataTestMethod]
        [DataRow("Alpha")]
        public async Task Event_Created_SendsEmail(string groupName)
        {
            await ExecuteWithDb(async (db) =>
            {
                var handler = new GroupCreatedEventHandler(MockMediator.Object, db, Mapper,
                                                           MockAuthorizationService.Object, MockEmailService.Object,
                                                           LoggerFactory.CreateLogger<GroupCreatedEventHandler>());

                var group = SeedHelper.CreateValidNewGroup(db, groupName);
                var notification = new GroupCreatedDomainEvent(group);

                await handler.Handle(notification, default);
                return Task.CompletedTask;
            }, (_, db) =>
            {
                MockEmailService.Verify(x => x.SendEmailAsync(It.IsNotNull<string>(),
                                                         It.IsNotNull<string>(),
                                                         It.Is<string>(subject => subject.Contains(groupName)),
                                                         It.IsNotNull<string>()),
                                        Times.Once);
            });
        }
    }
}
