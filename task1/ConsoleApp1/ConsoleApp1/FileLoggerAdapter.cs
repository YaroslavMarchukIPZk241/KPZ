using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public interface ILogger
    {
        void Log(string message);
        void Error(string message);
        void Warn(string message);
    }

    public class FileLoggerAdapter : ILogger
    {
        private readonly FileWriter fileWriter;

        public FileLoggerAdapter(string filePath)
        {
            fileWriter = new FileWriter(filePath);
        }

        public void Log(string message)
        {
            fileWriter.WriteLine("[LOG] " + message);
        }

        public void Error(string message)
        {
            fileWriter.WriteLine("[ERROR] " + message);
        }

        public void Warn(string message)
        {
            fileWriter.WriteLine("[WARN] " + message);
        }
    }
}
