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
        [HttpGet("[action]")]
        public async Task<IActionResult> Get([FromServices]ICommandMediator mediator) => Ok(await mediator.SendAsync(new CreateUser() { }));
    }
}