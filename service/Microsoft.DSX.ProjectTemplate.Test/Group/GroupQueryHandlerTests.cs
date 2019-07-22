using FluentAssertions;
using Microsoft.DSX.ProjectTemplate.Command.Group;
using Microsoft.DSX.ProjectTemplate.Data.DTOs;
using Microsoft.DSX.ProjectTemplate.Data.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.DSX.ProjectTemplate.Test.Group
{
    [TestClass]
    [TestCategory("Group")]
    public class GroupQueryHandlerTests : UnitTest
    {
        [TestMethod]
        public async Task GetAll_Valid_Success()
        {
            DateTime dtStart = DateTime.Now;

            await ExecuteWithDb((db) =>
            {
                var handler = new GroupQueryHandler(
                    MockMediator.Object,
                    db,
                    Mapper,
                    MockAuthorizationService.Object);
                return handler.Handle(new GetAllGroupsQuery(), default(CancellationToken));
            }, (result, db) =>
            {
                result.Should().NotBeNull();
                result.Should().BeAssignableTo<IEnumerable<GroupDto>>();
                result.Should().HaveCountGreaterThan(0);
                foreach (var group in result)
                {
                    group.Id.Should().BeGreaterThan(0);
                    group.Name.Should().NotBeNullOrWhiteSpace();
                    group.CreatedDate.Should().BeOnOrAfter(dtStart);
                    group.UpdatedDate.Should().BeOnOrAfter(dtStart);
                }
            });
        }

        [DataTestMethod]
        [ExpectedException(typeof(BadRequestException))]
        [DataRow(0)]
        [DataRow(-1)]
        public async Task GetById_InvalidId_BadRequestException(int id)
        {
            await ExecuteWithDb((db) =>
            {
                var handler = new GroupQueryHandler(
                    MockMediator.Object,
                    db,
                    Mapper,
                    MockAuthorizationService.Object);
                return handler.Handle(new GetGroupByIdQuery() { GroupId = id }, default(CancellationToken));
            });
        }

        [DataTestMethod]
        [ExpectedException(typeof(EntityNotFoundException))]
        [DataRow(int.MaxValue)]
        public async Task GetById_IdNotFound_EntityNotFoundException(int id)
        {
            await ExecuteWithDb((db) =>
            {
                var handler = new GroupQueryHandler(
                    MockMediator.Object,
                    db,
                    Mapper,
                    MockAuthorizationService.Object);
                return handler.Handle(new GetGroupByIdQuery() { GroupId = id }, default(CancellationToken));
            });
        }
    }
}
