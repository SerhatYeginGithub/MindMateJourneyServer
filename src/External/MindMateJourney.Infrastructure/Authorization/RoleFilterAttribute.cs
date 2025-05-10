using Microsoft.AspNetCore.Mvc;

namespace MindMateJourney.Infrastructure.Authorization;

public sealed class RoleFilterAttribute : TypeFilterAttribute
{
    public RoleFilterAttribute(string role) : base(typeof(RoleAttribute))
    {
        Arguments = new object[] { role };
    }
}