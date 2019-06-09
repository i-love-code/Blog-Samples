using EPiServer.Shell.Security;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace CommerceSite.Web.Controllers
{
    /// <summary>
    /// This is a seed method for Episerver CMS for a SQL-based provider. In some cases, the windows/mixedmode authentication provider
    /// is not easy to get a user created, domain issues may occur. Instead, just seed a SQL user then delete this controller.
    /// 
    /// Leaving this created for the blog sample project.
    /// </summary>
    public class SeedController : Controller
    {
        private readonly UIUserProvider _userProvider;
        private readonly UIRoleProvider _roleProvider;

        private const string AdminRole = "WebAdmins";

        public SeedController(UIUserProvider userProvider, UIRoleProvider roleProvider)
        {
            _userProvider = userProvider;
            _roleProvider = roleProvider;
        }

        public ActionResult Index()
        {
            bool created = false;
            var user = _userProvider.GetUser("admin@example.com");

            if(user == null)
            {
                var userCreated = _userProvider.CreateUser("admin@example.com", "Episerver123!", "admin@example.com", "Do you like cats?", "Who doesn't like cats?", isApproved: true, out UIUserCreateStatus status , out IEnumerable<string> errors);

                if(status != UIUserCreateStatus.Success)
                    return Content($"Admin user (admin@example.com / Episerver123!) failed to create [Error: {string.Join(",", errors)}]");

                created = true;
                user = userCreated;
            }

            // Ensure Role Exists
            var adminRole = _roleProvider.GetAllRoles();

            if(!adminRole.Any(x => x.Name == AdminRole))
            {
                _roleProvider.CreateRole(AdminRole);
            }

            // Ensure seed user in admin role
            var roles = _roleProvider.GetRolesForUser(user.Username);

            if(!roles.Contains(AdminRole))
            {
                _roleProvider.AddUserToRoles(user.Username, new[] { AdminRole });
            }

            return Content($"Admin user (admin@example.com / Episerver123!) exists already and is in {AdminRole} role");
        }
    }
}