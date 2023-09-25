using CarProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace CarProject.Pages
{
    public class IndexModel : PageModel
    {
        ApplicationContext context;
        public List<Car> Cars { get; private set; } = new();
        public IndexModel(ApplicationContext db)
        {
            context = db;
        }
        public void OnGet()
        {
            Cars = context.Cars.AsNoTracking().ToList();
        }
        public async Task<IActionResult> OnPostDeleteAsync(int id)
        {
            var auto = await context.Cars.FindAsync(id);

            if (auto != null)
            {
                context.Cars.Remove(auto);
                await context.SaveChangesAsync();
            }

            return RedirectToPage();
        }

        public IActionResult OnPostUpdateAsync(int id)
        {
            return RedirectToPage("Update", new { id });
        }
    }
}
