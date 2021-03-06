using System.ComponentModel.DataAnnotations;
using MediatR;
using PhoneDictionary.CQRS.Responses.Commands;

namespace PhoneDictionary.CQRS.Requests.Commands
{
    public class AssignTagToUserRequest : IRequest<AssignTagToUserResponse>
    {
        public int UserId { get; set; }
        [MaxLength(20)] public string Tag { get; set; }

        [RegularExpression("^#([A-Fa-f0-9]{6})$")]
        public string Color { get; set; }
    }
}