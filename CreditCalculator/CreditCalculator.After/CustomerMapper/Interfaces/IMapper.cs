namespace CreditCalculator.After.CustomerMapper.Interfaces;

public interface IMapper<T> where T : class
{
   T Map( string firstName, string lastName, string email, DateTime dateOfBirth);
}