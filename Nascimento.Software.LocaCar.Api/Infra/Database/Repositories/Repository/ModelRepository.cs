using Domain.Rent;
using Microsoft.EntityFrameworkCore;
using Nascimento.Software.LocaCar.Api.Infra.Database.Repositories.Contracts;

namespace Nascimento.Software.LocaCar.Api.Infra.Database.Repositories.Repository
{
    public class ModelRepository : IRepository<Model>
    {
        private readonly AppDbContext _context;

        public ModelRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Add(Model entity)
        {
            _context.Add(entity);
            return await _context.SaveChangesAsync() > 0;

        }

        public async Task<Model> Get(string Id)
        {
            return await _context.Models
                .Include(p=> p.Brand)
                .FirstOrDefaultAsync(p => p.Id == Id);
        }

        public async Task<IEnumerable<Model>> GetAll()
        {
            return await _context.Models
                .Include(p => p.Brand)
                .ToListAsync();
        }

        public async Task<bool> Remove(Model entity)
        {
            _context.Remove(entity);
            return await _context.SaveChangesAsync() > 0;

        }

        public async Task<bool> Update(Model entity)
        {
            _context.Update(entity);
            return await _context.SaveChangesAsync() > 0;

        }
    }
}
