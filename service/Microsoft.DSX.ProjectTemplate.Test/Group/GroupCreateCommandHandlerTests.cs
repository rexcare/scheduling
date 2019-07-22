using Microsoft.DSX.ProjectTemplate.Command.Group;
using Microsoft.DSX.ProjectTemplate.Data.Events;
using Microsoft.DSX.ProjectTemplate.Data.Exceptions;
using Microsoft.DSX.ProjectTemplate.Data.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.DSX.ProjectTemplate.Test.Group
{
    [TestClass]
    [TestCategory("Group")]
    public class GroupCreateCommandHandlerTests : UnitTest
    {
        [DataTestMethod]
        [ExpectedException(typeof(BadRequestException))]
        [DataRow(null)]
        [DataRow("")]
        public async Task Create_MissingName_BadRequestException(string name)
        {
            await ExecuteWithDb((db) =>
            {
                var handler = new CreateGroupCommandHandler(
                    MockMediator.Object,
                    db,
                    Mapper,
                    MockAuthorizationService.Object);

                var dto = SeedHelper.CreateValidNewGroupDto(db, Mapper);
                dto.Name = name;

                return handler.Handle(new CreateGroupCommand() { Group = dto }, default);
            });
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public async Task Create_NameAlreadyUsed_BadRequestException()
        {
            await ExecuteWithDb((db) =>
            {
                var handler = new CreateGroupCommandHandler(
                    MockMediator.Object,
                    db,
                    Mapper,
                    MockAuthorizationService.Object);

                var existingGroup = SeedHelper.GetRandomGroup(db);
                var dto = SeedHelper.CreateValidNewGroupDto(db, Mapper, existingGroup.Name);

                return handler.Handle(new CreateGroupCommand() { Group = dto }, default);
            });
        }

        [TestMethod]
        public async Task Create_Valid_PublishesGroupCreatedDomainEvent()
        {
            await ExecuteWithDb((db) =>
            {
                var handler = new CreateGroupCommandHandler(
                    MockMediator.Object,
                    db,
                    Mapper,
                    MockAuthorizationService.Object);

                var dto = SeedHelper.CreateValidNewGroupDto(db, Mapper);

                return handler.Handle(new CreateGroupCommand() { Group = dto }, default);
            }, (result, db) =>
            {
                MockMediator.Verify(x => x.Publish(It.IsAny<GroupCreatedDomainEvent>(), It.IsAny<CancellationToken>()), Times.Once);
            });
        }
    }
}
