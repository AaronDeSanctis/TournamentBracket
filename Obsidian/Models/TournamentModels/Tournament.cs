using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Obsidian.Models.TournamentModels
{
    public class Tournament
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Bracket { get; set; }
        public string Game { get; set; }
        public string Genre { get; set; }
        public bool? IsCompleted { get; set; }
        public virtual ICollection<Match> Matches { get; set; }
    }
}