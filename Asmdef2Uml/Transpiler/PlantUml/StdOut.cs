
using System;
using System.Collections.Generic;

namespace Asmdef2Uml.Transpiler.PlantUml
{
    public class Stdout : ITranspiler
    {
        public void Output(IDictionary<string, AssemblyRef> refList, List<string> excludeRegexList = null)
        {
            Action<Action<AssemblyRef>> write = (impl) => {
                foreach (var r in refList.Values)
                {
                    if (AssemblyNameMatcher.IsMatch(r.Assembly.AssemblyName, excludeRegexList))
                    {
                        continue;
                    }
                    impl(r);
                }
            };

            Console.WriteLine("@startuml");
            write((r) => Console.WriteLine($"    package {r.Assembly.AssemblyName} {{}}"));
            write((r) => {
                foreach (var d in r.Dependencies)
                {
                    Console.WriteLine($"    {r.Assembly.AssemblyName}..>{d.Assembly.AssemblyName}");
                }
            });
            Console.WriteLine("@enduml");
        }
    }
}
