using SupplierDelivery.Application.DTOs;

namespace SupplierDelivery.Application.Interfaces
{
    public interface IEntregaService : IViewService<EntregaQueryDTO>, ICreateService<EntregaDTO>
    {
    }
}
