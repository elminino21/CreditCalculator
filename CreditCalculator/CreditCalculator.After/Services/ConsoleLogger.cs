using CreditCalculator.After.Interfaces;

namespace CreditCalculator.After;

// simple decorator. I made to work like ASP logger Logger inface decorator
public class ConsoleLogger: ILogger
{
    public void Error(string message)
    {
        Console.WriteLine( "ERROR:" +message);
    }

    public void Information(string message)
    {
        Console.WriteLine( "INFOMARTION:" + message);
    }
}