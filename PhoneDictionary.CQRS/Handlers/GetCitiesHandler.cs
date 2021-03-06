using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PhoneDictionary.CQRS.Requests.Queries;
using PhoneDictionary.CQRS.Responses.Queries;
using PhoneDictionary.Interfaces;

namespace PhoneDictionary.CQRS.Handlers
{
    public class GetCitiesHandler : IRequestHandler<GetCitiesRequest, GetCitiesResponse>
    {
        private readonly IDbContext _dbContext;

        public GetCitiesHandler(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetCitiesResponse> Handle(GetCitiesRequest request, CancellationToken cancellationToken)
        {
            var query = _dbContext.ContactInfos
                .Select(x => x.City);

            var city = request.City;
            if (!string.IsNullOrWhiteSpace(city))
            {
                query = query.Where(x => x.Contains(city));
            }

            var cities = await query.Distinct().ToListAsync(cancellationToken);

            var response = new GetCitiesResponse
            {
                Cities = cities.OrderBy(x => x)
            };
            return response;
        }
    }
}