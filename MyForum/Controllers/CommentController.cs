using Domain.Entities;
using Infrastructure.Persistance;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyForum.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private AppDbContext _context;
        public CommentController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public List<Comment> Get()
        {
            return _context.Comments.ToList();
        }
        [HttpGet("{id}")]
        public List<Comment> GetCommentsToTopic(int id)
        {
            return _context.Comments.Where(c => c.TopicId == id).ToList();
        }
        [HttpGet("{id}")]
        public Comment GetCommentsById(int id)
        {
            return _context.Comments.Find(id);
        }
        [HttpPost]
        public void AddComment(CommentDto com)
        {
            Topic topic = (Topic)_context.Topics.Where(s => s.Id == com.TopicId).FirstOrDefault();
            var newComment = new Comment
            {
                Text = com.Text,
                TopicId = topic.Id
            };
            _context.Comments.Add(newComment);
            _context.SaveChanges();
        }
        [HttpPut]
        public void UpdateComment(CommentDto request)
        {
            var comment = _context.Comments.Find(request.Id);
            comment.Text = request.Text;
            _context.SaveChanges();
        }
        [HttpDelete("{id}")]
        public void DeleteComment(int id)
        {
            Comment? com = _context.Comments.Find(id);

            _context.Comments.Remove(com);
            _context.SaveChanges();
        }
    }
}
