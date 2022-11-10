using Microsoft.Extensions.Configuration;

ConfigurationBuilder configuration = new ConfigurationBuilder();
configuration.AddCommandLine(args);
IConfigurationRoot config = configuration.Build();
string server = config["server"]!;
Console.WriteLine($"server:{server}");