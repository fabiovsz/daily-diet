using System.ComponentModel.DataAnnotations;

namespace daily_diet.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public ICollection<Meal> Meals { get; set; }
    }
}
