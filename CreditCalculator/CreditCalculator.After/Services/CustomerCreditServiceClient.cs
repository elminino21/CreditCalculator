using CreditCalculator.After.Interfaces;

namespace CreditCalculator.After;

public class CustomerCreditServiceClient: ICustomerCreditServiceClient
{
    private readonly ILogger _logger;

    public CustomerCreditServiceClient( ILogger logger)
    {
        _logger = logger;
    }

    public CustomerCreditServiceClient():this( new ConsoleLogger() ) { }
    public decimal GetCreditLimit(string firstName, string lastName, DateTime dateOfBirth)
    {
        _logger.Information($"Starting to get creditlimit for {firstName} {lastName} with date {dateOfBirth}");
        if (firstName == "John" && lastName == "Doe")
        {
            return 500.0m;
        }

        if (DateTime.Now.Year - dateOfBirth.Year > 40)
        {
            return 600.0m;
        }

        _logger.Information($"Succeessfully to got creditlimit for {firstName} {lastName} with date {dateOfBirth}");
        return 249.9m;
    }
}