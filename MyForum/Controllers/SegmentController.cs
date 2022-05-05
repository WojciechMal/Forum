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
            return _context.Segments.ToList();
        }

        [HttpGet("{id}")]
        public Segment? GetSegment(int id)
        {
            return _context.Segments.Find(id);
        }

        [HttpPost]
        public void AddSegment(Segment segm)
        {
            _context.Segments.Add(segm);
            _context.SaveChanges();
        }

        [HttpPut]
        public void UpdateSegment(Segment request)
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
