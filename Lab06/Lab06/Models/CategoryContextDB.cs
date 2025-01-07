using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Lab06.Models
{
    public partial class CategoryContextDB : DbContext
    {
        public CategoryContextDB()
            : base("name=CategoryContextDB")
        {
        }

        public virtual DbSet<BOOK> BOOKS { get; set; }
        public virtual DbSet<CATEGORYBOOK> CATEGORYBOOKs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BOOK>()
                .Property(e => e.BOOKID)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
