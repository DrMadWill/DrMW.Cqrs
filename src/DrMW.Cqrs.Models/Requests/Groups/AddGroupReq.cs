namespace DrMW.Cqrs.Models.Requests.Groups;

public class AddGroupReq
{
    public string Name { get; set; }
    public int LevelId { get; set; } 
    public int EduTypeId { get; set; }
    public List<int>? StudentsIds { get; set; }
    public List<int>? SubjectsIds { get; set; }
}