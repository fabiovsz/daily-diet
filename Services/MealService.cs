using daily_diet.Interfaces;
using daily_diet.Interfaces.Services;
using daily_diet.Repository;

namespace daily_diet.Services
{
    public class MealService : IMealService
    {
        private readonly IMealRepository _mealRepository;

        public MealService(IMealRepository mealRepository)
        {  
            _mealRepository = mealRepository; 
        }


        public int GetBestSequenceInDiet(int userId)
        {
            int sequence = 0;
            int bestSequence = 0;

            var userMeals = _mealRepository.GetAllByUserId(userId);
            foreach (var meal in userMeals)
            {
                if (meal.IsOnTheDiet == true)
                {
                    sequence++;
                }
                else
                    sequence = 0;

                if (sequence > bestSequence)
                    bestSequence = sequence;

                
            }

            return bestSequence;
        }

    }
}
