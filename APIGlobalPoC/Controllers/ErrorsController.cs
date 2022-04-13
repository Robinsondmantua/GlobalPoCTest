using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Application.Common.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Presentation.Model;

namespace Presentation.Controllers
{
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("[controller]")]
    public class ErrorsController : ControllerBase
    {
        [Route("error")]
        public CustomErrorResponse Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context?.Error;
            var code = (int)HttpStatusCode.InternalServerError;

            if (exception is NotFoundException)
            {
                code = (int)HttpStatusCode.NotFound;
            }
            if (exception is ValidationException)
            {
                code = (int)HttpStatusCode.BadRequest;
            }

            Response.StatusCode = code; 

            return new CustomErrorResponse(exception.Source);
        }
    }
}
