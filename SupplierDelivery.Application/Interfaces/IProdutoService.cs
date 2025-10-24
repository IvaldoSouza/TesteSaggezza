using SupplierDelivery.Application.DTOs;

namespace SupplierDelivery.Application.Interfaces
{
    public interface IProdutoService : IViewService<ProdutoQueryDTO>, ICreateService<ProdutoDTO>
    {
    }
}
