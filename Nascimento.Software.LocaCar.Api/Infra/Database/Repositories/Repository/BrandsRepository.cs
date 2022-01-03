using Domain.Rent;
using Microsoft.EntityFrameworkCore;
using Nascimento.Software.LocaCar.Api.Infra.Database.Repositories.Contracts;

namespace Nascimento.Software.LocaCar.Api.Infra.Database.Repositories.Repository
{
    public class BrandsRepository : IRepository<Brand>
    {
        private readonly AppDbContext _context;
        public BrandsRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Add(Brand entity)
        {
            _context.Add(entity);
            return await _context.SaveChangesAsync() > 0;

        }

        public async Task<Brand> Get(string Id)
        {
            return await _context.Brands.FirstOrDefaultAsync(p => p.Id == Id);
        }

        public async Task<IEnumerable<Brand>> GetAll()
        {
            return await _context.Brands.ToListAsync();
        }

        public async Task<bool> Remove(Brand entity)
        {
            _context.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> Update(Brand entity)
        {
            _context.Update(entity);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
