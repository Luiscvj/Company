using Microsoft.AspNetCore.Identity;

namespace Core.Entities;

public class User
{
    public int UserId { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public ICollection<Role>  Roles  { get; set; } = new HashSet<Role>();
    public ICollection<UserRoles> UserRoles { get; set; }
    
}