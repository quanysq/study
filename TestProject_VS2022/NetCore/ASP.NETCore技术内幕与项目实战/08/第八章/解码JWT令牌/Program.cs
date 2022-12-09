using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

string jwt = "eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IjYiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoieXprIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjpbIlVzZXIiLCJBZG1pbiJdLCJQYXNzUG9ydCI6IkU5MDAwMDA4MiIsImV4cCI6MTY3MDY2MjkxMn0.aYZcJmIzZmIo1v3Kt8fQeJY0sy3E0hPI79r_cqZqebc";
Console.WriteLine("Test1 Method:");
Test1(jwt);
Console.WriteLine("===========================");
Console.WriteLine("Test2 Method:");
Test2(jwt);

/// <summary>
/// 使用 FromBase64String 对 jwt token 进行解码
/// 无法分辨数据是否被篡改过
/// </summary>
void Test1(string jwt)
{
    //使用Split方法用句点作为分隔符对字符串进行分隔，
    //然后取出第一部分和第二部分作为解码之前的头部和负载
    string[] segments=jwt.Split('.');
    string head = JwtDecode(segments[0]);
    string payload = JwtDecode(segments[1]);
    Console.WriteLine("--------head--------");
    Console.WriteLine(head);
    Console.WriteLine("--------payload--------");
    Console.WriteLine(payload);

    //内嵌函数
    string JwtDecode(string s)
    {
        s = s.Replace('-', '+').Replace('_', '/');
        switch (s.Length % 4)
        {
            case 2:
                s += "==";
                break;
            case 3:
                s += "=";
                break;
        }
        var bytes = Convert.FromBase64String(s);
        var result = Encoding.UTF8.GetString(bytes);
        return result;
    }
}

/// <summary>
/// 调用JwtSecurityTokenHandler类对JWT令牌进行解码
/// 可以分辨数据是否被篡改过
/// </summary>
void Test2(string jwt)
{
    string secKey = "fasdfad&9045dafz222#fadpio@0232";
    JwtSecurityTokenHandler tokenHandler = new();
    TokenValidationParameters valParam = new();
    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secKey));
    valParam.IssuerSigningKey = securityKey;
    valParam.ValidateIssuer = false;
    valParam.ValidateAudience = false;
    ClaimsPrincipal claimsPrincipal = tokenHandler.ValidateToken(jwt, valParam, out SecurityToken securityToken);
    foreach (var claim in claimsPrincipal.Claims)
    {
        Console.WriteLine($"{claim.Type}={claim.Value}");
    }
}
