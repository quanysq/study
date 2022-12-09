using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace 标识框架1.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Test1Controller : ControllerBase
    {
        private readonly ILogger<Test1Controller> logger;
        private readonly RoleManager<Role> roleManager;
        private readonly UserManager<User> userManager;

        public Test1Controller(
            ILogger<Test1Controller> logger,
            RoleManager<Role> roleManager,
            UserManager<User> userManager)
        {
            this.logger = logger;
            this.roleManager = roleManager;
            this.userManager = userManager;
        }

        [HttpPost]
        public async Task<ActionResult> CreateUserRole()
        {
            // 1. 判断管理员角色是否存在，不存在则创建
            bool roleExists = await roleManager.RoleExistsAsync("admin");
            if (!roleExists)
            {
                Role role = new Role() { Name = "Admin" };
                var r = await roleManager.CreateAsync(role);
                if (!r.Succeeded)
                {
                    return BadRequest(r.Errors);
                }
            }

            // 2. 创建账户
            User user = await userManager.FindByNameAsync("yzk");
            if (user == null)
            {
                user = new User
                {
                    UserName = "yzk",
                    Email = "51398898@qq.com",
                    EmailConfirmed = true,
                };

                var r = await userManager.CreateAsync(user, "123456");
                if (!r.Succeeded)
                {
                    return BadRequest(r.Errors);
                }
                r = await userManager.AddToRoleAsync(user, "Admin");
                if (!r.Succeeded)
                {
                    return BadRequest(r.Errors);
                }
            }
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginRequest req)
        {
            string userName = req.UserName;
            string password = req.Password;
            var user = await userManager.FindByNameAsync(userName);
            if (user == null)
            {
                return NotFound($"用户名不存在{userName}");
            }
            if (await userManager.IsLockedOutAsync(user))
            {
                return BadRequest("LockedOut");
            }
            var success = await userManager.CheckPasswordAsync(user, password);
            if (success)
            {
                return Ok("Success");
            }
            else
            {
                // 调用userManager的AccessFailedAsync方法来记录一次“登录失败”，
                // 当连续多次登录失败之后，账户就会被锁定一段时间，以避免账户被暴力破解
                var r = await userManager.AccessFailedAsync(user);
                if (!r.Succeeded)
                {
                    return BadRequest("AccessFailed failed");
                }
                return BadRequest("Failed");
            }
        }

        [HttpPost]
        public async Task<IActionResult> SendResetPasswordToken(
            SendResetPasswordTokenRequest req)
        {
            string email = req.Email;
            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return NotFound($"邮箱不存在：[{email}]");
            }
            string token = await userManager.GenerateEmailConfirmationTokenAsync(user);
            logger.LogInformation($"向邮箱{user.Email}发送Token={token}");
            return Ok(token); 
        }
    }
}