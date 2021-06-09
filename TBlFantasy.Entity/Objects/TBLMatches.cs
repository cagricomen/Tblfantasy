using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TBlFantasy.Entity
{
    [Table("Matches")]
    public class TBLMatches
    {
        [Key]
        public Guid MatchId { get; set; }
        public Guid UserId { get; set; }
        public Guid FakeId { get; set; }
        public string UserTeam { get; set; }
        public string FakeTeam { get; set; }
        public string Week { get; set; }
        public int Weeks { get; set; }
        public int UserScore { get; set; }
        public int FakeScore { get; set; }
        public string Winner { get; set; }
    }
}