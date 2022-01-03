using Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Clients
{
    public sealed class Client : Entity
    {
        public string Name { get; set; } = string.Empty;
        public List<Email> Emails { get; set; } = new List<Email>();
        public List<Address> Addresses { get; set; } = new List<Address>();
        public List<Phone> Phones { get; set; } = new List<Phone>();
    }
}
