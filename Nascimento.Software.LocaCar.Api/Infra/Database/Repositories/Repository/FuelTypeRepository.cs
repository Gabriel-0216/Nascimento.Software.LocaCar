using Domain.Rent;
using Microsoft.EntityFrameworkCore;
using Nascimento.Software.LocaCar.Api.Infra.Database.Repositories.Contracts;

namespace Nascimento.Software.LocaCar.Api.Infra.Database.Repositories.Repository
{
    public class FuelTypeRepository : IRepository<FuelType>
    {
        private readonly AppDbContext _context;
        public FuelTypeRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Add(FuelType entity)
        {
            _context.Add(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<FuelType> Get(string Id)
        {
            return await _context.Fuels.FirstOrDefaultAsync(p => p.Id == Id);
        }

        public async Task<IEnumerable<FuelType>> GetAll()
        {
            return await _context.Fuels.ToListAsync();
        }

        public async Task<bool> Remove(FuelType entity)
        {
            _context.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public Task<bool> Update(FuelType entity)
        {
            throw new NotImplementedException();
        }
    }
}
