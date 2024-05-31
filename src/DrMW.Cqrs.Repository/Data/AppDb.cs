using DrMW.Cqrs.Core.Edu;
using DrMW.Cqrs.Core.Edu.Questionnaires;
using DrMW.Cqrs.Core.Students;
using Microsoft.EntityFrameworkCore;

namespace DrMW.Cqrs.Repository.Data;

public class AppDb : DbContext
{
    
    #region Students
    public DbSet<Student> Students { get; set; }
    //public DbSet<Detail> StudentDetails { get; set; }
    public DbSet<Status> StudentStatus { get; set; } 
    #endregion
   
    #region Edu

    #region Quest

    public DbSet<EduLevel> EducationLevels { get; set; }
    public DbSet<EduType> EducationTypes { get; set; }

    #endregion
    
    public DbSet<Group> Groups { get; set; }
    public DbSet<GroupSubject> GroupSubjects { get; set; }
    public DbSet<Subject> Subjects { get; set; } 

    #endregion
    

    public AppDb(DbContextOptions<AppDb> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Student>()
            .HasOne(s => s.Group)
            .WithMany(s => s.Students)
            .HasForeignKey(s => s.GroupId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Student>()
            .HasOne(s => s.Detail)
            .WithOne(s => s.Student)
            .HasForeignKey<Detail>(s => s.Id)
            .OnDelete(DeleteBehavior.Restrict);


        modelBuilder.Entity<GroupSubject>()
            .HasIndex(s => new { s.GroupId, s.SubjectId })
            .HasFilter("[Deleted] = 0")
            .IsUnique();
            
        
        modelBuilder.ApplyDbSeedData();
    }
}