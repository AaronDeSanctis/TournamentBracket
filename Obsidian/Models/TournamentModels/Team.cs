using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Obsidian.Models.TournamentModels
{
    public class Team
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Wins { get; set; }
        public int MatchTotal { get; set; }
        public string Prefix { get; set; }
        public int Losses
        {
            get
            {
                return MatchTotal - Wins;
            }
        }
        public string WinRatio
        {
            get
            {
                return ((Wins / Losses).ToString() + "%");
            }
        }
        public virtual ICollection<Match> Matches { get; set; }
        public virtual ICollection<Member> Members { get; set; }
    }
}