// See https://aka.ms/new-console-template for more information
//Console.WriteLine($"Hello, World! {args.Length}");

using CodeGenerator;
using CodeGenerator.Model;
using CodeGenerator.Template;
using System.Configuration;

if (args.Length == 0)
{
    Console.WriteLine("Pls input the table name");
}
else
{
    var model = new CodeGeneratorModel();
    model.TableName = args[0];
    model.TableDesc = args[1];

    string viewModelPath        = ConfigurationManager.AppSettings["ViewModelPath"];
    string iRepositoryPath      = ConfigurationManager.AppSettings["IRepositoryPath"];
    string repositoryPath       = ConfigurationManager.AppSettings["RepositoryPath"];
    string iServicePath         = ConfigurationManager.AppSettings["IServicePath"];
    string servicePath          = ConfigurationManager.AppSettings["ServicePath"];

    string viewModelFileName    = ConfigurationManager.AppSettings["ViewModelFileName"];
    string iRepositoryFileName  = ConfigurationManager.AppSettings["IRepositoryFileName"];
    string repositoryFileName   = ConfigurationManager.AppSettings["RepositoryFileName"];
    string iServiceFileName     = ConfigurationManager.AppSettings["IServiceFileName"];
    string serviceFileName      = ConfigurationManager.AppSettings["ServiceFileName"];


    // 生成 ViewModel 文件
    var viewModeBuilder = new ViewModelFileBuilder(model);
    viewModeBuilder.BuildFile(viewModelPath, viewModelFileName);

    // 生成 IRepository 文件
    var irepositoryBuilder = new IRepositoryFileBuilder(model);
    irepositoryBuilder.BuildFile(iRepositoryPath, iRepositoryFileName);
    
    // 生成 Repository 文件
    var repositoryBuilder = new RepositoryFileBuilder(model);
    repositoryBuilder.BuildFile(repositoryPath, repositoryFileName);

    // 生成 IService 文件
    var iserviceBuilder = new IServiceFileBuilder(model);
    iserviceBuilder.BuildFile(iServicePath, iServiceFileName);

    // 生成 Service 文件
    var serviceBuilder = new ServiceFileBuilder(model);
    serviceBuilder.BuildFile(servicePath, serviceFileName);
}
