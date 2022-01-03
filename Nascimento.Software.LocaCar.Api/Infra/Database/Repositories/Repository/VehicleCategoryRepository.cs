using Domain.Rent;
using Microsoft.EntityFrameworkCore;
using Nascimento.Software.LocaCar.Api.Infra.Database.Repositories.Contracts;

namespace Nascimento.Software.LocaCar.Api.Infra.Database.Repositories.Repository
{
    public class VehicleCategoryRepository : IRepository<Category>
    {
        private readonly AppDbContext _context;
        public VehicleCategoryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Add(Category entity)
        {
            _context.Add(entity);
            return await _context.SaveChangesAsync() > 0;

        }

        public async Task<Category> Get(string Id)
        {
            return await _context.Categories.FirstOrDefaultAsync(p => p.Id == Id);
        }

        public async Task<IEnumerable<Category>> GetAll()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<bool> Remove(Category entity)
        {
            _context.Remove(entity);
            return await _context.SaveChangesAsync() > 0;

        }

        public Task<bool> Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
