using FluentAssertions;
using Microsoft.DES.DotNet.Utilities;
using Microsoft.DSX.ProjectTemplate.Data.DTOs;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Microsoft.DSX.ProjectTemplate.Test.Group
{
    [TestClass]
    [TestCategory("Group")]
    public class GroupControllerTests : IntegrationTest
    {
        [TestMethod]
        public async Task GetAll_Valid_Success()
        {
            // Arrange
            var client = Factory.CreateClient();

            // Act
            var response = await client.GetAsync("/api/groups");

            // Assert
            var result = await EnsureObject<IEnumerable<GroupDto>>(response);
            result.Should().HaveCountGreaterThan(0);
        }

        [DataTestMethod]
        [DataRow(1)]
        public async Task GetById_Valid_Success(int groupId)
        {
            // Arrange
            var client = Factory.CreateClient();

            // Act
            var response = await client.GetAsync($"/api/groups/{groupId}");

            // Assert
            var result = await EnsureObject<GroupDto>(response);
            result.Should().NotBeNull();
            result.Id.Should().Be(groupId);
            result.IsValid().Should().BeTrue();
        }

        [TestMethod]
        public async Task Create_Valid_Success()
        {
            // Arrange
            var client = Factory.CreateClient();
            var dto = SetupGroupDto();

            // Act
            var response = await client.PostAsJsonAsync("/api/groups", dto);

            // Assert
            var result = await EnsureObject<GroupDto>(response);
            result.Id.Should().BeGreaterThan(0);
            result.Name.Should().Be(dto.Name);
            result.IsActive.Should().Be(dto.IsActive);
        }

        [TestMethod]
        public async Task Update_Valid_Success()
        {
            // Arrange
            var client = Factory.CreateClient();
            var dto = SetupGroupDto();
            dto.Id = 4;

            // Act
            var response = await client.PutAsJsonAsync("/api/groups", dto);

            // Assert
            var result = await EnsureObject<GroupDto>(response);
            result.Id.Should().Be(dto.Id);
            result.Name.Should().Be(dto.Name);
            result.IsActive.Should().Be(dto.IsActive);
        }

        [DataTestMethod]
        [DataRow(4)]
        public async Task Delete_Valid_Success(int groupId)
        {
            // Arrange
            var client = Factory.CreateClient();

            // Act
            var response = await client.DeleteAsync($"/api/groups/{groupId}");

            // Assert
            var result = await EnsureObject<bool>(response);
            result.Should().BeTrue();
        }

        private GroupDto SetupGroupDto()
        {
            return new GroupDto()
            {
                Name = RandomFactory.GetCompanyName(),
                IsActive = RandomFactory.GetBoolean()
            };
        }
    }
}
