using CreditCalculator.After.Validator;

namespace CreditCalculator.After;

public class DateTimeProxy : ICurrentDate
{
    // I have run into the issue where this causes many problem when deploying micro services and testing
    // Now I can use MOQ to set the time as I need
    public DateTime GetCurrentDate() => DateTime.Now;
}