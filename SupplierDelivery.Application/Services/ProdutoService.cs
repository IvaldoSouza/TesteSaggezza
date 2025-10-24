using AutoMapper;
using SupplierDelivery.Application.DTOs;
using SupplierDelivery.Application.Interfaces;
using SupplierDelivery.Domain.Entities;
using SupplierDelivery.Domain.Interfaces;

namespace SupplierDelivery.Application.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly IMapper _mapper;
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoService(IMapper mapper, IProdutoRepository produtoRepository)
        {
            _mapper = mapper;
            _produtoRepository = produtoRepository;
        }

        public async Task AddAsync(ProdutoDTO dto)
        {
            var entity = _mapper.Map<ProdutoEntity>(dto);
            await _produtoRepository.CreateAsync(entity);
        }

        public async Task<IEnumerable<ProdutoQueryDTO>> GetAllAsync()
        {
            var entity = await _produtoRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProdutoQueryDTO>>(entity);
        }
    }
}
