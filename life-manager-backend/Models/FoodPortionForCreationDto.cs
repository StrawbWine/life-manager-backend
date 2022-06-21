namespace life_manager_backend.Models
{
    public class FoodPortionForCreationDto
    {
        public long FoodId { get; set; }
        public int WeightInGrams { get; set; }
        public DateTime DateConsumed { get; set; }
    }
}
