using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyChords.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using EasyChords.Core.Models.Identity;

namespace EasyChords.Data
{
    public class EasyChordsDbContext: IdentityDbContext <User, Role, Guid>
    {
        public EasyChordsDbContext(DbContextOptions<EasyChordsDbContext> options): base(options)
        {
            Database.EnsureCreated();
        }
		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
            builder.Entity<Comment>().HasOne(p => p.Sender).WithMany(p => p.Comments).OnDelete(DeleteBehavior.NoAction);
		}
        public DbSet<Chords> Chords { get; set; }
        public DbSet<Comment> Comments { get; set; }
        //public DbSet<User> Users { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Performer> Performers { get; set; }
        public DbSet<Song> Songs { get; set; }
    }
}
