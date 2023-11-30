using System.ComponentModel.DataAnnotations;

namespace daily_diet.Models
{
    public class Meal
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public bool IsOnTheDiet { get; set; }
        [Required]
        public DateTime date { get; set; }
        public User user { get; set; }
    }
}
