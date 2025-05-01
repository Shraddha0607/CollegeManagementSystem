using Microsoft.AspNetCore.Identity;

namespace CollegeApp.Repositories;

public interface ITokenRepo
{
    string CreateJwtToken(IdentityUser user, List<string> roles);
}
