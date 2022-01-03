using Domain.Clients;
using Microsoft.EntityFrameworkCore;
using Nascimento.Software.LocaCar.Api.Infra.Database.Repositories.Contracts;

namespace Nascimento.Software.LocaCar.Api.Infra.Database.Repositories.Repository
{
    public class ClientRepository : IRepository<Client>
    {
        private readonly AppDbContext DbContext;
        public ClientRepository(AppDbContext context)
        {
            DbContext = context;
        }
        public async Task<bool> Add(Client entity)
        {
            DbContext.Add(entity);
            return await DbContext.SaveChangesAsync() > 0;

        }

        public async Task<Client> Get(string Id)
        {
            var client = await DbContext.Clients.Include(p => p.Addresses)
                .Include(p => p.Emails)
                .Include(p => p.Phones)
                .FirstOrDefaultAsync(p => p.Id == Id);
            return client;
        }

        public async Task<IEnumerable<Client>> GetAll()
        {
            var clients = await DbContext.Clients.Include(p => p.Addresses)
               .Include(p => p.Emails)
               .Include(p => p.Phones)
               .ToListAsync();
            return clients;
        }

        public async Task<bool> Remove(Client entity)
        {
            DbContext.Remove(entity);
            return await DbContext.SaveChangesAsync() > 0;

        }

        public async Task<bool> Update(Client entity)
        {
            DbContext.Update(entity);
            return await DbContext.SaveChangesAsync() > 0;

        }
    }
}
