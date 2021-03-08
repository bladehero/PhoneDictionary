using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PhoneDictionary.CQRS.Requests.Queries;
using PhoneDictionary.CQRS.Responses.Queries;
using PhoneDictionary.Extensions;
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
                .Include(x => x.User);
            var query = includableQueryable.AsQueryable();

            var cities = request.Cities?.Where(x => !string.IsNullOrWhiteSpace(x)).ToList();
            if (cities?.Any() == true)
            {
                query = query.Where(x => cities.Contains(x.ContactInfo.City));
            }

            var search = request.Search;
            if (!string.IsNullOrWhiteSpace(search))
            {
                query = includableQueryable.ThenInclude(x => x.Tags)
                    .Include(x => x.ContactInfo)
                    .Where(x => x.Value.Contains(search)
                                || x.Value.Replace("(", string.Empty)
                                    .Replace(")", string.Empty)
                                    .Replace(" ", string.Empty)
                                    .Replace("-", string.Empty)
                                    .Contains(search)
                                || x.User.Name.Contains(search)
                                || x.ContactInfo.Country.Contains(search)
                                || x.ContactInfo.Provider.Contains(search)
                                || x.User.Tags.Any(tag => tag.Text.Contains(search)));
            }

            var contactTypes = request.ContactTypes?.ToList();
            if (contactTypes?.Any() == true)
            {
                query = query.Where(x => contactTypes.Contains(x.ContactType));
            }

            var contacts = await query.OrderBy(x => x.Id)
                .Skip(request.Page * request.Size)
                .Take(request.Size)
                .ToListAsync(cancellationToken);

            var records = await query.CountAsync(cancellationToken);
            var pages = (int) Math.Ceiling(records / (double) request.Size);

            var response = new GetPageContactResponse
            {
                Contacts = contacts
                    .Select(x =>
                        new GetPageContactResponse.PageContact(x.Id, x.Value, x.ContactType.GetDescription(), x.UserId,
                            x.User?.Name))
                    .OrderBy(x => x.UserName),
                Pages = pages,
                Records = records
            };
            return response;
        }
    }
}