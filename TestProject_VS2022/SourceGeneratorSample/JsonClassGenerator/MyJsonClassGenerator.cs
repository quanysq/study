using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace JsonClassGenerator
{
    [Generator]
    public class MyJsonClassGenerator : ISourceGenerator
    {
        public void Initialize(GeneratorInitializationContext context)
        {
            // 可以在这里添加初始化逻辑
        }

        public void Execute(GeneratorExecutionContext context)
        {
            // JSON 文件的路径（相对于项目根目录）
            string jsonFilePath = "JsonClasses.json";

            // 检查文件是否存在
            if (File.Exists(jsonFilePath))
            {
                // 读取 JSON 文件内容
                string jsonContent = File.ReadAllText(jsonFilePath);
                var classDefinitions = ExtractClassDefinitions(jsonContent);

                // 生成每个类的源代码
                foreach (var classDef in classDefinitions)
                {
                    string sourceCode = GenerateClassCode(classDef);
                    context.AddSource($"{classDef.ClassName}.g.cs", SourceText.From(sourceCode, Encoding.UTF8));
                }
            }
            else
            {
                // 报告 JSON 文件不存错误
                context.ReportDiagnostic(Diagnostic.Create(
                    new DiagnosticDescriptor("JCG001", "File Not Found", "JSON file not found.", "Usage", DiagnosticSeverity.Warning, true),
                    Location.None));
            }
        }

        private List<ClassDefinition> ExtractClassDefinitions(string jsonContent)
        {
            // 反序列化 JSON 内容并提取类的定义
            // 假设 JSON 是一个对象数组，每个对象都有 Name 和 Properties 属性
            using (JsonDocument doc = JsonDocument.Parse(jsonContent))
            {
                return doc.RootElement.EnumerateArray()
                    .Select(obj => new ClassDefinition
                    {
                        ClassName = obj.GetProperty("Name").GetString(),
                        Properties = obj.GetProperty("Properties").EnumerateArray()
                                       .Select(p => new ClassProperty
                                       {
                                           PropertyName = p.GetProperty("Name").GetString(),
                                           PropertyType = p.GetProperty("Type").GetString()
                                       }).ToList()
                    }).ToList();
            }
        }

        private string GenerateClassCode(ClassDefinition classDef)
        {
            // 生成类代码
            var propertiesCode = string.Join(Environment.NewLine, classDef.Properties.Select(p =>
                $"    public {p.PropertyType} {p.PropertyName} {{ get; set; }}"));

            return $@"
using System;

namespace GeneratedClasses
{{
    public class {classDef.ClassName}
    {{
{propertiesCode}
        public {classDef.ClassName}() {{ }}

        // 可以在这里添加方法
    }}
}}";
        }
    }

    // 定义类和属性结构
    public class ClassDefinition
    {
        public string ClassName { get; set; }
        public List<ClassProperty> Properties { get; set; }
    }

    public class ClassProperty
    {
        public string PropertyName { get; set; }
        public string PropertyType { get; set; }
    }
}
