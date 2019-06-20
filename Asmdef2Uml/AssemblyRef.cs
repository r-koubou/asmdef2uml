
using System;
using System.Collections.Generic;

namespace Asmdef2Uml
{
    public class AssemblyRef
    {
        public AssemblyDefinition Assembly { get; }
        public List<AssemblyRef> Dependencies { get; }

        int refCount;
        const int RefThreshold = 8;

        public AssemblyRef(AssemblyDefinition assembly)
        {
            Assembly = assembly;
            Dependencies = new List<AssemblyRef>();
        }

        public void ScanDependency(IDictionary<string,AssemblyRef> refList)
        {
            foreach (var name in Assembly.ReferencesNames)
            {
                if (name != Assembly.AssemblyName)
                {
                    var r = refList[name];
                    if( r.refCount>=RefThreshold)
                    {
                        r.refCount = 0;
                        throw new StackOverflowException($"[WARN] Circular reference? (Incl Indirectly) : {r}->{this}");
                    }

                    r.refCount++;
                    r.ScanDependency(refList);
                    r.refCount--;

                    if (!Dependencies.Contains(r))
                    {
                        Dependencies.Add(r);
                    }
                }
            }
        }

        public override string ToString()
        {
            return Assembly.AssemblyName;
        }
    }
}
