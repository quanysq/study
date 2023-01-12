using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ASPNETCore_JWT1.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class Test1Controller : ControllerBase
    {
        private readonly UserManager<User> userManager;

        //注入 UserManager
        public Test1Controller(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        // 生成 JWT
        private static string BuildToken(IEnumerable<Claim> claims, JWTOptions options)
        {
            DateTime expires = DateTime.Now.AddSeconds(options.ExpireSeconds);
            byte[] keyBytes = Encoding.UTF8.GetBytes(options.SigningKey);
            var secKey = new SymmetricSecurityKey(keyBytes);
            var credentials = new SigningCredentials(secKey, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new JwtSecurityToken(
                expires: expires, signingCredentials: 
                credentials, 
                claims: claims);
            var result = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor); 
            return result;
        }

        // 在方法中注入 IOptions<JWTOptions> 
        // 只需要返回 JWT Token 即可，其它的身份验证中间件会处理
        [HttpPost]
        public async Task<IActionResult> Login(
            LoginRequest req,
            [FromServices] IOptions<JWTOptions> jwtOptions)
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
            if (!success)
            {
                return BadRequest("Failed");
            }
            
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Name, user.UserName));
            var roles = await userManager.GetRolesAsync(user);
            foreach (string role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var jwtToken = BuildToken(claims, jwtOptions.Value);
            return Ok(jwtToken);
        }
    }
}