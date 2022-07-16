namespace life_manager_backend.Models
{
    public class FoodPortionForCreationDto
    {
        public string FoodId { get; set; }
        public int WeightInGrams { get; set; }
        public string DateConsumed { get; set; }
    }
}
