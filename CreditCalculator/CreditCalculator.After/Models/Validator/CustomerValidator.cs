namespace CreditCalculator.After.Validator;

public class CustomerValidator: IValidate<Customer>
{
    private readonly ICurrentDate _currentDate;
    public CustomerValidator( ICurrentDate currentDate )
    {
        _currentDate = currentDate;
    }
    
    public CustomerValidator(): this(new DateTimeProxy()){}
    public bool Validate(Customer customer)
    {
       return ValidateCustomer(customer.FirstName, customer.LastName, customer.EmailAddress, customer.DateOfBirth ); 
    }
    private  bool ValidateCustomer(string firstName, string lastName, string email, DateTime dateOfBirth)
    {
        const int minimumAge = 21;

        return !string.IsNullOrEmpty(firstName) &&
               !string.IsNullOrEmpty(lastName) &&
               email.Contains('@') &&
               email.Contains('.') &&
               CalculateAge(dateOfBirth, DateTime.Now) >= minimumAge;
    } 
    
    private  int CalculateAge(DateTime dateOfBirth, DateTime now)
    {
        var age = _currentDate.GetCurrentDate().Year - dateOfBirth.Year;
        if (dateOfBirth.Date > now.AddYears(-age))
        {
            age--;
        }

        return age;
    }

}