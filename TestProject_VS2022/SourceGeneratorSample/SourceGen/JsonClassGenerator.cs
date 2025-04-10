using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Text;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace SourceGen
{
    [Generator]
    public class JsonClassGenerator : ISourceGenerator
    {
        public void Execute(GeneratorExecutionContext context)
        {
            var syntaxTrees = context.Compilation.SyntaxTrees;

            foreach (var tree in syntaxTrees)
            {
                var root = tree.GetRoot();
                var classes = root.DescendantNodes().OfType<ClassDeclarationSyntax>();

                foreach (var classDeclaration in classes)
                {
                    var className = classDeclaration.Identifier.Text;
                    var properties = classDeclaration.Members.OfType<PropertyDeclarationSyntax>();
                    var propertiesList = string.Join(", ", properties.Select(p => $"{p.Identifier.Text} = {{{p.Identifier.Text}}}"));
                    var toStringMethod = $@"
public partial class {className} {{
    public override string ToString() => ""{className} {{{propertiesList}}}"";
}}
                ";
                    context.AddSource($"{className}_ToString.g.cs", SourceText.From(toStringMethod, Encoding.UTF8));
                }
            }
        }

        public void Initialize(GeneratorInitializationContext context)
        {
            // 可以在这里初始化任何需要的对象或资源
        }
    }
}
