using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace FLIPGAME.Entities
{
    public partial class FlipGameDBContext : DbContext
    {
        public FlipGameDBContext()
            : base("name=FlipGameDBContext")
        {
        }

        public virtual DbSet<Score> Scores { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
