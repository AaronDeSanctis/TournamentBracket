using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Obsidian.Models.TournamentModels
{
    public class Match
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("TeamOne")]
        public int TeamOneId { get; set; }
        public virtual Team TeamOne { get; set; }

        [ForeignKey("TeamTwo")]
        public int TeamTwoId { get; set; }
        public virtual Team TeamTwo { get; set; }


        [ForeignKey("Tournament")]
        public int TournamentId { get; set; }
        public virtual Tournament Tournament { get; set; }

        public string VideoFile { get; set; }
        public bool? TeamOneIsWinner { get; set; }
        public bool? TeamTwoIsWinner { get; set; }
        public bool? IsLosersFinals { get; set; }
        public bool? IsWinnersFinals { get; set; }
        public bool? IsGrandFinals { get; set; }
    }
}