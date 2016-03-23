using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Obsidian.Models.TournamentModels
{
    public class Member
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Team")]
        public int TeamId { get; set; }
        public virtual Team Team { get; set; }

        public string Name { get; set; }
        public int Coins { get; set; }

        public void AddCoins(int CoinAmount)
        {
            Coins += CoinAmount;
        }

        public void RemoveCoins(int CoinAmount)
        {
            Coins -= CoinAmount;
        }
    }
}