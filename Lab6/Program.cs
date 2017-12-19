using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Lab6
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build()
                .Run();
        }
    }
}