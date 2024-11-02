using CreditCalculator.After.Interfaces;

namespace CreditCalculator.After;

public class CustomerRepository: ICustomerRepository
{
    private readonly List<Customer> _customers = [];

    public List<Customer> GetCustomers() => _customers.ToList();

    public void AddCustomer(Customer customer)
    {
        _customers.Add(customer);
    }
}