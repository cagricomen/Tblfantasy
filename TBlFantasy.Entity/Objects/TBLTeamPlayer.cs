using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TBlFantasy.Entity
{
    [Table("TeamPlayer")]
    public class TBLTeamPlayer
    {
        [Key]
        public Guid tpId { get; set; }
        public Guid TeamId { get; set; }
        public Guid BasketballerId { get; set; }
        public int TeamNumber { get; set; }
    }
}