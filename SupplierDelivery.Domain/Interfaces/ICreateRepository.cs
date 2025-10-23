namespace SupplierDelivery.Domain.Interfaces
{
    public interface ICreateRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
    }
}
