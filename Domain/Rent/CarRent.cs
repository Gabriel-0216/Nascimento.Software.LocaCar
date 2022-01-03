using Domain.Clients;
using Domain.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Rent;

namespace Domain.Rent
{
    public sealed class CarRent : Entity
    {
        public DateTime RentStart_Date { get; private set; }
        public DateTime RentEnd_Date { get; private set; }
        public decimal Price { get; private set; }
        public string ClientId { get; private set; } = string.Empty;
        [ForeignKey("ClientId")]
        public Client Client { get; private set; }
        public string VehicleId { get; private set; } = string.Empty;
        public Vehicle Vehicle { get ; private set; }
        public bool Finished { get; private set; }


        public bool SetVehicle(string vehicleId)
        {
            if (string.IsNullOrWhiteSpace(vehicleId)) return false;

            VehicleId = vehicleId;
            return true;
        }
        public bool SetClient(string clientId)
        {
            if (string.IsNullOrWhiteSpace(clientId)) return false;

            ClientId = clientId;
            return true;
        }
        public bool SetPeriod(DateTime start, DateTime finish)
        {
            if(start > finish)
            {
                return false;
            }
            if(start == finish)
            {
                return false;
            }

            RentStart_Date = Convert.ToDateTime(start.ToString("dd/MM/yyyy"));
            RentEnd_Date = Convert.ToDateTime(finish.ToString("dd/MM/yyyy"));

            return true;
        }
        public bool StartRent()
        {
            if(string.IsNullOrWhiteSpace(ClientId)) return false;
            if (string.IsNullOrWhiteSpace(VehicleId)) return false;
            if (string.IsNullOrWhiteSpace(RentStart_Date.ToString())) return false;
            if (string.IsNullOrWhiteSpace(RentEnd_Date.ToString())) return false;

            var days = RentEnd_Date - RentStart_Date;
            Price = Convert.ToDecimal(days.TotalDays * 1);//buscar o preço diário da categoria daquele carro
            Finished = false;
            return true;

        }
        public bool FinishRent()
        {
            Finished = true;
            return true;
        }


    }
}
