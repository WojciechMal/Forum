using Domain.Common;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class Comment:Auditable
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int TopicId { get; set; }
        [JsonIgnore]
        public Topic Topic { get; set; }
    }
}
