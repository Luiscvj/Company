namespace Core.Entities;

public class Role
{
    public int RoleId { get; set; }
    public string RoleName { get; set; }
    public ICollection<User> Users { get; set; } = new HashSet<User>();
    public ICollection<UserRoles>  UserRoles { get; set; }
}