namespace Nascimento.Software.LocaCar.Api.DTO
{
    public class VehicleDTO
    {
        public string VehiclePlate { get; private set; }
        public string ModelId { get; set; } = string.Empty;
        public string BrandId { get; set; } = string.Empty;
        public string CategoryId { get; set; } = string.Empty;
        public int Year { get; set; }
        public bool Available { get; set; }
        public string FuelId { get; set; }
        public int FuelTankCapacity { get; set; }
        public int DoorsQuantity { get; set; }
    }
    public class BrandDTO
    {
        public string Name { get; set; }
    }
    public class ModelDTO
    {
        public string Name { get; set; }
        public string BrandId { get; set; }

    }
    public class CategoryDTO
    {
        public string Name { get; set; }
    }
}
