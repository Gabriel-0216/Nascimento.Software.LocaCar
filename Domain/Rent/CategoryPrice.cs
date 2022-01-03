using Domain.Shared;
using Domain.Rent;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Rent
{
    public class CategoryPrice : Entity
    {
        public bool Active { get; set; }
        public DateTime Price_StartDate { get; set; }
        public DateTime Price_FinishDate { get; set; }
        public decimal Daily_Price { get; set; }
        public string CategoryId { get; set; } = string.Empty;
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }



    }
}
