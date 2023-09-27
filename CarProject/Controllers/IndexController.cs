using CarProject.Models;
using CarProject.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CarProject.Controllers
{
    public class IndexController : Controller
    {
        ApplicationContext context;
        private IndexModel Model { get; set; }
        public IndexController(ApplicationContext db)
        {
            context = db;
        }
        public IActionResult Index()
        {

            ViewData["MyData"] = context.Cars.Include(car => car.Brand)
                               .Include(car => car.Model)
                               .Include(car => car.Color)
                               .AsNoTracking().ToList();
            return View();
        }
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var auto = await context.Cars.FindAsync(id);

            if (auto != null)
            {
                context.Cars.Remove(auto);
                await context.SaveChangesAsync();
            }

            return RedirectToPage("Index");
        }

        public IActionResult OnPostUpdateAsync(int id)
        {
            return RedirectToPage("Update", new { id });
        }

    }
}
