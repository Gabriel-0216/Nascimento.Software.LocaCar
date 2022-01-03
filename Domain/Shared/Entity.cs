using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Shared
{
    public abstract class Entity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime Created_At { get; set; } = Convert.ToDateTime(DateTime.Now.ToString("dd/MM/yyyy"));

    }
}
