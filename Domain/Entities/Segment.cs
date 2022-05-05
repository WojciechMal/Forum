using Domain.Common;

namespace Domain.Entities
{
    public class Segment:Auditable
    {
        
        public int Id { get; set; }
        public string? Name { get; set; } = string.Empty;
        public string? Description { get; set; } = string.Empty;
        public List<Topic>? Topics { get; set; } = new List<Topic>();
    }
}
