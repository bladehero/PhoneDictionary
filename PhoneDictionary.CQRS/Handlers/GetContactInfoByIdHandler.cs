using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PhoneDictionary.CQRS.Requests.Queries;
using PhoneDictionary.CQRS.Responses.Queries;
using PhoneDictionary.Interfaces;

namespace PhoneDictionary.CQRS.Handlers
{
    public class GetContactInfoByIdByIdHandler : IRequestHandler<GetContactInfoByIdRequest, GetContactInfoByIdResponse>
    {
        private readonly IDbContext _dbContext;

        public GetContactInfoByIdByIdHandler(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetContactInfoByIdResponse> Handle(GetContactInfoByIdRequest request,
            CancellationToken cancellationToken)
        {
            var contactInfo = await _dbContext.ContactInfos
                .Include(x => x.Contact)
                .ThenInclude(x => x.User)
                .FirstOrDefaultAsync(x => x.ContactId == request.ContactInfoId, cancellationToken);
            if (contactInfo is null)
            {
                return null;
            }

            var response = new GetContactInfoByIdResponse
            {
                City = contactInfo.City,
                Contact = contactInfo.Contact.Value,
                Country = contactInfo.Country,
                Provider = contactInfo.Provider,
                UserName = contactInfo.Contact.User.Name,
                UserId = contactInfo.Contact.UserId
            };
            return response;
        }
    }
}