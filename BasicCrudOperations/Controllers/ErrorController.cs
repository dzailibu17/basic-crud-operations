using Microsoft.AspNetCore.Mvc;

namespace BasicCrudOperations.Controllers
{
    [ApiController]
    public class ErrorController : ControllerBase
    {
        [Route("/Error")]
        public IActionResult Error() => Problem();
    }
}
