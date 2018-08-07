using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

using System.Threading.Tasks;

namespace MongoDB
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await WebHost.CreateDefaultBuilder(args)
                .UseKestrel()
                .UseSockets()
                .UseStartup<Startup>()
                .Build()
                .RunAsync();
        }
    }
}
