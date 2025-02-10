using Microsoft.AspNetCore.Mvc;
using DiscussionForum.Data; 
using DiscussionForum.Models; 
using System.Linq;

namespace DiscussionForum.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController(ApplicationDbContext context)
        {
            _context = context; // Injects the database context
        }

        // GET: Retrieves discussions ordered by their creation date, including comment counts
        public IActionResult Index()
        {
            var discussions = _context.Discussions
                .OrderByDescending(d => d.CreateDate)
                .Select(d => new
                {
                    d.DiscussionId,
                    d.Title,
                    d.CreateDate,
                    d.ImageFileName,
                    CommentCount = _context.Comments.Count(c => c.DiscussionId == d.DiscussionId)
                })
                .ToList();

            return View(discussions);
        }

        // GET: Fetches a specific discussion by its ID, returning a 404 if not found
        public IActionResult GetDiscussion(int id)
        {
            var discussion = _context.Discussions
                .FirstOrDefault(d => d.DiscussionId == id);

            if (discussion == null)
            {
                return NotFound();
            }

            return View(discussion);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}