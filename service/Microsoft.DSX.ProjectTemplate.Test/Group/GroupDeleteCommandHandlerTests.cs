using Microsoft.DSX.ProjectTemplate.Command.Group;
using Microsoft.DSX.ProjectTemplate.Data.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.DSX.ProjectTemplate.Test.Group
{
    [TestClass]
    [TestCategory("Group")]
    public class GroupDeleteCommandHandlerTests : UnitTest
    {
        [DataTestMethod]
        [ExpectedException(typeof(BadRequestException))]
        [DataRow(0)]
        [DataRow(-1)]
        public async Task Delete_InvalidId_BadRequestException(int id)
        {
            await ExecuteWithDb((db) =>
            {
                var handler = new DeleteGroupCommandHandler(
                    MockMediator.Object,
                    db,
                    Mapper,
                    MockAuthorizationService.Object);

                return handler.Handle(new DeleteGroupCommand() { GroupId = id }, default(CancellationToken));
            });
        }

        [TestMethod]
        [ExpectedException(typeof(EntityNotFoundException))]
        public async Task Delete_IdNotFound_EntityNotFoundException()
        {
            await ExecuteWithDb((db) =>
            {
                var handler = new DeleteGroupCommandHandler(
                    MockMediator.Object,
                    db,
                    Mapper,
                    MockAuthorizationService.Object);

                var lastGroup = db.Groups.OrderBy(o => o.Id).Last();

                return handler.Handle(new DeleteGroupCommand() { GroupId = (lastGroup.Id + 1) }, default(CancellationToken));
            });
        }
    }
}
