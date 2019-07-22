using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.DSX.ProjectTemplate.Data;

namespace Microsoft.DSX.ProjectTemplate.Command
{
    /// <summary>
	/// Base class that all query handlers inherit from
	/// </summary>
    public abstract class QueryHandlerBase : HandlerBase
    {
        protected QueryHandlerBase(
            IMediator mediator,
            ProjectTemplateDbContext database,
            IMapper mapper,
            IAuthorizationService authorizationService)
            : base(mediator, database, mapper, authorizationService)
        {
            // queries do not make changes to the database so we do not need ChangeTracker
            database.ChangeTracker.QueryTrackingBehavior = EntityFrameworkCore.QueryTrackingBehavior.NoTracking;
        }
    }
}
