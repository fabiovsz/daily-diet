using daily_diet.Dto;
using daily_diet.Interfaces;
using daily_diet.Interfaces.Services;
using daily_diet.Models;
using Microsoft.AspNetCore.Mvc;

namespace daily_diet.Controllers
{
    [Route("api/meal")]
    [ApiController]
    public class MealController : Controller
    {
        private readonly IMealRepository _mealRepository;
        private readonly IMealService _mealService;

        public MealController(IMealRepository mealRepository, IMealService mealService)
        {
            _mealRepository = mealRepository;
            _mealService = mealService;
        }

        [HttpPost()]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateMeal([FromBody] MealDto mealCreate)
        {
            if (mealCreate == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createMeal = _mealRepository.CreateMeal(mealCreate);

            if (!createMeal)
            {
                ModelState.AddModelError("", "Something went wrong while saving");
                return StatusCode(500, ModelState);
            }

            return Ok("Meal created!");
        }

        [HttpGet("{mealId}")]
        [ProducesResponseType(200, Type = typeof(Meal))]
        public IActionResult GetMeal(int mealId)
        {
            var meal = _mealRepository.GetById(mealId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(meal);
        }

        [HttpGet("get-all/{userId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Meal>))]
        public IActionResult GetUserMeals(int userId)
        {
            var meals = _mealRepository.GetAllByUserId(userId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(meals);
        }

        [HttpGet("total/{userId}")]
        [ProducesResponseType(200, Type = typeof(int))]
        public IActionResult GetUserTotalMeals(int userId)
        {
            var mealsCount = _mealRepository.GetUserTotalMealsRegistered(userId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(mealsCount);
        }

        [HttpGet("total-on-diet/{userId}")]
        [ProducesResponseType(200, Type = typeof(int))]
        public IActionResult GetUserTotalMealsOnDiet(int userId)
        {
            var mealsCount = _mealRepository.GetUserTotalMealsOnDiet(userId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(mealsCount);
        }

        [HttpGet("total-off-diet/{userId}")]
        [ProducesResponseType(200, Type = typeof(int))]
        public IActionResult GetUserTotalMealsOffDiet(int userId)
        {
            var mealsCount = _mealRepository.GetUserTotalMealsOffDiet(userId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(mealsCount);
        }

        [HttpGet("best-sequence/{userId}")]
        [ProducesResponseType(200, Type = typeof(int))]
        public IActionResult GetBestSequenceInDiet(int userId)
        {
            var mealsCount = _mealService.GetBestSequenceInDiet(userId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(mealsCount);
        }

        [HttpPut()]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult UpdateMeal([FromBody] MealDto mealUpdate)
        {
            if (mealUpdate == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updateMeal = _mealRepository.UpdateMeal(mealUpdate.userId, mealUpdate.description, mealUpdate.name, mealUpdate.isOnTheDiet);

            if (!updateMeal)
            {
                ModelState.AddModelError("", "Something went wrong while updating");
                return StatusCode(500, ModelState);
            }

            return Ok("Meal updated!");
        }

        [HttpDelete("{mealId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult DeleteMeal(int mealId)
        {
            if (mealId == null)
                return BadRequest(ModelState);

            var deleteMeal = _mealRepository.DeleteMeal(mealId);
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!deleteMeal)
            {
                ModelState.AddModelError("", "Something went wrong while deleting");
                return StatusCode(500, ModelState);
            }

            return Ok("Meal deleted!");
        }
    }
}