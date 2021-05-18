using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ChinookMusicCompany.Models;

namespace ChinookMusicCompany.Data
{
    public class ShopContext : DbContext
    {
        public ShopContext (DbContextOptions<ShopContext> options)
            : base(options)
        {
        }

        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<MediaType> MediaTypes { get; set; }
        public DbSet<Genre> Genres { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Album>().ToTable("albums");
            modelBuilder.Entity<Artist>().ToTable("artists");
            modelBuilder.Entity<Track>().ToTable("tracks");
            modelBuilder.Entity<MediaType>().ToTable("media_types");
            modelBuilder.Entity<Genre>().ToTable("genres");
        }
    }
}
