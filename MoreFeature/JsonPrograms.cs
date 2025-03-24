using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MoreFeature
{
    public class FeatureProgram
    {
        [JsonConstructor]
        public FeatureProgram(string name, string arguments, string path, string description)
        {
            this.Name = name;
            this.Arguments = arguments;
            this.Path = path;
            this.Description = description;
        }

        public string Name { get; }
        public string Arguments { get; }
        public string Path { get; }
        public string Description { get; }
    }

    public class FeaturePrograms
    {
        [JsonConstructor]
        public FeaturePrograms(FeatureProgram[] programs)
        {
            this.Programs = programs;
        }

        public FeatureProgram[] Programs { get; }
    }
}
