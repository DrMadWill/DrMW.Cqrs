using AutoMapper;
using DrMW.Cqrs.Core.Edu;
using DrMW.Cqrs.Core.Edu.Questionnaires;
using DrMW.Cqrs.Core.Students;
using DrMW.Cqrs.Models.Dtos;
using DrMW.Cqrs.Models.Dtos.Common;
using DrMW.Cqrs.Models.Dtos.Edu;
using DrMW.Cqrs.Models.Requests.Groups;
using DrMW.Cqrs.Models.Requests.Subjects;
using DrMW.Cqrs.Service.Features.Command.Students.Add;
using DrMW.Cqrs.Service.Features.Command.Students.Update;

namespace DrMW.Cqrs.Service.Mappers;

public class DrMWMapper : Profile
{
    public DrMWMapper()
    {
        CreateMap<EduLevel, BaseDto<int>>()
            .ReverseMap();
        CreateMap<EduLevel, BaseCategory>()
            .ReverseMap();
        CreateMap<EduType, BaseCategory>()
            .ReverseMap();
        CreateMap<Status, BaseCategory>()
            .ReverseMap();
        
        #region Student

        CreateMap<Student, StudentDto>()
            .ReverseMap();
        CreateMap<Student, AddStudentReq>()
            .ReverseMap();
        CreateMap<Student, UpdateStudentReq>()
            .ReverseMap();
        CreateMap<Detail, StudentDetailDto>()
            .ReverseMap();

        #endregion

        #region Group

        CreateMap<Group, GroupDto>()
            .ReverseMap();
        CreateMap<Group, AddGroupReq>()
            .ReverseMap();
        CreateMap<Group, UpdateGroupReq>()
            .ReverseMap();

        #endregion

        #region Subject

        CreateMap<Subject, SubjectDto>()
            .ReverseMap();
        CreateMap<Subject, AddSubjectReq>()
            .ReverseMap();
        CreateMap<Subject, UpdateSubjectReq>()
            .ReverseMap(); 

        #endregion

    }
}