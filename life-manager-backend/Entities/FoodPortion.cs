using life_manager_backend.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace life_manager_backend.Entities
{
    public class FoodPortion
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public Food? Food { get; set; }
        [ForeignKey("FoodId")]
        public string FoodId { get; set; }
        [Range(0.0, int.MaxValue)]
        public int WeightInGrams { get; set; }
        [DataType(DataType.Date)]
        public string DateConsumed { get; set; }
        public string PartitionKey { get; set; } = "1";

        public FoodPortion(string foodId, int weightInGrams, string dateConsumed)
        {
            FoodId = foodId;
            WeightInGrams = weightInGrams;
            DateConsumed = dateConsumed;
            Id = Guid.NewGuid().ToString();
        }        
    }
}
