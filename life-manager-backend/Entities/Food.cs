using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace life_manager_backend.Entities
{
    public class Food
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [Required]
        public string Name { get; set; } = String.Empty;
        [Range(0.0, double.MaxValue)]
        public double? Energy { get; set; }
        [Range(0.0, double.MaxValue)]
        public double? Fat { get; set; }
        [Range(0.0, double.MaxValue)]
        public double? SaturatedFat { get; set; }
        [Range(0.0, double.MaxValue)]
        public double? MonoUnsaturatedFat { get; set; }
        [Range(0.0, double.MaxValue)]
        public double? PolyUnsaturatedFat { get; set; }
        [Range(0.0, double.MaxValue)]
        public double? Carbohydrates { get; set; }
        [Range(0.0, double.MaxValue)]
        public double? Sugars { get; set; }
        [Range(0.0, double.MaxValue)]
        public double? Protein { get; set; }
        [Range(0.0, double.MaxValue)]
        public double? Salt { get; set; }
        [Range(0.0, double.MaxValue)]
        public double? Fiber { get; set; }

        public Food(string name)
        {
            Name = name;
        }
    }
}
