using System;

namespace csx
{
    using Roslyn.Compilers;
    using Roslyn.Scripting.CSharp;

    class Program
    {
        static void Main(string[] args)
        {

            var scriptEngine = new ScriptEngine();

            scriptEngine.AddReference("System");

            WritePromptLine();

            var code = new Code();
            var session = scriptEngine.CreateSession();
            session.Execute("");
            while (!code.IsExit)
            {
                try
                {
                    AddCodeLine(code);

                    if (code.IsExit) break;
                    
                    var result = session.Execute(code.Text);
                    
                    Console.WriteLine(result);

                    code.ClearNonLocalDeclarationLines();
                }
                catch (CompilationErrorException compilationErrorException)
                {
                    Console.WriteLine(compilationErrorException.Message);
                    code.Clear();
                }
                finally
                {
                    WritePromptLine();
                }
            }

            Console.WriteLine("bye");
        }


        private static void AddCodeLine(Code code)
        {
            code.AddLine(Console.ReadLine());

            if (code.IsMultiline)
                AddCodeLine(code);
        }

        private static void WritePromptLine()
        {
            Console.Write(">");
        }
    }
}
