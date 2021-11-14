using System;
using System.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace Loopr.audioDB
{
    public partial class AudioContext : DbContext
    {
        public AudioContext()
        {
        }

        public AudioContext(DbContextOptions<AudioContext> options, IConfiguration config)
            : base(options)
        {
            ConnString = config.GetConnectionString("devDB");
        }

        public string ConnString { get; set;  }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<Track> Tracks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySQL(ConnString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Session>(entity =>
            {
                entity.ToTable("session");

                entity.Property(e => e.SessionId).HasColumnName("sessionId");

                entity.Property(e => e.SessionDate).HasColumnName("sessionDate");

                entity.Property(e => e.SessionName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("sessionName");
            });

            modelBuilder.Entity<Track>(entity =>
            {
                entity.ToTable("track");

                entity.HasIndex(e => e.SessionId, "FK_TRACK_SESSION_idx");

                entity.Property(e => e.TrackId).HasColumnName("trackId");

                entity.Property(e => e.SessionId).HasColumnName("sessionId");

                entity.Property(e => e.TrackName)
                    .IsRequired()
                    .HasMaxLength(255)
                    .HasColumnName("trackName");

                entity.HasOne(d => d.Session)
                    .WithMany(p => p.Tracks)
                    .HasForeignKey(d => d.SessionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TRACK_SESSION");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
