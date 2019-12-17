namespace ConferencePlanner.Data
{
    using Entities;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Session> Sessions { get; set; }

        public DbSet<Track> Tracks { get; set; }

        public DbSet<Speaker> Speakers { get; set; }

        public DbSet<SessionSpeaker> SessionSpeaker { get; set; }

        public DbSet<Attendee> Attendees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Unique UserName Attendee
            // Ex1 - todo
            modelBuilder.Entity<Attendee>(a => a.HasIndex(e => e.UserName).IsUnique());

            // Many-to-many: Session <-> Attendee
//            modelBuilder.Entity<SessionAttendee>()
//                .HasOne(sa => sa.Session)
//                .WithMany(x => x.SessionAttendees)
//                .HasForeignKey(x => x.Session);
//
//            modelBuilder.Entity<SessionAttendee>()
//                .HasOne(sa => sa.Attendee)
//                .WithMany(x => x.SessionsAttendees)
//                .HasForeignKey(x => x.Attendee);

            modelBuilder.Entity<SessionAttendee>()
                .HasKey(ss => new { ss.SessionId, ss.AttendeeId });

            // Many-to-many: Speaker <-> Session
            modelBuilder.Entity<SessionSpeaker>()
                .HasKey(ss => new { ss.SessionId, ss.SpeakerId });
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.; Integrated Security=True; Initial Catalog=ConferencePlanner;");
            }
        }
    }
}