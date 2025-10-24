namespace SupplierDelivery.Application.Interfaces
{
    public interface IViewService<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
    }
}
