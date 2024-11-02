namespace CreditCalculator.After.Interfaces;

public interface ICustomerCreditServiceClient
{
    decimal GetCreditLimit(string firstName, string lastName, DateTime dateOfBirth);
}