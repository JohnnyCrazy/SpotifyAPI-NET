using System.Linq;
using System.Security.Claims;

namespace SpotifyAPI.Web.Examples.ASP
{
    public static class ClaimsExtensions
    {
        public static string GetSpecificClaim(this ClaimsIdentity claimsIdentity, string claimType)
        {
            Claim claim = claimsIdentity.Claims.FirstOrDefault(x => x.Type == claimType);

            return claim != null ? claim.Value : string.Empty;
        }
    }
}