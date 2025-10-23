using SupplierDelivery.Domain.Entities;

namespace SupplierDelivery.Domain.Interfaces
{
    public interface IProdutoRepository : IViewRepository<ProdutoEntity>, ICreateRepository<ProdutoEntity>
    {
    }
}
