using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Skinet.API.Errors;

namespace Skinet.API.Controllers
{
    // Used to return consistent response not handled by our controller 

    [Route("errors/{code}")]
    [ApiExplorerSettings(IgnoreApi = true)] // ignores controller and not consumable by client
    public class ErrorController : BaseApiController
    {
        public IActionResult Error(int code)
        {
            return new ObjectResult(new ApiResponse(code));
        }
    }
}
