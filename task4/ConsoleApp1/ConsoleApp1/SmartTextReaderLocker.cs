using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class SmartTextReaderLocker : ITextReader
{
    private SmartTextReader _reader = new SmartTextReader();
    private Regex _deniedPattern;

    public SmartTextReaderLocker(string pattern)
    {
        _deniedPattern = new Regex(pattern, RegexOptions.IgnoreCase);
    }

    public List<List<char>> ReadTextFile(string filePath)
    {
        if (_deniedPattern.IsMatch(filePath))
        {
            Console.WriteLine("[ACCESS DENIED] Access to this file is restricted.");
            return new List<List<char>>();
        }

        return _reader.ReadTextFile(filePath);
    }
}
