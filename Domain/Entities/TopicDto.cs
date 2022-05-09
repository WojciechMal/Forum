using Domain.Common;

namespace Domain.Entities
{
    public class TopicDto:Auditable
    {
        public int Id { get; set; } = 1;
        public string Name { get; set; } = "Topic";
        public string Description { get; set; } = "Opis";

        public int SegmentId { get; set; } = 1;

    }
}
