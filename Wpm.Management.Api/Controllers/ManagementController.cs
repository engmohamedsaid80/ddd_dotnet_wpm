using Microsoft.AspNetCore.Mvc;
using Wpm.Management.Api.Application;

namespace Wpm.Management.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ManagementController(ManagemantApplicationService applicationService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] CreatePetCommand command)
    {
        await applicationService.Handle(command);

        return Ok();
    }
}
