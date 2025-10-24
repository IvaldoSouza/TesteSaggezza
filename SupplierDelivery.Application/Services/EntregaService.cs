using AutoMapper;
using SupplierDelivery.Application.DTOs;
using SupplierDelivery.Application.Interfaces;
using SupplierDelivery.Domain.Entities;
using SupplierDelivery.Domain.Interfaces;

namespace SupplierDelivery.Application.Services
{
    public class EntregaService : IEntregaService
    {
        private readonly IMapper _mapper;
        private readonly IEntregaRepository _entregaRepository;

        public EntregaService(IMapper mapper, IEntregaRepository entregaRepository)
        {
            _mapper = mapper;
            _entregaRepository = entregaRepository;
        }

        public async Task AddAsync(EntregaDTO dto)
        {
            var entity = _mapper.Map<EntregaEntity>(dto);
            await _entregaRepository.CreateAsync(entity);
        }

        public async Task<IEnumerable<EntregaQueryDTO>> GetAllAsync()
        {
            var entity = await _entregaRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<EntregaQueryDTO>>(entity);
        }
    }
}
