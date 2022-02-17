using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Eventures.Data;
using System.Threading.Tasks;
using Eventures.Domain;

namespace Eventures.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public UserController(ApplicationDbContext context, UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.context = context;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public async Task<IActionResult> CreateRole()
        {
            var result = await roleManager.CreateAsync(new IdentityRole("User"));
            return Json(result.Succeeded);
        }
        public async Task<IActionResult> AddUserToRole()
        {
           User user = await userManager.GetUserAsync(this.User);
            var result = await userManager.AddToRoleAsync(user, "Admin");
            return Json(result.ToString());
        }
    }
}