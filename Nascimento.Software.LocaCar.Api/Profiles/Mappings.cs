using AutoMapper;
using Domain.Clients;
using Nascimento.Software.LocaCar.Api.DTO;

namespace Nascimento.Software.LocaCar.Api.Profiles
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<ClientDTO, Client>().ReverseMap();
        }
    }
}
