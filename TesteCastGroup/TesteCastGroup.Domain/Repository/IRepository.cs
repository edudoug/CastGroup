namespace TesteCastGroup.Domain.Repository
{
    public interface IRepository<T>
    {
        Task<T> Get();
    }
}
