using Microsoft.AspNetCore.Identity;

namespace MindMateJourney.Domain.Entities;

public sealed class AppUser : IdentityUser<string>
{
    public AppUser()
    {
        Id = Guid.NewGuid().ToString();
    }

    public string NameLastName { get; set; }
}
