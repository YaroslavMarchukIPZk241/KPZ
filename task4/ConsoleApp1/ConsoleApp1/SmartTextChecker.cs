using System;
using System.Collections.Generic;
public class SmartTextChecker : ITextReader
{
    private SmartTextReader _reader = new SmartTextReader();

    public List<List<char>> ReadTextFile(string filePath)
    {
        Console.WriteLine($"[INFO] Opening file: {filePath}");

        List<List<char>> content = _reader.ReadTextFile(filePath);

        Console.WriteLine("[INFO] File read successfully.");
        Console.WriteLine($"[INFO] Total lines: {content.Count}");

        int totalChars = 0;
        foreach (var line in content)
        {
            totalChars += line.Count;
        }
        Console.WriteLine($"[INFO] Total characters: {totalChars}");

        Console.WriteLine("[INFO] File closed.");
        return content;
    }
}
