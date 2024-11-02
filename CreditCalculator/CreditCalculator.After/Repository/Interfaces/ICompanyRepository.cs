namespace CreditCalculator.After.Interfaces;

public interface ICompanyRepository
{
    Company GetById(int companyId);
}