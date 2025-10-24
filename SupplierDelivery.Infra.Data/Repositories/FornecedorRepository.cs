using Microsoft.EntityFrameworkCore;
using SupplierDelivery.Domain.Entities;
using SupplierDelivery.Domain.Interfaces;
using SupplierDelivery.Infra.Data.Context;

namespace SupplierDelivery.Infra.Data.Repositories
{
    public class FornecedorRepository : IFornecedorRepository
    {
        ApplicationDbContext _context;
        public FornecedorRepository(ApplicationDbContext context) 
        {
            _context = context;
        }

        public async Task<FornecedorEntity> CreateAsync(FornecedorEntity entity)
        {
            _context.Fornecedor.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<FornecedorEntity>> GetAllAsync()
        {
            return await _context.Fornecedor.ToListAsync();
        }
    }
}
