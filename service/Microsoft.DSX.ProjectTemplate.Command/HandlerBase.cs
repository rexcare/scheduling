using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.DSX.ProjectTemplate.Data;

namespace Microsoft.DSX.ProjectTemplate.Command
{
    /// <summary>
    /// Base class that all handlers inherit from
    /// </summary>
    public abstract class HandlerBase
    {
        protected IMediator Mediator { get; }

        protected ProjectTemplateDbContext Database { get; }

        protected IMapper Mapper { get; }

        protected IAuthorizationService AuthorizationService { get; }

        protected HandlerBase(
            IMediator mediator,
            ProjectTemplateDbContext database,
            IMapper mapper,
            IAuthorizationService authorizationService)
        {
            Mediator = mediator;
            Database = database;
            Mapper = mapper;
            AuthorizationService = authorizationService;
        }
    }
}
