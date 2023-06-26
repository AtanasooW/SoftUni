using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Homies.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        public string GetUserID()
        {
            string id = string.Empty;
            if (User != null)
            {
                id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
            return id;
        }
    }
}
