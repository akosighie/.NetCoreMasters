using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetCoreMasters.Filter
{
    public class ShowElapseTimeAttribute : IResultFilter
    {
        private Stopwatch _stopwatch;
        public ShowElapseTimeAttribute()
        {
            _stopwatch = new Stopwatch();
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            _stopwatch.Start();

        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            //Debug.WriteLine("Time Elapsed: " + _stopwatch.Elapsed);
            //Console.WriteLine("Time Elapsed: " + _stopwatch.Elapsed);
            byte[] bytes = Encoding.ASCII.GetBytes($" Elapsed Time : {_stopwatch.Elapsed}");
            context.HttpContext.Response.Body.WriteAsync(bytes, 0, bytes.Length);

            _stopwatch.Stop();
        }       
    }
}
