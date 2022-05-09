using Domain.Common;

namespace Domain.Entities
{
    public class CommentDto:Auditable
    {
        public int Id { get; set; } = 1;
        public string Text { get; set; } = "Komentarz";
        public int TopicId { get; set; } = 1;
    }
}
