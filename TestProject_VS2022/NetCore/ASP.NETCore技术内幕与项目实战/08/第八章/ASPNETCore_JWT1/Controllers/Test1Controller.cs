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

        //ע�� UserManager
        public Test1Controller(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        // ���� JWT
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

        // �ڷ�����ע�� IOptions<JWTOptions> 
        // ֻ��Ҫ���� JWT Token ���ɣ������������֤�м���ᴦ��
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
                return NotFound($"�û���������{userName}");
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