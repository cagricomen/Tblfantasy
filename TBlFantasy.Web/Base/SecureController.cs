using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TBlFantasy.Web
{
    [Authorize]
    public class SecureController : Controller
    {

    }
}
