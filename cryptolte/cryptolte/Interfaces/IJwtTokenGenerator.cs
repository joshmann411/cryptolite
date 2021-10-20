using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace cryptolte.Interfaces
{
    public interface IJwtTokenGenerator
    {
        string generateToken(IdentityUser user);
        string generateToken(IdentityUser user, IList<string> roles);
        string generateToken(IdentityUser user, IList<string> roles, IList<Claim> claims);
    }
}
