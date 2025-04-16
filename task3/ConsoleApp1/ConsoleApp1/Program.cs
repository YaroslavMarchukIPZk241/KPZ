using System;
using System.Threading;
using System.Threading.Tasks;
class Program
{
    sealed class Authenticator 
{
    private static Authenticator _instance;
    private static readonly object _lock = new object(); 
    public string Link { get; private set; }

    private Authenticator(string link)
    {
        Link = link;
        Console.WriteLine($"Authenticator created with link: {Link}");
    }

    public static Authenticator GetInstance(string link)
    {
        if (_instance == null)
        {
            lock (_lock) 
            {
                if (_instance == null)
                {
                    _instance = new Authenticator(link);
                }
            }
        }
        return _instance;
    }
}

    static void Main()
    {
        Parallel.For(0, 5, i =>
        {
            var instance = Authenticator.GetInstance("https://link" + i + ".com");
            Console.WriteLine($"[{i}] Link: {instance.Link}");
        });
        var a1 = Authenticator.GetInstance("https://first.com");
        var a2 = Authenticator.GetInstance("https://second.com");
        Console.WriteLine($"Are a1 and a2 same instance? {object.ReferenceEquals(a1, a2)}");
    }
}