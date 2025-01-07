namespace Lab06.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("BOOKS")]
    public partial class BOOK
    {
        [StringLength(6)]
        public string BOOKID { get; set; }

        [Required]
        [StringLength(255)]
        public string BOOKNAME { get; set; }

        public int NAMXB { get; set; }

        public int? CATEGORYID { get; set; }

        public virtual CATEGORYBOOK CATEGORYBOOK { get; set; }
    }
}
