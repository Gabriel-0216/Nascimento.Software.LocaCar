using Domain.Rent;
using Microsoft.EntityFrameworkCore;
using Nascimento.Software.LocaCar.Api.Infra.Database.Repositories.Contracts;

namespace Nascimento.Software.LocaCar.Api.Infra.Database.Repositories.Repository
{
    public class VehicleRepository : IRepository<Vehicle>
    {
        private readonly AppDbContext _context;
        public VehicleRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Add(Vehicle entity)
        {
            _context.Add(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<Vehicle> Get(string Id)
        {
            return await _context.Vehicles
               .Include(p => p.Brand)
               .Include(p => p.CarModel)
               .Include(p => p.Fuel)
               .Include(p => p.Category)
               .FirstOrDefaultAsync(p=> p.Id == Id);
        }

        public async Task<IEnumerable<Vehicle>> GetAll()
        {
            return await _context.Vehicles
                .Include(p => p.Brand)
                .Include(p => p.CarModel)
                .Include(p => p.Fuel)
                .Include(p => p.Category)
                .ToListAsync();
        }

        public async Task<bool> Remove(Vehicle entity)
        {
            _context.Remove(entity);
            return await _context.SaveChangesAsync() > 0;
        }

        public Task<bool> Update(Vehicle entity)
        {
            throw new NotImplementedException();
        }
    }
}
