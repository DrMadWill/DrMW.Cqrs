namespace DrMW.Cqrs.Models.Requests.Subjects;

public class UpdateSubjectReq : AddSubjectReq
{
    public Guid Id { get; set; }
}