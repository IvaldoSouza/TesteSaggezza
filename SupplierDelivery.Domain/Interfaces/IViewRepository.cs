namespace SupplierDelivery.Domain.Interfaces
{
    public interface IViewRepository<T> where T : class
    {
        Task<T> CreateAsync(T entity);
    }
}
