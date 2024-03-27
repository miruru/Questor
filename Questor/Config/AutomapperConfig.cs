using AutoMapper;
using BancoClass.Entities;
using BoletoClass.Entities;
using Questor.Dto;

namespace Questor.Config
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            #region Banco
            CreateMap<Banco, GetBancoDto>().ReverseMap();
            CreateMap<Banco, CreateBancoDto>().ReverseMap();
            CreateMap<CreateBancoDto, GetBancoDto>().ReverseMap();
            CreateMap<GetBancoDto, GetBancoDto>().ReverseMap();
            #endregion

            #region Boleto
            CreateMap<Boleto, GetBoletoDto>().ReverseMap();
            CreateMap<Boleto, CreateBoletoDto>().ReverseMap();
            CreateMap<CreateBoletoDto, GetBoletoDto>().ReverseMap();
            CreateMap<GetBoletoDto, CreateBoletoDto>().ReverseMap();
            #endregion
        }
    }
}
