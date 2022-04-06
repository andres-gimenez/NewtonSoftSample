using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TextJSonSample
{
    public class Cliente
    {
        public Guid IdCliente { get; set; }

        [JsonPropertyNameAttribute("PersonalName")]
        public string Nombre { get; set; }

        [JsonPropertyNameAttribute("FamilyName")]
        public string Apellidos { get; set; }

        public List<Vehiculo> Vehiculos { get; set; }
    }
}
