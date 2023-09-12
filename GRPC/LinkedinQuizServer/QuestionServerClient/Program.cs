using Grpc.Core;
using Grpc.Net.Client;
using System;
using System.Linq;
using System.Threading.Tasks;
using Questions.Proto.Bufs;

namespace QuestionServerClient {
    class Program {
        static async Task Main(string[] args) {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new QuestionsService.QuestionsServiceClient(channel);
            //var reply = await client.GetCustomerInfoAsync(new CustomerInfoLookup { UserId = 1 });

            client.GetAllQuestionsList(new EmptyReq()).Questions.ToList().ForEach(x => Console.WriteLine($"Q{x.Id}. {x.Text}"));
            Console.WriteLine("\n\n\n");

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            var q = new CreateOrUpdateQuestionRequest {
                Text = "How to stop giving fucks?"
            };
            var res = client.CreateOrUpdate(q);
            client.GetAllQuestionsList(new EmptyReq()).Questions.ToList().ForEach(x => Console.WriteLine($"Q{x.Id}. {x.Text}"));
            Console.WriteLine("\n\n\n");

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            q.Id = 5;
            q.Text = $"{q.Text}... updated";
            client.CreateOrUpdate(q);
            client.GetAllQuestionsList(new EmptyReq()).Questions.ToList().ForEach(x => Console.WriteLine($"Q{x.Id}. {x.Text}"));
            Console.WriteLine("\n\n\n");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();

            client.Delete(new DefaultFilterReq { Id = "3" });
            client.GetAllQuestionsList(new EmptyReq()).Questions.ToList().ForEach(x => Console.WriteLine($"Q{x.Id}. {x.Text}"));


            //Console.WriteLine("Greeting: " + reply.FirstName);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
