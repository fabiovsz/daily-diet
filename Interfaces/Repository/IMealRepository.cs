using daily_diet.Dto;
using daily_diet.Models;

namespace daily_diet.Interfaces
{
    public interface IMealRepository
    {
        Meal GetById(int mealId);
        Meal GetByName(string name);
        ICollection<Meal> GetAllByUserId(int userId);
        int GetUserTotalMealsRegistered(int userId);
        int GetUserTotalMealsOnDiet(int userId);
        int GetUserTotalMealsOffDiet(int userId);
        bool UpdateMeal(int userId, string description, string name, bool isOnTheDiet);
        bool DeleteMeal(int mealId);
        bool CreateMeal(MealDto meal);
        bool Save();
    }
}
