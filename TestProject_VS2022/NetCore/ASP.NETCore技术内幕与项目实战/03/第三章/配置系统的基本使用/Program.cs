using Microsoft.Extensions.Configuration;

//手动读取配置
ConfigurationBuilder configuration = new ConfigurationBuilder();
configuration.AddJsonFile("config.json", optional: false, reloadOnChange: false);
IConfigurationRoot config = configuration.Build();
string name = config["name"]!;
Console.WriteLine($"name={name}");
string proxyAddress = config.GetSection("proxy:address").Value!;
Console.WriteLine($"Address:{proxyAddress}");