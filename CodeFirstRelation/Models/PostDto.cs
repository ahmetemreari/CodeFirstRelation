namespace CodeFirstRelation.DTOs
{
    public class PostDto
    {
        //kullanıcıdan post adını ve içeriğin adını alıp hangi idli kullanıcaya atayacağını soruyoruz
        public string Title { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
    }
}