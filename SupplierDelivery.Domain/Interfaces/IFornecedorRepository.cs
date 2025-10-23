using SupplierDelivery.Domain.Entities;

namespace SupplierDelivery.Domain.Interfaces
{
    public interface IFornecedorRepository : IViewRepository<FornecedorEntity>, ICreateRepository<FornecedorEntity>
    {
    }
}
