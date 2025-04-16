using System;
using System.Collections.Generic;
using System.IO;

public class SmartTextReader : ITextReader
{
    public List<List<char>> ReadTextFile(string filePath)
    {
        var result = new List<List<char>>();

        using (var reader = new StreamReader(filePath))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                var charList = new List<char>(line);
                result.Add(charList);
            }
        }

        return result;
    }
}