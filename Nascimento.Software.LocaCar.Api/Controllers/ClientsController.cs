using AutoMapper;
using Domain.Clients;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Nascimento.Software.LocaCar.Api.DTO;
using Nascimento.Software.LocaCar.Api.Infra.Database.Repositories.Contracts;

namespace Nascimento.Software.LocaCar.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IRepository<Client> _repo;
        private readonly IMapper _map;
        public ClientsController(IRepository<Client> repo, IMapper map)
        {
            _map = map;
            _repo = repo;
        }
        [HttpGet]
        [Route("get-all-clients")]
        public async Task<ActionResult> GetAllClientsAsync()
        {
            return Ok(await _repo.GetAll());
        }
        [HttpGet]
        [Route("get-client-by-id")]
        public async Task<ActionResult> GetClientById([FromHeader] string id)
        {
            return Ok(await _repo.Get(id));
        }
        [HttpPost]
        [Route("insert-new-client")]
        public async Task<ActionResult> InsertNewClient([FromBody] ClientDTO client)
        {
            if (ModelState.IsValid)
            {
                var clientMap = DTOtoModel(client);

                var insert = await _repo.Add(clientMap);
                if (insert) return Ok();
                else
                {
                    return BadRequest();
                }
            }
            else
            {
                return BadRequest();
            }
        }

        private Client DTOtoModel(ClientDTO client)
        {
            var clientMap = new Client();
            clientMap.Name = client.Name;
            foreach(var item in client.Phones)
            {
                clientMap.Phones.Add(new Phone()
                {
                    PhoneNumber = item.PhoneNumber,
                });
            }
            foreach(var item in client.Addresses)
            {
                clientMap.Addresses.Add(new Address()
                {
                    City = item.City,
                    State = item.State,
                    Country = item.Country,
                    Street = item.Street,
                    Number = item.Number,
                    ZipCode = item.ZipCode,
                });
            }
            foreach(var item in client.Emails)
            {
                clientMap.Emails.Add(new Email()
                {
                    EmailAddress = item.EmailAddress,
                });
            }
            return clientMap;
        }

        [HttpDelete]
        [Route("delete-client-by-id")]
        public async Task<ActionResult> DeleteClientById([FromHeader] string id)
        {
            if (string.IsNullOrWhiteSpace(id)) return BadRequest();

            var clientGet = await _repo.Get(id);
            if (clientGet == null) return BadRequest("Client doesn't exists!");

            var deleted = await _repo.Remove(clientGet);
            if (deleted) return Ok();

            return BadRequest();
        }

        [HttpPut]
        [Route("edit-client-register")]
        public async Task<ActionResult> EditClientRegister([FromHeader] string id, [FromBody] ClientDTO client)
        {
            if (string.IsNullOrWhiteSpace(id)) return BadRequest();
            if (!ModelState.IsValid) return BadRequest();

            var clientGet = await _repo.Get(id);
            if (clientGet == null) return BadRequest();

            var clientMap = _map.Map<Client>(client);
            clientMap.Id = id;
            var updated = await _repo.Update(clientMap);
            if (updated) return Ok();
            return BadRequest();
        }
    }
}
