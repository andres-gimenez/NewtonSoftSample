using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewtonSoftSample
{
    public class Persona
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Name:{0}", Name);
            sb.AppendFormat("Age: {0}", Age);

            return sb.ToString();
        }
    }
}
