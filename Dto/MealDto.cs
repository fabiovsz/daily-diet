namespace daily_diet.Dto
{
    public class MealDto
    {
        public string name { get; set; }
        public int userId { get; set; }
        public string description { get; set; }
        public bool isOnTheDiet { get; set; }
        public DateTime date { get; set; }  
    }
}
