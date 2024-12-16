using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirstRelation.Models
{
    public class Post
    {
        // Primary id
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }

        // Navigation Property
        //
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}