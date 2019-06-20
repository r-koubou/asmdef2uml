
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Asmdef2Uml.Transpiler
{
    static public class AssemblyNameMatcher
    {
        static public bool IsMatch( string assemblyName, List<string> patterns )
        {
            if( patterns == null || patterns.Count==0)
            {
                return false;
            }

            foreach (var i in patterns)
            {
                if( Regex.IsMatch(assemblyName,i))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
