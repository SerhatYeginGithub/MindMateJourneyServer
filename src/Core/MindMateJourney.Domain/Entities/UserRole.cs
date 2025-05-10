using MindMateJourney.Domain.Abstraction;
using System.ComponentModel.DataAnnotations.Schema;

namespace MindMateJourney.Domain.Entities;

public sealed class UserRole : Entity
{
    [ForeignKey("AppUser")]
    public string UserId { get; set; }
    public AppUser User { get; set; }

    [ForeignKey("Role")]
    public string RoleId { get; set; }
    public Role Role { get; set; }
}
