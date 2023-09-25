using Microsoft.EntityFrameworkCore;

namespace CarProject.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<CarModel> Models { get; set; } 
    }
}