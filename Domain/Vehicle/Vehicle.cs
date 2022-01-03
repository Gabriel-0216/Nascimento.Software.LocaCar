using Domain.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Rent
{
    public sealed class Vehicle : Entity
    {
        public int VehicleNumber { get; private set; } = Guid.NewGuid().GetHashCode();
        public string VehiclePlate { get; private set; }
        public string ModelId { get; set; } = string.Empty;
        [ForeignKey("ModelId")]
        public Model CarModel { get; set; } = new Model();
        public string BrandId { get; set; } = string.Empty;
        [ForeignKey("BrandId")]
        public Brand Brand { get; set; } = new Brand();
        public string CategoryId { get; set; } = string.Empty;
        [ForeignKey("CategoryId")]
        public Category Category { get; set; } = new Category();
        public int Year { get; set; }
        public bool Available { get; set; }
        public string FuelId { get; set; }

        [ForeignKey("FuelId")]
        public FuelType Fuel { get; set; }
        public int FuelTankCapacity { get; set; }
        public int DoorsQuantity { get; set; }

        private bool SetVehiclePlate(string vehiclePlate)
        {
            if (string.IsNullOrWhiteSpace(VehiclePlate)) return false;


            VehiclePlate = RemoveSpecialCharacteres(vehiclePlate);
            return true;

        }



        private static string RemoveSpecialCharacteres(string text)
        {
            return System.Text.RegularExpressions.Regex.Replace(text, @"[^0-9a-zA-ZéúíóáÉÚÍÓÁèùìòàÈÙÌÒÀõãñÕÃÑêûîôâÊÛÎÔÂëÿüïöäËYÜÏÖÄçÇ]+?", string.Empty);
        }
    }
}
