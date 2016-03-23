using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Obsidian.Models.TournamentModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Obsidian.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        private const int DefaultCoins = 1000;
        private const string DefaultName = "User";
        private const string DefaultTeamName = "Unaffiliated";
        private const int DefaultWins = 0;
        private const int DefaultTotalMatches = 0;

        [Required]
        [Display(Name = "Display Name")]
        [DefaultValue(DefaultName)]
        public string DisplayName { get; set; }

        [Display(Name = "Coins")]
        [DefaultValue(DefaultCoins)]
        public int Coins { get; set; }

        [Required]
        [Display(Name = "Team Name")]
        [DefaultValue(DefaultTeamName)]
        public string TeamName { get; set; }

        [Display(Name = "Total Tournament Match Wins")]
        [DefaultValue(DefaultWins)]
        public int Wins { get; set; }

        [Display(Name = "Total Tournament Matches")]
        [DefaultValue(DefaultTotalMatches)]
        public int TotalMatches { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            userIdentity.AddClaim(new Claim("DisplayName", this.DisplayName));
            userIdentity.AddClaim(new Claim("Coins", this.Coins.ToString()));
            userIdentity.AddClaim(new Claim("TeamName", this.TeamName));
            userIdentity.AddClaim(new Claim("Wins", this.Wins.ToString()));
            userIdentity.AddClaim(new Claim("TotalMatches", this.TotalMatches.ToString()));
            // Add custom user claims here
            return userIdentity;
        }

    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Member> Members { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }


        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>()
                    .HasRequired(m => m.TeamOne)
                    .WithMany()
                    .HasForeignKey(m => m.TeamOneId)
                    .WillCascadeOnDelete(false);

            modelBuilder.Entity<Match>()
                        .HasRequired(m => m.TeamTwo)
                        .WithMany()
                        .HasForeignKey(m => m.TeamTwoId)
                        .WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);
        }
    }
}