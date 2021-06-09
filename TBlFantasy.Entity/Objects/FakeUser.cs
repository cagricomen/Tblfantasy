using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TBlFantasy.Entity
{
    [Table("FakeUser")]
    public class FakeUser
    {
        [Key]
        public Guid FakeId { get; set; }
        public string Name { get; set; }
        public string TeamName { get; set; }
    }
}