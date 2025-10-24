using Microsoft.EntityFrameworkCore;
using SupplierDelivery.Domain.Entities;
using SupplierDelivery.Domain.Interfaces;
using SupplierDelivery.Infra.Data.Context;

namespace SupplierDelivery.Infra.Data.Repositories
{
    public class EntregaRepository : IEntregaRepository
    {
        ApplicationDbContext _context;

        public EntregaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<EntregaEntity> CreateAsync(EntregaEntity entity)
        {
            _context.Entrega.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<EntregaEntity>> GetAllAsync()
        {
            return await _context.Entrega
                .Include(e => e.Fornecedor)
                .Include(e => e.Produto)
                .ToListAsync();
        }
    }
}
