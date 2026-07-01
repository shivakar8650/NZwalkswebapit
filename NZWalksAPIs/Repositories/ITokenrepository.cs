using Microsoft.AspNetCore.Identity;
using System.Runtime.InteropServices;

namespace NZWalksAPIs.Repositories
{
    public interface ITokenrepository
    {
        string CreateJWTToken(IdentityUser User, List<string> roles);
    }
}   
