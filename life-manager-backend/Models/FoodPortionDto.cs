namespace life_manager_backend.Models
{
    public class FoodPortionDto
    {
        public long Id { get; set; }
        public FoodDto Food { get; set; }
        public int WeightInGrams { get; set; }
        public DateTime DateConsumed { get; set; }
        public double? Energy
        {
            get
            {
                return Food.Energy * WeightInGrams * 0.01;             
            }
        }
        public double? Fat
        {
            get
            {
                return Food.Fat * WeightInGrams * 0.01;
            }
        }
        public double? SaturatedFat
        {
            get
            {
                return Food.SaturatedFat * WeightInGrams * 0.01;
            }
        }
        public double? MonoUnsaturatedFat
        {
            get
            {
                return Food.MonoUnsaturatedFat * WeightInGrams * 0.01;
            }
        }
        public double? PolyUnsaturatedFat
        {
            get
            {
                return Food.PolyUnsaturatedFat * WeightInGrams * 0.01;
            }
        }
        public double? Carbohydrates
        {
            get
            {
                return Food.Carbohydrates * WeightInGrams * 0.01;
            }
        }
        public double? Sugars
        {
            get
            {
                return Food.Sugars * WeightInGrams * 0.01;
            }
        }
        public double? Protein
        {
            get
            {
                return Food.Protein * WeightInGrams * 0.01;
            }
        }
        public double? Salt
        {
            get
            {
                return Food.Salt * WeightInGrams * 0.01;
            }
        }
        public double? Fiber
        {
            get
            {
                return Food.Fiber * WeightInGrams * 0.01;
            }
        }

    }
}
