using CodeGenerator.Model;
using CodeGenerator.Template;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenerator
{
    /// <summary>
    /// 产品抽象类，用于生成文件
    /// </summary>
    public abstract class FileBuilder
    {
        protected CodeGeneratorModel model;

        protected CodeGeneratorParameter Parameter
        {
            get { return model.CodeGeneratorParameter; }
        }

        public FileBuilder(CodeGeneratorModel model)
        {
            this.model = model;
        }

        public abstract void BuildFile(string filePath, string fileName);

        protected void Build(dynamic objTemplate, string filePath, string fileName)
        {
            string fileContent = objTemplate.TransformText();
            fileName = fileName.Replace("{Parameter.TableName}", Parameter.TableName)
                               .Replace("{Parameter.ControllerName}", Parameter.ControllerName)
                               .Replace("{Parameter.ControllerNameLower}", Parameter.ControllerNameLower);
            filePath = filePath.Replace("{Parameter.ControllerName}", Parameter.ControllerName);
            var fileDir = Path.Combine(model.GeneratorFiles.BasePath, filePath);
            if (!Directory.Exists(fileDir)) Directory.CreateDirectory(fileDir);
            filePath = Path.Combine(fileDir, fileName);
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, fileContent);
                Console.WriteLine($"已创建文件：[{filePath}]");
            }
            else
            {
                Console.WriteLine($"已存在文件：[{filePath}]");
            }
        }
    }

    /// <summary>
    /// 具体产品类 ViewModelFileBuilder，生成 ViewModel 文件
    /// </summary>
    public class ViewModelFileBuilder : FileBuilder
    {
        public ViewModelFileBuilder(CodeGeneratorModel model) : base(model)
        {

        }

        public override void BuildFile(string filePath, string fileName)
        {
            var page = new ViewModel(Parameter);
            Build(page, filePath, fileName);
        }
    }

    /// <summary>
    /// 具体产品类 IRepositoryFileBuilder，生成 IRepository 文件
    /// </summary>
    public class IRepositoryFileBuilder : FileBuilder
    {
        public IRepositoryFileBuilder(CodeGeneratorModel model) : base(model)
        {

        }

        public override void BuildFile(string filePath, string fileName)
        {
            var page = new IRepository(Parameter);
            Build(page, filePath, fileName);
        }
    }

    /// <summary>
    /// 具体产品类 RepositoryFileBuilder，生成 Repository 文件
    /// </summary>
    public class RepositoryFileBuilder : FileBuilder
    {
        public RepositoryFileBuilder(CodeGeneratorModel model) : base(model)
        {

        }

        public override void BuildFile(string filePath, string fileName)
        {
            var page = new Repository(Parameter);
            Build(page, filePath, fileName);
        }
    }

    /// <summary>
    /// 具体产品类 IServiceFileBuilder，生成 IService 文件
    /// </summary>
    public class IServiceFileBuilder : FileBuilder
    {
        public IServiceFileBuilder(CodeGeneratorModel model) : base(model)
        {

        }

        public override void BuildFile(string filePath, string fileName)
        {
            var page = new IService(Parameter);
            Build(page, filePath, fileName);
        }
    }

    /// <summary>
    /// 具体产品类 ServiceFileBuilder，生成 Service 文件
    /// </summary>
    public class ServiceFileBuilder : FileBuilder
    {
        public ServiceFileBuilder(CodeGeneratorModel model) : base(model)
        {

        }

        public override void BuildFile(string filePath, string fileName)
        {
            var page = new Service(Parameter);
            Build(page, filePath, fileName);
        }
    }

    /// <summary>
    /// 具体产品类 ControllerFileBuilder，生成 Controller 文件
    /// </summary>
    public class ControllerFileBuilder : FileBuilder
    {
        public ControllerFileBuilder(CodeGeneratorModel model) : base(model)
        {

        }

        public override void BuildFile(string filePath, string fileName)
        {
            var page = new Controller(Parameter);
            Build(page, filePath, fileName);
        }
    }

    /// <summary>
    /// 具体产品类 ServiceFileBuilder，生成 Service 文件
    /// </summary>
    public class ViewFileBuilder : FileBuilder
    {
        public ViewFileBuilder(CodeGeneratorModel model) : base(model)
        {

        }

        public override void BuildFile(string filePath, string fileName)
        {
            var page = new View(Parameter);
            Build(page, filePath, fileName);
        }
    }

    /// <summary>
    /// 具体产品类 ServiceFileBuilder，生成 Service 文件
    /// </summary>
    public class JSControllerFileBuilder : FileBuilder
    {
        public JSControllerFileBuilder(CodeGeneratorModel model) : base(model)
        {

        }

        public override void BuildFile(string filePath, string fileName)
        {
            var page = new JSController(Parameter);
            Build(page, filePath, fileName);
        }
    }

    /// <summary>
    /// 具体产品类 ServiceFileBuilder，生成 Service 文件
    /// </summary>
    public class JSVueFileBuilder : FileBuilder
    {
        public JSVueFileBuilder(CodeGeneratorModel model) : base(model)
        {

        }

        public override void BuildFile(string filePath, string fileName)
        {
            var page = new JSVue(Parameter);
            Build(page, filePath, fileName);
        }
    }
}
