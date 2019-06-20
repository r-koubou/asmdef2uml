
using System.Collections.Generic;
using System.IO;
using Asmdef2Uml.MiniJSON;

namespace Asmdef2Uml
{
    /// <summary>
    /// Data model of Unity assembly definition file.
    /// </summary>
    public class AssemblyDefinition
    {
        public string FileName { get; }
        public string AssemblyName { get; }
        public List<string> ReferencesNames { get; }
        public IDictionary<string, object> JsonData { get; }

        public AssemblyDefinition(string asmdefFilePath)
        {
            string jsonText = File.ReadAllText(asmdefFilePath);
            JsonData = Json.Deserialize(jsonText) as Dictionary<string, object>;

            FileName = asmdefFilePath;
            AssemblyName = JsonData["name"] as string;
            ReferencesNames = new List<string>();
            if (JsonData.ContainsKey("references"))
            {
                foreach (var item in JsonData["references"] as List<object>)
                {
                    ReferencesNames.Add(item.ToString());
                }
            }
        }
    }
}
