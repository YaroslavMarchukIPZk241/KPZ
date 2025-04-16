using ConsoleApp1;
using System;

class Program
{
    static async Task Main()
    {
        string[] bookLines = await DownloadBookLinesAsync();
        var factory = new HtmlElementFactory();

        long before = MemoryUtil.GetMemoryUsage();
        string html = LightHTMLParser.ConvertToHTML(bookLines, factory);
        long after = MemoryUtil.GetMemoryUsage();

        Console.WriteLine(html);
        Console.WriteLine($"\nUsed {factory.Count} flyweight elements.");
        Console.WriteLine($"Memory usage: {after - before} bytes");
    }

    static async Task<string[]> DownloadBookLinesAsync()
    {
        using HttpClient client = new HttpClient();
        string url = "https://www.gutenberg.org/cache/epub/1513/pg1513.txt";
        string content = await client.GetStringAsync(url);
        return content.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
    }

}

