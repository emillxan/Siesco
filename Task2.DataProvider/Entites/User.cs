namespace Task2.DataProvider.Entites;

public class User
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string PasswordHash { get; set; } 
    public int RoleId { get; set; }
    public Role Role { get; set; }
}

