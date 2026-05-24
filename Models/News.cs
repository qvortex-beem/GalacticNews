using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GalacticNews.Models
{
    [Table("news")]
    public class News
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("date")]
        public DateTime? Date { get; set; }

        [Column("title")]
        public string Title { get; set; } = string.Empty;

        [Column("announce")]
        public string? Announce { get; set; }

        [Column("content")]
        public string? Content { get; set; }

        [Column("image")]
        public string Image { get; set; } = string.Empty;
    }
}