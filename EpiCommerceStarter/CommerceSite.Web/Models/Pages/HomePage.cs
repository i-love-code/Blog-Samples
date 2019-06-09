using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace CommerceSite.Web.Models.Pages
{
    [ContentType(DisplayName = "Homepage", GUID = "19adbcb8-f521-4c5a-b605-0036361e0113", Description = "")]
    public class HomePage : PageData
    {
        public virtual XhtmlString Ingress { get; set; }
    }
}