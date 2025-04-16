using System;
using System.Collections.Generic;
using System.Text;
public interface ITextReader
{
    List<List<char>> ReadTextFile(string filePath);
}
class Program
    {    
        static void Main(string[] args)
        {
            string allowedFile = "test.txt";
            string deniedFile = "secret.txt";

            Console.WriteLine("\n--- Using SmartTextChecker ---");
            ITextReader checker = new SmartTextChecker();
            checker.ReadTextFile(allowedFile);

            Console.WriteLine("\n--- Using SmartTextReaderLocker (allowing only .txt files except secret.txt) ---");
            ITextReader locker = new SmartTextReaderLocker(@"secret\.txt$");
            locker.ReadTextFile(allowedFile);   
            locker.ReadTextFile(deniedFile);    
        }
    }
