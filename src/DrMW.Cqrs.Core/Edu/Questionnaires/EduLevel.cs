using DrMW.Cqrs.Core.Commons;

namespace DrMW.Cqrs.Core.Edu.Questionnaires;

public class EduLevel : Enumeration,IOriginEntity<int>
{
    public static EduLevel Bachelor = new(1, "Bakalavır");
    public static EduLevel Master = new(2, "Master");
    
    public EduLevel(int id, string name) : base(id, name)
    {
    }
}