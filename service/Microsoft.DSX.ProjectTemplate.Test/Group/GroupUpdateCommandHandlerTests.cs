using Microsoft.DSX.ProjectTemplate.Command.Group;
using Microsoft.DSX.ProjectTemplate.Data.DTOs;
using Microsoft.DSX.ProjectTemplate.Data.Exceptions;
using Microsoft.DSX.ProjectTemplate.Data.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.DSX.ProjectTemplate.Test.Group
{
    [TestClass]
    [TestCategory("Group")]
    public class GroupUpdateCommandHandlerTests : UnitTest
    {
        [DataTestMethod]
        [ExpectedException(typeof(BadRequestException))]
        [DataRow(0)]
        [DataRow(-1)]
        public async Task Update_InvalidId_BadRequestException(int id)
        {
            await ExecuteWithDb(async (db) =>
            {
                var handler = new UpdateGroupCommandHandler(
                    MockMediator.Object,
                    db,
                    Mapper,
                    MockAuthorizationService.Object);

                var randomGroup = SeedHelper.GetRandomGroup(db);
                var dto = Mapper.Map<GroupDto>(randomGroup);
                dto.Id = id;

                return await handler.Handle(new UpdateGroupCommand() { Group = dto }, default(CancellationToken));
            });
        }

        [DataTestMethod]
        [ExpectedException(typeof(BadRequestException))]
        [DataRow(null)]
        [DataRow("")]
        public async Task Update_MissingName_BadRequestException(string name)
        {
            await ExecuteWithDb(async (db) =>
            {
                var handler = new UpdateGroupCommandHandler(
                    MockMediator.Object,
                    db,
                    Mapper,
                    MockAuthorizationService.Object);

                var randomGroup = SeedHelper.GetRandomGroup(db);
                var dto = Mapper.Map<GroupDto>(randomGroup);

                dto.Name = name;

                return await handler.Handle(new UpdateGroupCommand() { Group = dto }, default(CancellationToken));
            });
        }

        [TestMethod]
        public async Task Update_NoChanges_Success()
        {
            await ExecuteWithDb((db) =>
            {
                var handler = new UpdateGroupCommandHandler(
                    MockMediator.Object,
                    db,
                    Mapper,
                    MockAuthorizationService.Object);

                var existingGroup = SeedHelper.GetRandomGroup(db);
                var dto = Mapper.Map<GroupDto>(existingGroup);

                return handler.Handle(new UpdateGroupCommand() { Group = dto }, default(CancellationToken));
            });
        }

        [TestMethod]
        [ExpectedException(typeof(BadRequestException))]
        public async Task Update_NameAlreadyUsed_BadRequestException()
        {
            await ExecuteWithDb((db) =>
            {
                var handler = new UpdateGroupCommandHandler(
                    MockMediator.Object,
                    db,
                    Mapper,
                    MockAuthorizationService.Object);

                var existingGroup = SeedHelper.GetRandomGroup(db);
                var differentGroup = db.Groups
                    .Where(x => x.Id != existingGroup.Id)
                    .OrderBy(x => Guid.NewGuid())
                    .First();
                var dto = Mapper.Map<GroupDto>(existingGroup);
                dto.Name = differentGroup.Name;

                return handler.Handle(new UpdateGroupCommand() { Group = dto }, default(CancellationToken));
            });
        }

        [TestMethod]
        [ExpectedException(typeof(EntityNotFoundException))]
        public async Task Update_IdNotFound_EntityNotFoundException()
        {
            await ExecuteWithDb((db) =>
            {
                var handler = new UpdateGroupCommandHandler(
                    MockMediator.Object,
                    db,
                    Mapper,
                    MockAuthorizationService.Object);

                var dto = SeedHelper.CreateValidNewGroupDto(db, Mapper);
                dto.Id = int.MaxValue;

                return handler.Handle(new UpdateGroupCommand() { Group = dto }, default(CancellationToken));
            });
        }
    }
}
