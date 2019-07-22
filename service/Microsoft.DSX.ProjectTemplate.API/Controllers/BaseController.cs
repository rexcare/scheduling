namespace Microsoft.DSX.ProjectTemplate.API.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Base controller for our web API.
    /// </summary>
    public abstract class BaseController : Controller
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseController"/> class.
        /// </summary>
        /// <param name="mediator">Mediator instance from dependency injection.</param>
        protected BaseController(IMediator mediator)
            : base()
        {
            Mediator = mediator;
        }

        /// <summary>
        /// Gets injected Mediator instance.
        /// </summary>
        protected IMediator Mediator { get; }
    }
}
