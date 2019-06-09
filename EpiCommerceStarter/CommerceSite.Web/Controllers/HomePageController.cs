using CommerceSite.Web.Models.Pages;
using EPiServer.Web.Mvc;
using System.Web.Mvc;

namespace CommerceSite.Web.Controllers
{
    public class HomePageController : PageController<HomePage>
    {
        public ActionResult Index(HomePage currentPage)
        {
            return View(currentPage);
        }
    }
}