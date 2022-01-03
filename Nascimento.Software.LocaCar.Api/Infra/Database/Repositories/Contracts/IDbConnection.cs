namespace Nascimento.Software.LocaCar.Api.Infra.Database.Repositories.Contracts
{
    public interface IDbConnection
    {
        public AppDbContext DbContext { get; set; }
    }
}
