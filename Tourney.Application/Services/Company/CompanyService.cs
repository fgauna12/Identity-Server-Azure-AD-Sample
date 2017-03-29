using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Tourney.Infrastructure.Dtos;

namespace Tourney.Application.Services.Company
{
    public interface ICompanyService
    {
        Task<PagedResponse<Domain.Company>> GetCompaniesAsync(PagedRequest pagedRequest);
    }

    public class CompanyService : ICompanyService
    {
        public Task<PagedResponse<Domain.Company>> GetCompaniesAsync(PagedRequest pagedRequest)
        {
            var faker = new Faker<Domain.Company>()
                .RuleFor(x => x.Id, opt => opt.UniqueIndex.ToString())
                .RuleFor(x => x.Name, opt => opt.Company.CompanyName())
                .RuleFor(x => x.Description, opt => opt.Company.CatchPhrase());
            var results = faker.Generate(25).ToList();
            var response = new PagedResponse<Domain.Company>()
            {
                Results = results,
                Total = results.Count
            };
            return Task.FromResult(response);
        }
    }
}