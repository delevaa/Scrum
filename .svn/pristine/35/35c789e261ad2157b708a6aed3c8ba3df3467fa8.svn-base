using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using ScrumProject.Models.Mapping;

namespace ScrumProject.Models
{
    public partial class SMRPO6Context : DbContext
    {
        static SMRPO6Context()
        {
            Database.SetInitializer<SMRPO6Context>(null);
        }

        public SMRPO6Context()
            : base("Name=SMRPO6Context")
        {
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Project_User> Project_User { get; set; }
        public DbSet<Sprint> Sprints { get; set; }
        public DbSet<Story> Stories { get; set; }
        public DbSet<sysdiagram> sysdiagrams { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Members> Members { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CarMap());
            modelBuilder.Configurations.Add(new ProjectMap());
            modelBuilder.Configurations.Add(new Project_UserMap());
            modelBuilder.Configurations.Add(new SprintMap());
            modelBuilder.Configurations.Add(new StoryMap());
            modelBuilder.Configurations.Add(new sysdiagramMap());
            modelBuilder.Configurations.Add(new UserMap());
           
        }
    }
}
