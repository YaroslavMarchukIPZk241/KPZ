using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class MemoryUtil
    {
        public static long GetMemoryUsage()
        {
            using Process process = Process.GetCurrentProcess();
            process.Refresh();
            return process.PrivateMemorySize64;
        }
    }

}
