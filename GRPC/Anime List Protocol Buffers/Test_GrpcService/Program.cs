using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using GrpcServer;

namespace Test_GrpcService {
    public class Program {
        //public static void Main(string[] args) {
        //    //CreateHostBuilder(args).Build().Run();

        //    // The port number(5001) must match the port of the gRPC server.
        //    var channel = GrpcChannel.ForAddress("https://localhost:5001");
        //    var client = new Fucker.FuckerClient(channel);
        //    var reply = await client.FuckABitch(new FuckABitchReq { Name = "GreeterClient" });
        //    Console.WriteLine("Greeting: " + reply.Message);
        //    Console.WriteLine("Press any key to exit...");
        //    Console.ReadKey();
        //}

        static async Task Main(string[] args) {
            // The port number(5001) must match the port of the gRPC server.
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Fucker.FuckerClient(channel);
            var reply = client.FuckABitch( new FuckABitchReq { Name = "Britny Bitch" });
            Console.WriteLine("Greeting: " + reply.Message);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }

        // Additional configuration is required to successfully run gRPC on macOS.
        // For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682
        //public static IHostBuilder CreateHostBuilder(string[] args) =>
        //    Host.CreateDefaultBuilder(args)
        //        .ConfigureWebHostDefaults(webBuilder => {
        //            webBuilder.UseStartup<Startup>();
        //        });
    }
}
