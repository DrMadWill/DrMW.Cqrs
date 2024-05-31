using DrMW.Cqrs.Core.Commons;

namespace DrMW.Cqrs.Core.Students;

public class Status : Enumeration
{
    public static Status Studying = new(1, "Təhsil alır");
    public static Status Finished = new(2, "Bitirib");
    public static Status Expelled = new(3, "Xaric olub");
    public Status(int id, string name) : base(id, name)
    {
    }
}