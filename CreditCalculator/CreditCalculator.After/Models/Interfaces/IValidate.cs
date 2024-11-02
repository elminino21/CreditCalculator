namespace CreditCalculator.After.Validator;

public interface IValidate<T>
{
   bool Validate(T obj); 
}