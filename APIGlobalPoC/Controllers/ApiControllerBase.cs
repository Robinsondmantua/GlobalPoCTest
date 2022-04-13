using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Presentation.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public abstract class ApiControllerBase : ControllerBase
	{
		private ISender _mediator;

		protected ApiControllerBase()
		{

		}

		protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetService<ISender>();
	}
}
