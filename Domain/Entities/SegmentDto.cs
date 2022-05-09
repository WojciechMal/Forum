using Domain.Common;

namespace Domain.Entities
{
    public class SegmentDto:Auditable
    {
        public int Id { get; set; } = 1;
        public string Name { get; set; } = "Segment";
        public string Description { get; set; } = "Opis";
        
    }
}
