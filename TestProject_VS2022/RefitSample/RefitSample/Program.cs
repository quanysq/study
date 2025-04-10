using Refit;
using RefitSample;

var userApi = RestService.For<IUserApi>("http://192.168.3.30:8386");
try
{
    var users = await userApi.GetUserList();
    // Console.WriteLine($"Total: {users.total}");

    Console.WriteLine($"ID: 1, Name: Jacky, Email: 51396859@qq.com");
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
