using Microsoft.AspNetCore.Mvc;
using TBlFantasy.Entity;

namespace TBlFantasy.Web
{
    public class DbController : Controller
    {
        private TBLDContext _db;
        public TBLDContext Db => _db ?? (TBLDContext)HttpContext?.RequestServices.GetService(typeof(TBLDContext));
    }
}
