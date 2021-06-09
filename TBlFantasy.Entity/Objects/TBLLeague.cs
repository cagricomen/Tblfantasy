using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TBlFantasy.Entity
{
    [Table("League")]
    public class TBLLeague
    {
        [Key]
        public Guid ligId { get; set; }
        public Guid LeagueId { get; set; }
        public Guid TeamId { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
    }
}