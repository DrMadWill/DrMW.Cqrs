
namespace DrMW.Cqrs.Models.Requests.Groups;

public class UpdateGroupReq : AddGroupReq
{
    public Guid Id { get; set; }
}