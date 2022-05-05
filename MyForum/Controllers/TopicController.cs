using Domain.Entities;
using Infrastructure.Persistance;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyForum.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private AppDbContext _context;
        public TopicController(AppDbContext context)
        {
            _context = context;
        }
        //private static List<Topic> topics = new List<Topic>
        //    {
        //       new Topic {
        //            Id = 1,
        //            Name = "Diamine",
        //            Description = "Temat o atramentach marki Diamine",
        //            SegmentId = 1
        //        },
        //        new Topic {
        //            Id = 2,
        //            Name = "Herbin",
        //            Description = "Temat o atramentach marki Herbin",
        //            SegmentId = 1
        //        },
        //        new Topic {
        //            Id = 3,
        //            Name = "KWZ",
        //            Description = "Temat o atramentach marki KWZ",
        //            SegmentId = 1
        //        },
        //        new Topic {
        //            Id = 4,
        //            Name = "LAMY",
        //            Description = "Temat o piórach marki LAMY",
        //            SegmentId = 2
        //        },
        //        new Topic {
        //            Id = 5,
        //            Name = "Kaweco",
        //            Description = "Temat o piórach marki Kaweco",
        //            SegmentId = 2
        //        }
        //};
        //[HttpGet]
        //public async Task<ActionResult<List<Topic>>> Get() /*Task<IActionResult> Get()*/
        //{


        //    return Ok(topics);
        //}
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Topic>> Get(int id)
        //{
        //    //var segment = segments[id];
        //    var topic = topics.Find(x => x.Id == id);
        //    if (topic == null)
        //    {
        //        return BadRequest("Topic not found");
        //    }
        //    return Ok(topic);
        //}
        //[HttpPost]
        //public async Task<ActionResult<List<Topic>>> AddTopic(Topic top)
        //{
        //    topics.Add(top);
        //    return Ok(topics);
        //}

        //[HttpPut]
        //public async Task<ActionResult<List<Topic>>> UpdateTopic(Topic request)
        //{
        //    var topic = topics.Find(x => x.Id == request.Id);
        //    if (topic == null)
        //    {
        //        return BadRequest("Topic not found");
        //    }

        //    topic.Name = request.Name;
        //    topic.Description = request.Description;

        //    return Ok(topics);
        //}

        //[HttpDelete("{id}")]
        //public async Task<ActionResult<List<Topic>>> DeleteTopic(int id)
        //{
        //    var topic = topics.Find(x => x.Id == id);
        //    if (topic == null)
        //    {
        //        return BadRequest("Segment not found");
        //    }

        //    topics.Remove(topic);
        //    return Ok(topics);
        //}


        [HttpGet]
        public List<Topic> GetTopics()
        {
            return _context.Topics.ToList();
        }

        [HttpGet("{id}")]
        public Topic? GetTopic(int id)
        {
            return _context.Topics.Find(id);
        }

        [HttpPost]
        public void AddTopic(Topic top)
        {
            _context.Topics.Add(top);
            _context.SaveChanges();
        }

        [HttpPut]
        public void UpdateTopic(Topic request)
        {
            var topic = _context.Topics.Find(request.Id);

            topic.Name = request.Name;
            topic.Description = request.Description;

            _context.SaveChanges();
        }



        [HttpDelete("{id}")]
        public void DeleteTopic(int id)
        {
            Topic? top = _context.Topics.Find(id);
            _context.Topics.Remove(top);
            _context.SaveChanges();
        }

    };
}

