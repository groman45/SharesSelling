using AutoMapper;
using SharesSelling.Application.DTOs;
using SharesSelling.Domain.Entities;

namespace SharesSelling.Application;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<SaleResult, SaleResultDto>();
        CreateMap<StockLot, StockLotDto>();
    }
}

