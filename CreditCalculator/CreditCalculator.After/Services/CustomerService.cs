using System.Reflection.Metadata;
using CreditCalculator.After.CustomerMapper;
using CreditCalculator.After.CustomerMapper.Interfaces;
using CreditCalculator.After.Interfaces;
using CreditCalculator.After.Validator;

namespace CreditCalculator.After;
/// <summary>
/// Main services reworked be more testable, extendable and recieiently 
/// </summary>
public class CustomerService{
    private readonly ICompanyRepository _companyRepository;
    private readonly ICustomerRepository _customerRepository;
    private readonly CreditLimitCalculator _creditLimitCalculator;
    private readonly IValidate<Customer> _validator;
    private readonly IMapper<Customer> _mapper;
    private readonly ILogger _logger;

    public CustomerService  (ICompanyRepository companyRepository, ICustomerRepository customerRepository, 
        CreditLimitCalculator creditLimitCalculator,  IValidate<Customer> validate, IMapper<Customer> mapper,
        ILogger logger
        )
    {
        _companyRepository = companyRepository;
        _customerRepository = customerRepository;
        _creditLimitCalculator = creditLimitCalculator;
        _validator = validate;
        _mapper = mapper;
        _logger = logger;
    }
    public CustomerService(): this(new CompanyRepository(), new CustomerRepository(), 
        new CreditLimitCalculator(new CustomerCreditServiceClient()), new CustomerValidator(), new Mapper(), new ConsoleLogger()    ){}
    public bool AddCustomer(string firstName, string lastName, string email, DateTime dateOfBirth, int companyId)
    {
        _logger.Information($"Stating to add new customer with Name: {firstName} {lastName} email: {email} and Date of Birth: {dateOfBirth}");
        var customer = _mapper.Map(firstName, lastName, email, dateOfBirth); 
        if (!_validator.Validate( customer))
        {
            _logger.Information($"Failed to add new customer with Name: {firstName} {lastName} email: {email} and Date of Birth: {dateOfBirth}");
            return false;
        }

        try
        {
            customer.Company = _companyRepository.GetById(companyId);
        }
        catch (Exception exception)
        {
            _logger.Error(exception.Message);
            _logger.Information($"Failed to add new customer with Name: {firstName} {lastName} email: {email} and Date of Birth: {dateOfBirth}");
            return false;
        }

        (customer.HasCreditLimit, customer.CreditLimit) = _creditLimitCalculator.Calculate(customer.Company, customer);

        if (customer.IsUnderCreditLimit())
        {
            _logger.Information($"Failed to add new customer with Name: {firstName} {lastName} email: {email} and Date of Birth: {dateOfBirth}");
            return false;
        }

        _customerRepository.AddCustomer(customer);
        _logger.Information($"Successfully to added new customer with Name: {firstName} {lastName} email: {email} and Date of Birth: {dateOfBirth}");

        return true;
    }

    

    
}