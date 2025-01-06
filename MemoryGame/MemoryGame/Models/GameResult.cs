namespace MemoryGame.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GameResult
    {
        [Key]
        public int ResultID { get; set; }

        public int UserID { get; set; }

        public int PlayTime { get; set; }

        public DateTime? PlayDate { get; set; }

        public virtual User User { get; set; }
    }
}
