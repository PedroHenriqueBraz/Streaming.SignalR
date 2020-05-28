using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        private static HubConnection connection;

        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            connection = new HubConnectionBuilder()
              .WithUrl("http://localhost:5000/stream")
              .WithAutomaticReconnect()
              .Build();

            await connection.StartAsync();

            var cancellationTokenSource = new CancellationTokenSource();

            var stream = connection.StreamAsync<int>("Counter", 10, 500, cancellationTokenSource.Token);

            await foreach (var count in stream)
            {
                Console.WriteLine($"{count}");
            }

            Console.WriteLine("Streaming completed");
        }
    }
}
