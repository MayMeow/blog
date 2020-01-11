using System;
using System.Threading.Tasks;
using MayMeow.Blog.Data;
using MayMeow.Blog.Entities.Content;
using MayMeow.Blog.Entities.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MayMeow.Blog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class NodesController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public NodesController(ApplicationDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var model = await _dbContext.Nodes.ToListAsync();
            return View(model);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var model = await _dbContext.Nodes
                .Include(m => m.Author)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (model == null)
            {
                return NotFound();
            }
            
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title", "Body")] Node node)
        {
            var date = DateTime.UtcNow;
            if (!ModelState.IsValid) return View(node);
            
            var user = await _userManager.GetUserAsync(User);
            node.AuthorId = user.Id;
            node.CreatedAt = date;
            node.ModifiedAt = date;

            _dbContext.Add(node);
            await _dbContext.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}