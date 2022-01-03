using Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Rent
{
    public sealed class Model : Entity
    {
        public string Name { get; set; } = string.Empty;
        public string BrandId { get; set; } = string.Empty;
        public Brand Brand { get; set; }

    }
}
