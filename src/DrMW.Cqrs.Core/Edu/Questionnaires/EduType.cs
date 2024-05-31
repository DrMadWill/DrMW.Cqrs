using DrMW.Cqrs.Core.Commons;

namespace DrMW.Cqrs.Core.Edu.Questionnaires;

public class EduType : Enumeration,IOriginEntity<int>
{
    public static EduType Main = new(1, "Əsas təhil");
    public static EduType Additional = new(2, "Əlavə təhil");
    public EduType(int id, string name) : base(id, name)
    {
    }
}