namespace Nascimento.Software.LocaCar.Api.DTO
{
    public class ClientDTO
    {
        public string Name { get; set; }
        public List<EmailDTO> Emails { get; set; }
        public List<AddressDTO> Addresses{ get; set; }
        public List<PhoneDTO> Phones { get; set; }

    }
    public class EmailDTO
    {
        public string EmailAddress { get; set; }

    }
    public class AddressDTO
    {
        public string ZipCode { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string Number { get; set; } = string.Empty;
    }
    public class PhoneDTO
    {
        public string PhoneNumber { get; set; }

    }
}
