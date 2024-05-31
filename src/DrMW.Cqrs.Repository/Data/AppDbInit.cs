using DrMW.Cqrs.Core.Commons;
using DrMW.Cqrs.Core.Edu.Questionnaires;
using DrMW.Cqrs.Core.Students;
using Microsoft.EntityFrameworkCore;

namespace DrMW.Cqrs.Repository.Data;

public static class AppDbInit
{

    public static void ApplyDbSeedData(this ModelBuilder builder)
    {

        builder.Entity<EduLevel>()
            .HasData(Enumeration.GetAll<EduLevel>());
        
        builder.Entity<EduType>()
            .HasData(Enumeration.GetAll<EduType>());
        
        builder.Entity<Status>()
            .HasData(Enumeration.GetAll<Status>());
    }

}