using AnimeListServer.Protos;
using Grpc.Net.Client;
using System;
using System.Threading.Tasks;

namespace AnimeListClient {
    class Program {
        static async Task Main(string[] args) {

            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Customer.CustomerClient(channel);
            var reply = await client.GetCustomerInfoAsync(new CustomerInfoLookup {  UserId = 1});
            Console.WriteLine("Greeting: " + reply.FirstName);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            Console.WriteLine("Hello World!");
        }
    }
}
