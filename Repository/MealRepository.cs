using daily_diet.Data;
using daily_diet.Dto;
using daily_diet.Interfaces;
using daily_diet.Models;
using System.Diagnostics;

namespace daily_diet.Repository
{
    public class MealRepository : IMealRepository
    {
        private readonly DataContext _context;

        public MealRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreateMeal(MealDto meal)
        {
            var user = _context.Users.Where(u => u.Id == meal.userId).FirstOrDefault();

            var mealRecord = new Meal()
            { 
                Description = meal.description, 
                IsOnTheDiet = meal.isOnTheDiet, 
                Name = meal.name,
                user = user,
                date = meal.date
            };

            _context.Add(mealRecord);
            return Save();
        }

        public ICollection<Meal> GetAllByUserId(int userId)
        {
            return _context.Meals.Where(m => m.user.Id == userId).ToList();
        }

        public Meal GetById(int id)
        {
            return _context.Meals.Where(m => m.Id == id).FirstOrDefault();
        }

        public Meal GetByName(string name)
        {
            
            return _context.Meals.Where(m => m.Name.Trim().ToUpper() == name.Trim().ToUpper()).FirstOrDefault();
        }

        public int GetUserTotalMealsOffDiet(int userId)
        {
            return _context.Meals.Where(m => m.IsOnTheDiet == false).Count();
        }

        public int GetUserTotalMealsOnDiet(int userId)
        {
            return _context.Meals.Where(m => m.user.Id == userId && m.IsOnTheDiet == true).Count();
        }

        public int GetUserTotalMealsRegistered(int userId)
        {
            return _context.Meals.Where(m => m.user.Id == userId).Count();
        }

        public bool UpdateMeal(int userId, string description, string name, bool isOnTheDiet)
        {
            var meal = GetById(userId);

            meal.Description = description;
            meal.Name = name;
            meal.IsOnTheDiet = isOnTheDiet;

            return Save();
        }

        public bool DeleteMeal(int mealId)
        {
            var meal = GetById(mealId);
            _context.Meals.Remove(meal);
            
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
