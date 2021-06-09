using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TBlFantasy.Entity
{
    [Table("Basketballer")]
    public class TBLBasketballer
    {
        [Key]
        public Guid BasketballerId { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }
        public int Assists { get; set; }
        public int Rebounds { get; set; }
        public int Blocks { get; set; }
        public int Steals { get; set; }
        public int Turnovers { get; set; }
        public int Fauls { get; set; }
        public int Height { get; set; }
        public int Age { get; set; }
        public int No { get; set; }
        public string TwoPointShot { get; set; }
        public string ThreePointShot { get; set; }
        public string freeThrown { get; set; }
        public string Position { get; set; }
        public string Matchtime { get; set; }
        public int MatchesPlayed { get; set; }
        public string TotalTime { get; set; }
        public decimal AveragePoints { get; set; }
        public decimal AverageAssists { get; set; }
        public decimal AverageRebounds{ get; set; }
        public decimal FantasyScore { get; set; }
        public decimal PirValue { get; set; }
    }
}