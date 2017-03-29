using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Tourney.Infrastructure.Dtos;

namespace Tourney.Application.Services.Facility
{
    public interface IFacilityService
    {
        Task<PagedResponse<Domain.Facility>> GetFacilitiesAsync();
    }

    public class FacilityService : IFacilityService
    {
        public Task<PagedResponse<Domain.Facility>> GetFacilitiesAsync()
        {
            var faker = new Faker<Domain.Facility>()
                .RuleFor(x => x.Name, opt => "Facility " + opt.Address.BuildingNumber())
                .RuleFor(x => x.AddressLine1, opt => opt.Address.StreetAddress())
                .RuleFor(x => x.AddressLine2, opt => opt.Address.SecondaryAddress())
                .RuleFor(x => x.City, opt => opt.Address.City())
                .RuleFor(x => x.State, opt => opt.Address.State())
                .RuleFor(x => x.ZipCode, opt => opt.Address.ZipCode());

            var results = faker.Generate(25).ToList();
            return Task.FromResult(new PagedResponse<Domain.Facility>()
            {
                Results = results,
                Total = results.Count
            });
        }
    }
}