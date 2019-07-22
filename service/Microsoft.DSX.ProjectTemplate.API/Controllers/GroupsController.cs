using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DSX.ProjectTemplate.Command.Group;
using Microsoft.DSX.ProjectTemplate.Data.DTOs;

namespace Microsoft.DSX.ProjectTemplate.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class GroupsController : BaseController
    {
        public GroupsController(IMediator mediator) : base(mediator) { }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GroupDto>>> GetAllGroups()
        {
            return Ok(await Mediator.Send(new GetAllGroupsQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GroupDto>> GetGroup(int id)
        {
            return Ok(await Mediator.Send(new GetGroupByIdQuery() { GroupId = id }));
        }

        [HttpPost]
        public async Task<ActionResult<GroupDto>> CreateGroup([FromBody] GroupDto dto)
        {
            return Ok(await Mediator.Send(new CreateGroupCommand() { Group = dto }));
        }

        [HttpPut]
        public async Task<ActionResult<GroupDto>> UpdateGroup([FromBody] GroupDto dto)
        {
            return Ok(await Mediator.Send(new UpdateGroupCommand() { Group = dto }));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<GroupDto>> DeleteGroup([FromRoute] int id)
        {
            return Ok(await Mediator.Send(new DeleteGroupCommand() { GroupId = id }));
        }
    }
}
