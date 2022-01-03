using Domain.Clients;
using Domain.Rent;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Nascimento.Software.LocaCar.Api.Infra
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options ) : base( options )
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<CarRent> CarRents { get; set; }
        public DbSet<CategoryPrice> CategoriesPrices { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<FuelType> Fuels { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Vehicle>().HasOne(p => p.Fuel);
            builder.Entity<Vehicle>().HasOne(p => p.Category);
            builder.Entity<Vehicle>().HasOne(p => p.Brand);
            builder.Entity<Vehicle>().HasOne(p => p.CarModel);

            builder.Entity<Client>().HasMany(p => p.Emails);
            builder.Entity<Client>().HasMany(p => p.Addresses);
            builder.Entity<Client>().HasMany(p => p.Phones);

            builder.Entity<CarRent>().HasOne(p => p.Client);
            builder.Entity<CarRent>().HasOne(p => p.Vehicle);

            builder.Entity<CategoryPrice>().HasOne(p => p.Category);


            base.OnModelCreating(builder);
        }

    }
}
