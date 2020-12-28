using Microsoft.AspNetCore.Mvc;

namespace VisitCard.API.Controllers
{
    [Route("api/[controller]")]
    public class BaseController : Controller
    {
        protected string CurrentUserId => HttpContext.User.Identity?.Name;
    }
}