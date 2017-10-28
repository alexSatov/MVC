using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Task1
{
    public class RequestTimeMiddleware
    {
        public readonly RequestDelegate next;

        public RequestTimeMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            await context.Response.WriteAsync("Start\n");

            var stopwatch = new Stopwatch();

            stopwatch.Start();

            var milliseconds = new Random().Next(1, 5) * 1000;

            await Task.Delay(milliseconds);
            stopwatch.Stop();
            await context.Response.WriteAsync($"End: {stopwatch.ElapsedMilliseconds}");
        }
    }
}