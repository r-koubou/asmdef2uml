
using System.Collections.Generic;

namespace Asmdef2Uml.Transpiler
{
    public interface ITranspiler
    {
        void Output(IDictionary<string, AssemblyRef> refList, List<string> excludeRegexList = null);
    }
}
