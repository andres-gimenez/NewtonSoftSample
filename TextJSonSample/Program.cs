using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace TextJSonSample
{
    internal class Program
    {
        public static async Task SerializeAsync<T>(T obj, string path)
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
            var cliente = new Cliente
            {
                IdCliente = Guid.NewGuid(),
                Nombre = "Pepe",
                Apellidos = "Pena"
            };

            cliente.Vehiculos = new List<Vehiculo>(
                    new[] {
                        new Vehiculo
                        {
                            IdVehiculo = Guid.NewGuid(),
                            Matricula = "XXXX-XXX",
                            Modelo = "Porche",
                            Color = Color.Rojo,
                            Cliente = cliente
                        },
                        new Vehiculo
                        {
                            IdVehiculo = Guid.NewGuid(),
                            Matricula = "XXXX-XXX",
                            Modelo = "Mercedes",
                            Color = Color.Gris,
                            Cliente = cliente
                        },
                });

            Console.WriteLine("Object before serialization:");
            Console.WriteLine("----------------------------");
            Console.WriteLine();
            Console.WriteLine(data);

            await SerializeAsync(data, "./Cliente.json");

            var deserialized = await Deserialize<Cliente>("./Cliente.json");

            Console.WriteLine("Deserialized (json) string:");
            Console.WriteLine("---------------------------");
            Console.WriteLine();
            Console.WriteLine(deserialized);
        }
    }
}