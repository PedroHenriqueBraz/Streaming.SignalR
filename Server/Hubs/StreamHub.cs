using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
