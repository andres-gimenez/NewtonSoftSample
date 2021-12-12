using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace TextJSonSample
{
    internal class Program
    {
        const string filePath = @".\json.txt";

        public static async Task Serialize<T>(T obj)
        {
            string jsonString = JsonSerializer.Serialize(obj);

            using FileStream createStream = File.Create(filePath);
            await JsonSerializer.SerializeAsync<T>(createStream, obj);
            await createStream.DisposeAsync();


            //File.WriteAllText(filePath, jsonString);
        }

        public static async Task<T> Deserialize<T>(string path)
        {
            using FileStream createStream = File.OpenRead(filePath);

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

            await Serialize(data);

            var deserialized = await Deserialize<DataStructure>(filePath);

            Console.WriteLine("Deserialized (json) string:");
            Console.WriteLine("---------------------------");
            Console.WriteLine();
            Console.WriteLine(deserialized);
        }
    }
}
