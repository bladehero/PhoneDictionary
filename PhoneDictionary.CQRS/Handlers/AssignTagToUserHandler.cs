using System.Threading;
using System.Threading.Tasks;
using Bogus;
using MediatR;
using PhoneDictionary.CQRS.Requests.Commands;
using PhoneDictionary.CQRS.Responses.Commands;
using PhoneDictionary.Data.Models;
using PhoneDictionary.Interfaces;

namespace PhoneDictionary.CQRS.Handlers
{
    public class AssignTagToUserHandler : IRequestHandler<AssignTagToUserRequest, AssignTagToUserResponse>
    {
        private readonly IDbContext _dbContext;

        public AssignTagToUserHandler(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AssignTagToUserResponse> Handle(AssignTagToUserRequest request,
            CancellationToken cancellationToken)
        {
            var tag = new Tag
            {
                Text = request.Tag,
                Color = request.Color ?? new Faker().Internet.Color(),
                UserId = request.UserId
            };
            await _dbContext.Tags.AddAsync(tag, cancellationToken);
            _dbContext.SaveChanges();

            var response = new AssignTagToUserResponse
            {
                TagId = tag.Id
            };
            return response;
        }
    }
}