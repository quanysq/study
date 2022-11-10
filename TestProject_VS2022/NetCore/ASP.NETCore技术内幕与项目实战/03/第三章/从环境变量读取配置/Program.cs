using Microsoft.Extensions.Configuration;

ConfigurationBuilder configBuilder = new ConfigurationBuilder();
//configBuilder.AddEnvironmentVariables("TEST_");
configBuilder.AddEnvironmentVariables();
IConfigurationRoot config = configBuilder.Build();
//string name = config["Name"];
//Console.WriteLine(name);
var list = config.GetChildren();
foreach (var item in list)
{
    Console.WriteLine(item.Value);
}