using Microsoft.AspNetCore.Identity;

namespace MindMateJourney.Domain.Entities;


public sealed class Role : IdentityRole<string>
{
    public Role()
    {
        Id = Guid.NewGuid().ToString();
    }
}
