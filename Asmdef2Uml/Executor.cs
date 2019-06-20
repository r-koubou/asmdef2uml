using System;
using System.Collections.Generic;
using System.IO;

using Asmdef2Uml.Transpiler;

namespace Asmdef2Uml
{
    static public class Executor
    {
        static public void Execute(string baseDir, ITranspiler transpiler, List<string> excludeRegexList = null)
        {
            List<AssemblyDefinition> asmdefList = new List<AssemblyDefinition>();
            IDictionary<string, AssemblyRef> refs = new Dictionary<string, AssemblyRef>();

            string[] files = Directory.GetFiles(baseDir, "*.asmdef", SearchOption.AllDirectories);
            foreach (var i in files)
            {
                var asm = new AssemblyDefinition(i);
                asmdefList.Add(asm);
                refs[asm.AssemblyName] = new AssemblyRef(asm);
            }

            foreach (var r in refs.Values)
            {
                try
                {
                    r.ScanDependency(refs);
                }
                catch (StackOverflowException ex)
                {
                    Console.Error.WriteLine(ex.Message);
                }
            }

            transpiler.Output(refs, excludeRegexList);
        }
    }
}
