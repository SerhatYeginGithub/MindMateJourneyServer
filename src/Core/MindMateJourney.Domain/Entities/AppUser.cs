using Microsoft.AspNetCore.Identity;

namespace MindMateJourney.Domain.Entities;

public sealed class AppUser : IdentityUser<string>
{
    public AppUser()
    {
        Id = Guid.NewGuid().ToString();
    }

    public string NameLastName { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime? RefreshTokenExpires { get; set; }
}
