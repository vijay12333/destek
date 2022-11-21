using GRAMPRO.Platform.Utility.Model;
using GRAMPRO.Platform.Utility.Model.General;
using GRAMPRO.Platform.Utility.Model.sample;
using GRAMPRO.Platform.Utility.Model.Operations;
//using GRAMPRO.Platform.Utility.Model.Recruitment;
using GRAMPRO.Platform.Utility.Model.Authentication;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace GRAMPRO.Platform.Utility.Repository
{
    public partial class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        private IConfigurationRoot _config;
        public ApplicationContext(DbContextOptions<ApplicationContext> options,
         IConfigurationRoot config)
        : base(options)
        {
            _config = config;
        }


        public DbSet<tblTicket> tblTicket { get; set; }
        public DbSet<tblCategory> tblCategory { get; set; }

        public DbSet<tblTeamMembers> tblTeamMembers { get; set; }

        public DbSet<tblSubCategory> tblSubCategory { get; set; }

        public DbSet<tblFindings> tblFindings { get; set; }

        public DbSet<tblPriority> tblPriority { get; set; }

        public DbSet<tblRole> tblRole { get; set; }

        public DbSet<tblStatus> tblStatus { get; set; }

        public DbSet<tblTeam> tblTeam { get; set; }

         public DbSet<tblClient> tblClient { get; set; }

         //public DbSet<TicketCount> TicketCount { get; set; }






        protected override void OnConfiguring(DbContextOptionsBuilder
        optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(_config["ConnectionStrings:DbConnection"]);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}