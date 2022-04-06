using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TextJSonSample
{
    public class Vehiculo
    {
        public Guid IdVehiculo { get; set; }
        public string Matricula { get; set; }
        public string Modelo { get; set; }

        public Color Color { get; set; }
        
        [JsonIgnore]
        public Cliente Cliente { get; set; }
    }
}
