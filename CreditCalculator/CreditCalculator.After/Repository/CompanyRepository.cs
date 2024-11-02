using CreditCalculator.After.Interfaces;

namespace CreditCalculator.After;

public class CompanyRepository: ICompanyRepository
{
    private readonly List<Company> _companies = new()
    {
        Company.RegularClient,
        Company.ImportantClient,
        Company.VeryImportantClient
    };

    public Company GetById(int companyId)
    {
        return _companies.Single(c => c.Id == companyId);
    }
}