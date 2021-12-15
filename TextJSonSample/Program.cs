using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace TextJSonSample
{
    internal class Program
    {
        public static async Task Serialize<T>(T obj, string path)
        {
            string jsonString = JsonSerializer.Serialize(obj);

            using FileStream createStream = File.Create(path);
            await JsonSerializer.SerializeAsync<T>(createStream, obj);
            await createStream.DisposeAsync();


            //File.WriteAllText(filePath, jsonString);
        }

        public static async Task<T> Deserialize<T>(string path)
        {
            using FileStream createStream = File.OpenRead(path);

            var obj = await JsonSerializer.DeserializeAsync<T>(createStream);

            return obj;
        }

        static async Task Main(string[] args)
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

            await Serialize(data, "./fichero.json");

            var deserialized = await Deserialize<DataStructure>("./fichero.json");

            Console.WriteLine("Deserialized (json) string:");
            Console.WriteLine("---------------------------");
            Console.WriteLine();
            Console.WriteLine(deserialized);
        }
    }
}