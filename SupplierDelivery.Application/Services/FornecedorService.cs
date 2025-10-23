using AutoMapper;
using SupplierDelivery.Application.DTOs;
using SupplierDelivery.Application.Interfaces;
using SupplierDelivery.Domain.Interfaces;

namespace SupplierDelivery.Application.Services
{
    public class FornecedorService : IFornecedorService
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IMapper _mapper;
        public FornecedorService(IFornecedorRepository fornecedorRepository, IMapper mapper)
        {
            _fornecedorRepository = fornecedorRepository;
            _mapper = mapper;
        }
        public async Task AddAsync(FornecedorDTO dto)
        {
            var entity = _mapper.Map<Domain.Entities.FornecedorEntity>(dto);
            await _fornecedorRepository.CreateAsync(entity);
        }

        public async Task<IEnumerable<FornecedorDTO>> GetAllAsync()
        {
            var entity = await _fornecedorRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<FornecedorDTO>>(entity);
        }
    }
}
