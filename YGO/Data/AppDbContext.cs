using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YGO.Models;

namespace YGO.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor_Movie>().HasKey(item => new
            {
                item.ActorId,
                item.MovieId
            });

            modelBuilder.Entity<Actor_Movie>().HasOne(item => item.Movie)
                .WithMany(item => item.Actors_Movies)
                .HasForeignKey(item => item.MovieId);
            modelBuilder.Entity<Actor_Movie>().HasOne(item => item.Actor)
                .WithMany(item => item.Actors_Movies)
                .HasForeignKey(item => item.ActorId);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }

        public DbSet<Actor_Movie> Actors_Movies { get; set; }
    }
}
