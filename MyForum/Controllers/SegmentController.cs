using Domain.Entities;
using Infrastructure.Persistance;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace MyForum.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SegmentController : ControllerBase
    {
        private AppDbContext _context;
        public SegmentController(AppDbContext context)
        {
            _context = context;
        }
        //private static List<Segment> segments = new List<Segment>
        //    {
        //        new Segment {
        //            Id = 1,
        //            Name = "Atramenty",
        //            Description = "Dział dotyczący atramentów"
        //        },
        //        new Segment {
        //            Id = 2,
        //            Name = "Pióra wieczne",
        //            Description = "Dział dotyczący piór wiecznych"
        //        }
        //    };


        //[HttpGet]
        //public async Task<ActionResult<List<Segment>>> Get() /*Task<IActionResult> Get()*/
        //{
        //    return Ok(segments);
        //}



        //[HttpGet("{id}")]
        //public async Task<ActionResult<Segment>> Get(int id) 
        //{
        //    //var segment = segments[id];
        //    var segment = segments.Find(x => x.Id == id);
        //    if (segment == null)
        //    {
        //        return BadRequest("Segment not found"); 
        //    }
        //    return Ok(segment);
        //}
        //[HttpPut]
        //public async Task<ActionResult<List<Segment>>> UpdateSegment(Segment request)
        //{
        //    var segment = segments.Find(x => x.Id == request.Id);
        //    if (segment == null)
        //    {
        //        return BadRequest("Segment not found");
        //    }

        //    segment.Name = request.Name;
        //    segment.Description = request.Description;

        //    return Ok(segments);
        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult<List<Segment>>> DeleteSegment(int id)
        //{
        //    var segment = segments.Find(x => x.Id == id);
        //    if (segment == null)
        //    {
        //        return BadRequest("Segment not found");
        //    }

        //    segments.Remove(segment);
        //    return Ok(segments);
        //}

        [HttpGet]
        public List<Segment> GetSegments()
        {
            List<Segment> segments = new List<Segment>();
            foreach (Segment sgm in _context.Segments)
            {
                sgm.Topics = _context.Topics.Where(t => t.SegmentId == sgm.Id).ToList();
                foreach (Topic top in sgm.Topics)
                {
                    top.Comments = _context.Comments.Where(c => c.TopicId == top.Id).ToList();
                }
                segments.Add(sgm);
            }
            
            return segments;
        }

        [HttpGet("{id}")]
        public Segment? GetSegment(int id)
        {
            Segment? segment = _context.Segments.Find(id);
            segment.Topics = _context.Topics.Where(t => t.SegmentId == segment.Id).ToList();
            foreach (Topic top in segment.Topics)
            {
                top.Comments = _context.Comments.Where(c => c.TopicId == top.Id).ToList();
            }
            return segment;
        }

        [HttpPost]
        public void AddSegment(SegmentDto segm)
        {
            var Segment = new Segment
            {
                Name = segm.Name,
                Description = segm.Description
            };
            _context.Segments.Add(Segment);
            _context.SaveChanges();
        }
        [HttpPut]
        public void UpdateSegment(SegmentDto request)
        {
            var segment = _context.Segments.Find(request.Id);
            
            segment.Name = request.Name;
            segment.Description = request.Description;

            _context.SaveChanges();
        }
        [HttpDelete("{id}")]
        public void DeleteSegment(int id)
        {
            Segment? seg = _context.Segments.Find(id);
            _context.Segments.Remove(seg);
            _context.SaveChanges();
        }

    }
}
