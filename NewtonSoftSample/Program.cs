using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace NewtonSoftSample
{
    internal class Program
    {
        public static void Serialize<T>(T obj, string path)
        {
            var serializer = new JsonSerializer();

            using (var sw = new StreamWriter(path))
            {
                using (JsonWriter writer = new JsonTextWriter(sw))
                {
                    serializer.Serialize(writer, obj);
                }
            }
        }

        public static T Deserialize<T>(string path)
        {
            var serializer = new JsonSerializer();

            using (var sw = new StreamReader(path))
            {
                using (var reader = new JsonTextReader(sw))
                {
                    return serializer.Deserialize<T>(reader);
                }
            }
        }

        static void Main(string[] args)
        {
            var data = new DataStructure
            {
                Name = "Henry",
                Identifiers = new List<int> { 1, 2, 3, 4 }
            };

            Console.WriteLine("Object before serialization:");
            Console.WriteLine("----------------------------");
            Console.WriteLine();
            Console.WriteLine(data);

            Console.WriteLine(data.Name);

            Serialize(data, "./data1.json");

            var deserialized = Deserialize<DataStructure>("./data1.json");

            Console.WriteLine("Deserialized (json) string:");
            Console.WriteLine("---------------------------");
            Console.WriteLine();
            Console.WriteLine(deserialized);
            Console.WriteLine(deserialized.Name);

            var persona = new Persona
            {
                Name = "Henry",
                Age = 32
            };

            Serialize(persona, "./data2.json");

            var deserializedPersona = Deserialize<Persona>("./data2.json");
        }
    }
}
