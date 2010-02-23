using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;
using System.Reflection;
using System.Text;
using Bricks.Core;
using Recorder.Domain;
using White.Core.Factory;
using White.Core.UIItems;
using White.Core.UIItems.WindowItems;
using Microsoft.CSharp;
using Recorder.CodeGeneration;
using Repository;
using White.Recorder.CodeGeneration;

namespace White.Recorder.Domain
{
    public class ScreenObjectGenerator
    {
        private readonly ScreenObjectGeneratorOptions options = new ScreenObjectGeneratorOptions();

        public virtual ScreenObjectGeneratorOptions Options
        {
            get { return options; }
        }

        public virtual string Generate(Window window)
        {
            window.ReInitialize(InitializeOption.WithCache);
            var stringBuilder = new StringBuilder();
            var stringWriter = new StringWriter(stringBuilder);

            var cscProvider = new CSharpCodeProvider();
            ICodeGenerator codeGenerator = cscProvider.CreateGenerator(stringWriter);
            var codeGeneratorOptions = new CodeGeneratorOptions {BlankLinesBetweenMembers = false, VerbatimOrder = false};

            codeGenerator.GenerateCodeFromCompileUnit(new CodeSnippetCompileUnit(string.Format("using {0};", typeof(UIItem).Namespace)), stringWriter, codeGeneratorOptions);
            codeGenerator.GenerateCodeFromCompileUnit(new CodeSnippetCompileUnit(string.Format("using {0};", typeof(Window).Namespace)), stringWriter, codeGeneratorOptions);
            codeGenerator.GenerateCodeFromCompileUnit(new CodeSnippetCompileUnit(string.Format("using {0};", typeof(AppScreen).Namespace)), stringWriter, codeGeneratorOptions);

            CodeNamespace codeNamespace = null;
            if (S.IsNotEmpty(options.Namespace))
            {
                codeNamespace = new CodeNamespace(options.Namespace);
            }

            var classDefinition = new CodeTypeDeclaration
                                      {
                                          IsClass = true,
                                          IsPartial = true,
                                          Name = window.Title.Trim().Replace(" ", string.Empty),
                                          TypeAttributes = TypeAttributes.Public
                                      };
            classDefinition.BaseTypes.Add(typeof (AppScreen));

            var constructor = new CodeConstructor {Attributes = MemberAttributes.Family};
            classDefinition.Members.Add(constructor);

            constructor = new CodeConstructor {Attributes = MemberAttributes.Public};
            constructor.Parameters.Add(new CodeParameterDeclarationExpression(typeof(Window), "window"));
            constructor.Parameters.Add(new CodeParameterDeclarationExpression(typeof (ScreenRepository), "screenRepository"));
            constructor.BaseConstructorArgs.Add(new CodeVariableReferenceExpression("window"));
            constructor.BaseConstructorArgs.Add(new CodeVariableReferenceExpression("screenRepository"));
            classDefinition.Members.Add(constructor);

            var visitor = new CodeGenerationVisitor(new WindowCodeGenerationStrategy(options));
            window.Visit(visitor);
            visitor.Generate(classDefinition);

            if (codeNamespace != null)
            {
                codeNamespace.Types.Add(classDefinition);
                codeGenerator.GenerateCodeFromNamespace(codeNamespace, stringWriter, codeGeneratorOptions);
            }
            else
            {
                codeGenerator.GenerateCodeFromType(classDefinition, stringWriter, codeGeneratorOptions);                
            }

            stringWriter.Close();
            return stringBuilder.ToString();
        }
    }
}