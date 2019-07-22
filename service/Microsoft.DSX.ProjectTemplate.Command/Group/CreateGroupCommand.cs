using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.DES.DotNet.Data.Exceptions;
using Microsoft.DES.DotNet.Extensions;
using Microsoft.DSX.ProjectTemplate.Data;
using Microsoft.DSX.ProjectTemplate.Data.DTOs;
using Microsoft.DSX.ProjectTemplate.Data.Events;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.DSX.ProjectTemplate.Command.Group
{
    public class CreateGroupCommand : IRequest<GroupDto>
    {
        public GroupDto Group { get; set; }
    }

    public class CreateGroupCommandHandler : CommandHandlerBase,
        IRequestHandler<CreateGroupCommand, GroupDto>
    {
        public CreateGroupCommandHandler(
            IMediator mediator,
            ProjectTemplateDbContext database,
            IMapper mapper,
            IAuthorizationService authorizationService)
            : base(mediator, database, mapper, authorizationService)
        {
        }

        public async Task<GroupDto> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
        {
            if (request.Group.IsNull())
            {
                throw new BadRequestException($"A valid {nameof(Data.Models.Group)} must be provided");
            }

            if (!request.Group.IsValid())
            {
                throw new BadRequestException(request.Group.GetValidationErrors());
            }

            var dto = request.Group;

            bool nameAlreadyUsed = await Database.Groups
                .AnyAsync(e => e.Name.Trim() == dto.Name.Trim());
            if (nameAlreadyUsed)
            {
                throw new BadRequestException($"{nameof(dto.Name)} '{dto.Name}' already used");
            }

            var model = new Data.Models.Group()
            {
                Name = dto.Name,
                IsActive = dto.IsActive
            };

            Database.Groups.Add(model);

            await Database.SaveChangesAsync();

            await Mediator.Publish(new GroupCreatedDomainEvent(model));

            return Mapper.Map<GroupDto>(model);
        }
    }
}
