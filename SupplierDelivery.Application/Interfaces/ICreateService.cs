namespace SupplierDelivery.Application.Interfaces
{
    public interface ICreateService<T> where T : class
    {
        Task AddAsync(T dto);
    }
}
