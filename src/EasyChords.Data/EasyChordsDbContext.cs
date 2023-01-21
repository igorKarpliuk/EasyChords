using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyChords.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace EasyChords.Data
{
    public class EasyChordsDbContext: DbContext
    {
        public EasyChordsDbContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
        public DbSet<Chords> Chords { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Performer> Performers { get; set; }
        public DbSet<Song> Songs { get; set; }
    }
}
