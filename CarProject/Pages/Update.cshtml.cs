using CarProject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CarProject.Models;

namespace CarProject.Pages
{
    [IgnoreAntiforgeryToken]
    public class UpdateModel : PageModel
    {
        ApplicationContext context;
        [BindProperty]
        public Car? Auto { get; set; }

        public UpdateModel(ApplicationContext db)
        {
            context = db;
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Auto = await context.Cars.FindAsync(id);

            if (Auto == null) return NotFound();

            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            context.Cars.Update(Auto!);
            await context.SaveChangesAsync();
            return RedirectToPage("Index");
        }
    }
}