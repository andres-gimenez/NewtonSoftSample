using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewtonSoftSample
{
    public class DataStructure
    {
        [JsonProperty("PersonalName")]
        public string Name { get; set; }

        [JsonProperty]
        public List<int> Identifiers { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Name:{0}", Name);
            sb.AppendFormat("Identifiers: {0}", string.Join<int>(",", Identifiers));

            return sb.ToString();
        }
    }
}
