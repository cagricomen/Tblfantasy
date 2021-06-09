using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TBlFantasy.Entity
{
    [Table("Team")]
    public class TBLTeam
    {
        [Key]
        public Guid TeamId { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int GamesPlayed { get; set; }
        public int Win { get; set; }
        public int Lose { get; set; }
        public int Points { get; set; }
        public decimal FantasyScore { get; set; }
    }
}