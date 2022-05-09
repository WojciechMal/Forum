using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Topic:Auditable
    {
        
        
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } 
        [Required]
        public string Description { get; set; } 
        //[Required]
        //public int SegmentId { get; set; }
        
        public int SegmentId { get; set; }
        [JsonIgnore]
        public Segment Segment { get; set; }
        public List<Comment> Comments { get; set; }
        
    }
}
