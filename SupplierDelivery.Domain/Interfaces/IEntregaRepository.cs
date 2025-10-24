using SupplierDelivery.Domain.Entities;

namespace SupplierDelivery.Domain.Interfaces
{
    public interface IEntregaRepository : IViewRepository<EntregaEntity>, ICreateRepository<EntregaEntity>
    {
    }
}
