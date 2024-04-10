using Bogus;
using PontoAPI.Core.Entities;

namespace PontoAPI.Infrastructure.Test.Faker
{
    public static class CompanyFaker
    {

        public static Company GerarCompanyFake()
        {
            var companyFaker = new Faker<Company>()
                .RuleFor(p => p.Id, f => f.Random.Guid())
                .RuleFor(p => p.Name, f => f.Name.FirstName(Bogus.DataSets.Name.Gender.Male))
                .RuleFor(p => p.Address, f => f.Address.StreetAddress())
                .RuleFor(p => p.Telephone, f => f.Person.Phone)
                .Generate();

            return companyFaker;

        }

        public static List<Company> GerarListaCompanyFake()
        {
            var companyFaker = new Faker<Company>()
                .RuleFor(p => p.Id, f => f.Random.Guid())
                .RuleFor(p => p.Name, f => f.Name.FirstName(Bogus.DataSets.Name.Gender.Male))
                .RuleFor(p => p.Address, f => f.Address.StreetAddress())
                .RuleFor(p => p.Telephone, f => f.Person.Phone)
                .Generate(10);

            return companyFaker;

        }
    }
}