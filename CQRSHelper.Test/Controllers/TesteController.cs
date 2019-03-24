using CQRSHelper.Mediator.Interfaces;
using CQRSHelper.Test.Commands;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CQRSHelper.Test.Controllers
{
    [Route("api/v1/teste")]
    [ApiController]
    public class TesteController : ControllerBase
    {
        [HttpPost("[action]")]
        public async Task<IActionResult> CreateUser([FromServices]ICommandMediator mediator, [FromBody]CreateUser command) => Ok(await mediator.SendAsync(command));
    }
}