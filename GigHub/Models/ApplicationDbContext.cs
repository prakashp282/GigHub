using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace GigHub.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        //EF will know about Gig class - domain model
        //EF will know about genres through gig as gig has a reference to it 
        public DbSet<Gig> Gigs { get; set; }

        //to query genres 
        public DbSet<Genre> Genres { get; set; }

        //to query attendances
        public  DbSet<Attendance> Attendances { get; set; }

        public DbSet<Following> Followings { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        //overrding OnModelCreating to turn off and avoid cascade deleting 
        //where one request to delete comes from user to attendee
        // and the other request goes from user to gig the attendee
        //overriding default convention using modelBuilder obj to supply additional configuration
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //turning off cascade delete with Fluent API
            modelBuilder.Entity<Attendance>()  
                .HasRequired(a => a.Gig) //each attendance has a required gig
                .WithMany() // reverse direction
                .WillCascadeOnDelete(false);

            //an app user has many followers and each follower has required followee
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.Followers)
                .WithRequired(f => f.Followee)
                .WillCascadeOnDelete(false);


            //has many followees and has req follower
            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.Followee)
                .WithRequired(f => f.Follower)
                .WillCascadeOnDelete(false);

            base.OnModelCreating(modelBuilder);
        }
    }
}