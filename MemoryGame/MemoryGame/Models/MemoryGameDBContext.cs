using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace MemoryGame.Models
{
    public partial class MemoryGameDBContext : DbContext
    {
        public MemoryGameDBContext()
            : base("name=MemoryGameDBContext")
        {
        }

        public virtual DbSet<GameResult> GameResults { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasMany(e => e.GameResults)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);
        }
    }
}
