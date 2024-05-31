using DrMW.Cqrs.Models.Dtos.Common;

namespace DrMW.Cqrs.Models.Dtos.Edu;

public class SubjectDto : BaseDto<Guid>
{
    public BaseCategory? Level { get; set; }
    public int LevelId { get; set; }
}