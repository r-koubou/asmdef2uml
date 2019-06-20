
using System;
using System.Collections.Generic;
using Asmdef2Uml.Transpiler;
using Asmdef2Uml.Transpiler.PlantUml;

namespace Asmdef2Uml.App
{
    class ConsoleProgram
    {
        static void Main(string[] args)
        {
            List<string> excludeRegexList = new List<string>();

            if( args.Length == 0)
            {
                Usage();
                return;
            }
            if( args.Length >= 2)
            {
                for (int i = 1; i < args.Length; i++)
                {
                    excludeRegexList.Add(args[i]);
                }
            }

            ITranspiler transpiler = new Stdout();
            Executor.Execute(args[0], transpiler, excludeRegexList);
        }

        static void Usage()
        {
            Console.Error.WriteLine("Asmdef2Uml <scan directory> [exclude assembly name (Regex)]");
            Console.Error.WriteLine("e.g.");
            Console.Error.WriteLine(@"  Asmdef2Uml C:\Hoge\Foo\Bar");
            Console.Error.WriteLine(@"  Asmdef2Uml C:\Hoge\Foo\Bar .*Test.*");
        }
    }
}
