using System.Threading.Tasks;
using MayMeow.Blog.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MayMeow.Blog.Web.Controllers
{
    public class NodesController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public NodesController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET
        public IActionResult Index()
        {
            return View();
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
    }
}