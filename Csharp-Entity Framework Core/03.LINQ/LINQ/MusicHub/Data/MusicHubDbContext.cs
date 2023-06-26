using Microsoft.EntityFrameworkCore;
using MusicHub.Data.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MusicHub.Data
{
    public class MusicHubDbContext : DbContext
    {
        public MusicHubDbContext()
        {

        }
        public MusicHubDbContext(DbContextOptions options)
          : base(options)
        {

        }
        public virtual DbSet<Song> Songs { get; set; } = null!;
        public virtual DbSet<Album> Albums { get; set; } = null!;
        public virtual DbSet<Performer> Performers { get; set; } = null!;
        public virtual DbSet<Producer> Producers { get; set; } = null!;
        public virtual DbSet<Writer> Writers { get; set; } = null!;
        public virtual DbSet<SongPerformer> SongsPerformers { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SongPerformer>(enitity =>
            {
                enitity.HasKey(x => new { x.SongId, x.PerformerId });
            });
        }

    }
}
