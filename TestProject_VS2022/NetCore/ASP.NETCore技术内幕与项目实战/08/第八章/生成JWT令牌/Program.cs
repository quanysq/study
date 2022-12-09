using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

//Claim代表用户信息
//一个Claim就代表一条用户信息
//Claim有两个主要的属性：Type和Value
//它们都是string类型的，Type代表用户信息的类型，Value代表用户信息的值
//Type可以取任意值
//不过，一般Type的值都取自ClaimTypes类中的成员
//好处是可以更方便地与其他系统对接
//下面代码创建了5个Claim对象
var claims = new List<Claim>();
claims.Add(new Claim(ClaimTypes.NameIdentifier, "6"));
claims.Add(new Claim(ClaimTypes.Name, "yzk"));
claims.Add(new Claim(ClaimTypes.Role, "User"));
claims.Add(new Claim(ClaimTypes.Role, "Admin"));
claims.Add(new Claim("PassPort", "E90000082")); //自定义的PassPort为E90000082的用户护照信息

//对JWT进行签名的密钥
string key = "fasdfad&9045dafz222#fadpio@0232";
//设置令牌的过期时间
DateTime expires = DateTime.Now.AddDays(1);
//根据过期时间、多个Claim对象、密钥来生成JWT
byte[] secBytes = Encoding.UTF8.GetBytes(key);
var secKey = new SymmetricSecurityKey(secBytes);
var credentials = new SigningCredentials(secKey, SecurityAlgorithms.HmacSha256Signature); //算法
var tokenDescriptor = new JwtSecurityToken(claims: claims, expires: expires, signingCredentials: credentials);
string jwt = new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
Console.WriteLine(jwt);