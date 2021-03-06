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
    public class GetPageContactsHandler : IRequestHandler<GetPageContactRequest, GetPageContactResponse>
    {
        private readonly IDbContext _dbContext;

        public GetPageContactsHandler(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetPageContactResponse> Handle(GetPageContactRequest request,
            CancellationToken cancellationToken)
        {
            var includableQueryable = _dbContext.Contacts
                .OrderBy(x => x.User.Name)
                .Include(x => x.User);
            var query = includableQueryable.AsQueryable();

            var city = request.City?.Trim();
            if (!string.IsNullOrWhiteSpace(city))
            {
                query = query.Where(x => x.ContactInfo.City == city);
            }

            var search = request.Search;
            if (!string.IsNullOrWhiteSpace(search))
            {
                query = includableQueryable.ThenInclude(x => x.Tags)
                    .Include(x => x.ContactInfo)
                    .Where(x => x.Value.Contains(search))
                    .Where(x => x.User.Name.Contains(search))
                    .Where(x => x.ContactInfo.Country.Contains(search))
                    .Where(x => x.ContactInfo.Provider.Contains(search))
                    .Where(x => x.User.Tags.Any(x => x.Text.Contains(search)));
            }

            if (request.ContactType is { } contactType)
            {
                query = query.Where(x => x.ContactType == contactType);
            }

            var contacts = await query.Skip(request.Page * request.Page)
                .Take(request.Size)
                .ToListAsync(cancellationToken);

            var response = new GetPageContactResponse
            {
                Contacts = contacts.Select(x =>
                    new GetPageContactResponse.PageContact(x.Value, x.ContactType.ToString(), x.UserId, x.User?.Name))
            };
            return response;
        }
    }
}