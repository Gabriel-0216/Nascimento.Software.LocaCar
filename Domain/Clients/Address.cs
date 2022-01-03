﻿using Domain.Shared;

namespace Domain.Clients
{
    public class Address : Entity
    {
        public string ZipCode { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
    }
}