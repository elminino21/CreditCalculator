namespace CreditCalculator.After.Interfaces;

public interface ILogger
{
    void Error(string message);
    void Information(string message); 
}