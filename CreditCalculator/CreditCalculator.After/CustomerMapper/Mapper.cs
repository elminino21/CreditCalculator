using CreditCalculator.After.CustomerMapper.Interfaces;

namespace CreditCalculator.After.CustomerMapper;

public class Mapper: IMapper<Customer>
{
    public Customer Map( string firstName, string lastName, string email, DateTime dateOfBirth)
    {
        return new Customer
        {
            DateOfBirth = dateOfBirth,
            EmailAddress = email,
            FirstName = firstName,
            LastName = lastName
        };
    }
}