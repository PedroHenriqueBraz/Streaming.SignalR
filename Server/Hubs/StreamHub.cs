using Microsoft.AspNetCore.SignalR;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Server.Hubs
{
    public class StreamHub: Hub
    {
        public async IAsyncEnumerable<int> Counter(int count, int delay, [EnumeratorCancellation]CancellationToken cancellationToken)
        {
            for (var i = 0; i < count; i++)
            {
                cancellationToken.ThrowIfCancellationRequested();

                Console.WriteLine("returning.."+ i.ToString());
                yield return i;

                await Task.Delay(delay, cancellationToken);
            }
        }

        public async IAsyncEnumerable<Measure> Temperatures()
        {
            var i = 1;

            while (i > 0)
            {
                Random random = new Random();

                var dado = new Measure
                {
                    temp1 = random.Next(5, 10),
                    temp2 = random.Next(2, 7),
                    tempo = i
                };

                Console.WriteLine(i);
                i++;

                yield return dado;
                await Task.Delay(2000);
            }
        }
    }
}
