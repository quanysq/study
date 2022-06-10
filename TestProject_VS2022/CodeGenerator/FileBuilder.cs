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
        private readonly string entityPath;
        public ViewModelFileBuilder(CodeGeneratorModel model) : base(model)
        {
            var entityFileName = $"{Parameter.TableName}.cs";
            entityPath = Path.Combine(model.GeneratorFiles.BasePath,
                                      model.GeneratorFiles.EntityPath,
                                      entityFileName);
        }

        /// <summary>
        /// 获取实体类内容
        /// </summary>
        private void GetEntityContent()
        {
            if (!File.Exists(entityPath)) return;
            using (var sr = new StreamReader(entityPath))
            {
                var fileContent = new StringBuilder(16);
                string line;
                var compareTxt = "public partial class";
                var compareRet = false;
                var startTxt = "{";
                var endTxt = "}";
                while ((line = sr.ReadLine()) != null)
                {
                    var lineNote = line.Trim();
                    if (!compareRet)
                    {
                        if (lineNote.StartsWith(compareTxt, StringComparison.OrdinalIgnoreCase))
                        {
                            // 如果读取到 class 声明行，设置 compareRet=true
                            // 表示从下一行开始存储内容
                            compareRet = true; 
                        }
                    }
                    else
                    {
                        // 读取到 class 块最后一行，跳出循环 
                        if (lineNote == endTxt) break;
                        if (lineNote == startTxt) continue;
                        fileContent.AppendLine(line);
                    }
                }
                Parameter.EntityContent = fileContent.ToString();
            }
        }

        public override void BuildFile(string filePath, string fileName)
        {
            GetEntityContent();

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
            if (string.IsNullOrWhiteSpace(Parameter.ControllerName))
            {
                return;
            }
            var page = new Controller(Parameter);
            Build(page, filePath, fileName);
        }
    }

    /// <summary>
    /// 具体产品类 ViewFileBuilder，生成 View 文件
    /// </summary>
    public class ViewFileBuilder : FileBuilder
    {
        public ViewFileBuilder(CodeGeneratorModel model) : base(model)
        {

        }

        public override void BuildFile(string filePath, string fileName)
        {
            if (string.IsNullOrWhiteSpace(Parameter.ControllerName))
            {
                return;
            }

            var page = new View(Parameter);
            Build(page, filePath, fileName);
        }
    }

    /// <summary>
    /// 具体产品类 JSControllerFileBuilder，生成 Javascript Controller 文件
    /// </summary>
    public class JSControllerFileBuilder : FileBuilder
    {
        public JSControllerFileBuilder(CodeGeneratorModel model) : base(model)
        {

        }

        public override void BuildFile(string filePath, string fileName)
        {
            if (string.IsNullOrWhiteSpace(Parameter.ControllerName))
            {
                return;
            }

            var page = new JSController(Parameter);
            Build(page, filePath, fileName);
        }
    }

    /// <summary>
    /// 具体产品类 JSVueFileBuilder，生成 Javascript Vue 文件
    /// </summary>
    public class JSVueFileBuilder : FileBuilder
    {
        public JSVueFileBuilder(CodeGeneratorModel model) : base(model)
        {

        }

        public override void BuildFile(string filePath, string fileName)
        {
            if (string.IsNullOrWhiteSpace(Parameter.ControllerName))
            {
                return;
            }

            var page = new JSVue(Parameter);
            Build(page, filePath, fileName);
        }
    }
}
