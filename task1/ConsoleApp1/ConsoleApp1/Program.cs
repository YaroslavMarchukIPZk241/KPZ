using ConsoleApp1;
using System;

class Program
{
    static void Main(string[] args)
    {
     
        var consoleLogger = new Logger();
        consoleLogger.Log("Систему запущено");
        consoleLogger.Warn("Низький рівень батареї");
        consoleLogger.Error("Фатальна помилка");

        ILogger fileLogger = new FileLoggerAdapter("log.txt");
        fileLogger.Log("Систему запущено");
        fileLogger.Warn("Низький рівень батареї");
        fileLogger.Error("Фатальна помилка");

        Console.WriteLine("Логування завершено. Перевірте файл log.txt");
    }
}