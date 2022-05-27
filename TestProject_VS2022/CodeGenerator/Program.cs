// See https://aka.ms/new-console-template for more information
//Console.WriteLine($"Hello, World! {args.Length}");

using CodeGenerator;
using CodeGenerator.Model;
using CodeGenerator.Template;
using CodeGenerator.Util;
using System.Configuration;
using System.Reflection;

var configFile = "";
if (args.Length == 0)
{
    configFile = "./CustomConfig.config";
}
else
{
    configFile = args[0];
}

var model = ConfigUtil.Deserialize<CodeGeneratorModel>(configFile);
object[] parameters = new object[1];
parameters[0] = model;
foreach (var item in model.GeneratorFiles.GeneratorFileList)
{
    FileBuilder factory = Assembly.Load("CodeGenerator")
                                  .CreateInstance("CodeGenerator." + item.FileBuilder, 
                                                    true, 
                                                    BindingFlags.Default, 
                                                    null, 
                                                    parameters, 
                                                    null, 
                                                    null) as FileBuilder;
    if (factory != null) factory.BuildFile(item.FilePath, item.FileName);
}

/*
 * 新加一个文件模板流程：
 * 1. 添加 tt 文件（T4模板）并填充相应的模板内容和创建部分类
 * 2. 添加一个新的 FileBuilder 具体实现类
 * 3. 修改 CustomConfig.config，在 GeneratorFiles 处添加新的 GeneratorFile 节点
 */ 