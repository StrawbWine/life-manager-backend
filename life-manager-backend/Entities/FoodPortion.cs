using life_manager_backend.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace life_manager_backend.Entities
{
    public class FoodPortion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public Food? Food { get; set; }
        [ForeignKey("FoodId")]
        public long FoodId { get; set; }
        [Range(0.0, int.MaxValue)]
        public int WeightInGrams { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateConsumed { get; set; }

        public FoodPortion(long foodId, int weightInGrams, DateTime dateConsumed)
        {
            FoodId = foodId;
            WeightInGrams = weightInGrams;
            DateConsumed = dateConsumed;
        }        
    }
}
