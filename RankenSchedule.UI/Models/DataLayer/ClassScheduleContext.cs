using Microsoft.EntityFrameworkCore;
using RankenSchedule.UI.Models.Configuration;
using RankenSchedule.UI.Models.DomainModels;

namespace RankenSchedule.UI.Models.DataLayer
{
    public class ClassScheduleContext:DbContext
    {
        public ClassScheduleContext(DbContextOptions<ClassScheduleContext>options)
            : base(options)
        {
                
        }
        public DbSet<Day> Days { get; set; } = null!;
        public DbSet<Teacher> Teachers { get; set; } = null!;
        public DbSet<Class> Classes { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Seed our Data
            modelBuilder.ApplyConfiguration(new DayConfig());
            modelBuilder.ApplyConfiguration(new TeacherConfig());
            modelBuilder.ApplyConfiguration(new ClassConfing());
        }
    }
}
