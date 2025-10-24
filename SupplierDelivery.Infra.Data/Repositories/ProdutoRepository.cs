using Microsoft.EntityFrameworkCore;
using SupplierDelivery.Domain.Entities;
using SupplierDelivery.Domain.Interfaces;
using SupplierDelivery.Infra.Data.Context;

namespace SupplierDelivery.Infra.Data.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        ApplicationDbContext _context;

        public ProdutoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ProdutoEntity> CreateAsync(ProdutoEntity entity)
        {
            _context.Produto.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<ProdutoEntity>> GetAllAsync()
        {
            return await _context.Produto.ToListAsync();
        }
    }
}
