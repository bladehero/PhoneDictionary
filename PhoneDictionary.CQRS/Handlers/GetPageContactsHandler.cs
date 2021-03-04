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

        public async Task<GetPageContactResponse> Handle(GetPageContactRequest request, CancellationToken cancellationToken)
        {
            var contacts = await _dbContext.Contacts
                .Include(x => x.User)
                .OrderBy(x => x.User.Name)
                .Skip(request.Page * request.Page)
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