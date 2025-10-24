using AutoMapper;
using SupplierDelivery.Application.DTOs;
using SupplierDelivery.Domain.Entities;

namespace SupplierDelivery.Application.Mapping
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<FornecedorEntity, FornecedorDTO>().ReverseMap();
            CreateMap<ProdutoEntity, ProdutoDTO>().ReverseMap();
            CreateMap<EntregaEntity, EntregaDTO>().ReverseMap();
            CreateMap<FornecedorEntity, FornecedorQueryDTO>().ReverseMap();
            CreateMap<ProdutoEntity, ProdutoQueryDTO>().ReverseMap();
            CreateMap<EntregaEntity, EntregaQueryDTO>().ReverseMap();
        }
    }
}
