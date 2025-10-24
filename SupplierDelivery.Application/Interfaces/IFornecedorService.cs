using SupplierDelivery.Application.DTOs;

namespace SupplierDelivery.Application.Interfaces
{
    public interface IFornecedorService : IViewService<FornecedorQueryDTO>, ICreateService<FornecedorDTO>
    {
    }
}
