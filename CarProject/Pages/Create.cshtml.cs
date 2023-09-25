using CarProject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarProject.Models;
using Microsoft.EntityFrameworkCore;
using System.Web.Mvc;

namespace CarProject.Pages
{
    [IgnoreAntiforgeryToken]
    public class CreateModel : PageModel
    {
        ApplicationContext context;
        [BindProperty]
        public Car Auto { get; set; } = new();
        public Microsoft.AspNetCore.Mvc.Rendering.SelectList Brands { get; private set; }
        public List<CarModel> Models { get; private set; } = new();
        public List<CarColor> Colors { get; private set; } = new();
        public CreateModel(ApplicationContext db)
        {
            context = db;
        }
        public void OnGet()
        {
            Brands = new (context.Brands.AsNoTracking().ToList(), nameof(Brand.Id), nameof(Brand.Name));
        
            //Models = context.Models.AsNoTracking().ToList();
            //Colors = context.Colors.AsNoTracking().ToList();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            context.Cars.Add(Auto);
            await context.SaveChangesAsync();
            return RedirectToPage("Index");
        }

        public Microsoft.AspNetCore.Mvc.Rendering.SelectList GetModelsById(int id)
        {
            return new(context.Brands.Single(b => b.Id.Equals(id)).Models, nameof(CarModel.Id), nameof(CarModel.Name));
        }
    }
}