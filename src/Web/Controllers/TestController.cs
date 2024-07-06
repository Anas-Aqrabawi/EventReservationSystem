using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleProject.Domain.Constants;

namespace SampleProject.Web.Controllers;
[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = Roles.Administrator)]
public class TestController : ApiController
{
    [HttpGet("GetNumberFromROute")]
    public ActionResult<int> GetNumberUpdated2()
    {
        return Ok(5);
    }
}
