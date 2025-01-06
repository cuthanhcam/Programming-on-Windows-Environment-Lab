namespace FLIPGAME.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Score
    {
        public int ScoreID { get; set; }

        public int? UserID { get; set; }

        public int TimeTaken { get; set; }

        public DateTime? GameDate { get; set; }

        public virtual User User { get; set; }
    }
}
