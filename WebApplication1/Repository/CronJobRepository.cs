using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Repository
{
    public class CronJobRepository : ICronJobRepository
    {
        public async Task WriteDebugTrace(string text)
        {
             System.Diagnostics.Debug.Write(text);
        }
    }
}
