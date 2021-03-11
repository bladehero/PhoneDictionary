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
    public class GetUserByIdHandler : IRequestHandler<GetUserByIdRequest, GetUserByIdResponse>
    {
        private readonly IDbContext _dbContext;

        public GetUserByIdHandler(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetUserByIdResponse> Handle(GetUserByIdRequest request, CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users
                .Include(x => x.Contacts)
                .ThenInclude(x => x.ContactInfo)
                .Include(x => x.Tags)
                .FirstOrDefaultAsync(x => x.Id == request.UserId, cancellationToken);
            if (user is null)
            {
                return null;
            }

            var response = new GetUserByIdResponse
            {
                UserName = user.Name,
                Contacts = user.Contacts.OrderBy(x=>x.ContactType).Select(x =>
                    new GetUserByIdResponse.UserContact(x.Id, x.Value, x.ContactType.ToString(), x.ContactInfo?.Id)),
                Tags = user.Tags.Select(x => new GetUserByIdResponse.UserTag(x.Id, x.Text, x.Color))
            };
            return response;
        }
    }
}