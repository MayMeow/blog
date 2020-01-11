using System.Threading.Tasks;
using MayMeow.Blog.Data;
using MayMeow.Blog.Entities.Taxonomy;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MayMeow.Blog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class LabelsController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public LabelsController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public async Task<IActionResult> Index()
        {
            var model = await _dbContext.Labels.ToListAsync();
            return View(model);
        }
        
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _dbContext.Labels
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
        public async Task<IActionResult> Create([Bind("Name,Description,Color")] Label label)
        {
            if (!ModelState.IsValid) return View(label);
            
            _dbContext.Add(label);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}