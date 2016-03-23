using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Security.Claims;
using System.Security.Principal;
using System.Web.Http.Owin;
using System.Web;
using Microsoft.AspNet.Identity;
using Obsidian.Models;

namespace Obsidian
{
    public static class IdentityExtensions
    {
        public static bool IsWinner { get; set; }
        public static bool IsPlayerOne { get; set; }
        public static string GetDisplayName(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("DisplayName");
            return (claim != null) ? claim.Value : string.Empty;
        }

        public static void SetDisplayName(this IIdentity identity, string NewName)
        {
            var Identity = new ClaimsIdentity(identity);
                Identity.RemoveClaim(Identity.FindFirst("DisplayName"));
                Identity.AddClaim(new Claim("DisplayName", NewName));
        }

        public static string GetCoins(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("Coins");
            return (claim != null) ? claim.Value : string.Empty;
        }

        public static void AddCoins(this IIdentity identity, int Amount)
        {
            var Identity = new ClaimsIdentity(identity);
            var TempClaim = ((ClaimsIdentity)identity).FindFirst("Coins");
            Identity.RemoveClaim(Identity.FindFirst("Coins"));
            Identity.AddClaim(new Claim("Coins", (int.Parse(TempClaim.Value) + Amount).ToString()));
        }

        public static void RemoveCoins(this IIdentity identity, int Amount)
        {
            var Identity = new ClaimsIdentity(identity);
            var TempClaim = ((ClaimsIdentity)identity).FindFirst("Coins");
            Identity.RemoveClaim(Identity.FindFirst("Coins"));
            Identity.AddClaim(new Claim("Coins", (int.Parse(TempClaim.Value) - Amount).ToString()));
        }

        public static string GetTeamName(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("TeamName");
            return (claim != null) ? claim.Value : string.Empty;
        }

        public static void SetTeamName(this IIdentity identity, string NewTeamName)
        {
            var Identity = new ClaimsIdentity(identity);
            Identity.RemoveClaim(Identity.FindFirst("TeamName"));
            Identity.AddClaim(new Claim("TeamName", NewTeamName));
        }

        public static string GetWins(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("Wins");
            return (claim != null) ? claim.Value : string.Empty;
        }

        public static void AddOneToWins(this IIdentity identity)
        {
            var Identity = new ClaimsIdentity(identity);
            var TempClaim = ((ClaimsIdentity)identity).FindFirst("Wins");
            Identity.RemoveClaim(Identity.FindFirst("TeamName"));
            Identity.AddClaim(new Claim("TeamName", (int.Parse(TempClaim.Value) + 1).ToString()));
        }

        public static string GetTotalMatches(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("TotalMatches");
            return (claim != null) ? claim.Value : string.Empty;
        }

        public static void AddOneToTotalMatches(this IIdentity identity)
        {
            var Identity = new ClaimsIdentity(identity);
            var TempClaim = ((ClaimsIdentity)identity).FindFirst("TotalMatches");
            Identity.RemoveClaim(Identity.FindFirst("TeamName"));
            Identity.AddClaim(new Claim("TeamName", (int.Parse(TempClaim.Value) + 1).ToString()));
        }

        public static string GetId(this IIdentity identity)
        {
            return identity.GetUserId();
        }
    }
}