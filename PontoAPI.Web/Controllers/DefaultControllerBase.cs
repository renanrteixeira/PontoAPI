using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PontoAPI.Web.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class DefaultControllerBase : ControllerBase
    {

    }
}