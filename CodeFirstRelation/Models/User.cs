namespace CodeFirstRelation.Models;
public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }

    // Navigation Property
    public ICollection<Post> Posts { get; set; }
}