using System;
using AutoMapper;
using CI.interview.pltosman.Core.Entities.Concrete;
using CI.interview.pltosman.Entities.Concrete;
using CI.interview.pltosman.Entities.Dtos;

namespace CI.interview.pltosman.Business.Mappers
{
    public class FixerServiceMappingProfile : Profile
    {

        public FixerServiceMappingProfile()
        {
            CreateMap<FixerRate, FixerDetailResponse>()
               .ForMember(dest => dest.Base, opt => opt.MapFrom(src => src.Base))
               .ForMember(dest => dest.Success, opt => opt.MapFrom(src => src.Success))
               .ForMember(dest => dest.Timestamp, opt => opt.MapFrom(src => src.Timestamp))
               .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
               .ForMember(dest => dest.Rates, opt => opt.Ignore());

            CreateMap<FixerDetailResponse, FixerRate>()
             .ForMember(dest => dest.Base, opt => opt.MapFrom(src => src.Base))
             .ForMember(dest => dest.Success, opt => opt.MapFrom(src => src.Success))
             .ForMember(dest => dest.Timestamp, opt => opt.MapFrom(src => src.Timestamp))
             .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
             .ForMember(dest => dest.Rates, opt => opt.Ignore());


            CreateMap<ExcelData, DataExcelModelDto>()
                   .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount))
                   .ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.Currency))
                   .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country))
                   .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date))
                   .ForMember(dest => dest.SheetName, opt => opt.Ignore());


            CreateMap<DataExcelModelDto, ExcelData>()
                 .ForMember(dest => dest.Amount, opt => opt.MapFrom(src => src.Amount))
                 .ForMember(dest => dest.Currency, opt => opt.MapFrom(src => src.Currency))
                 .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country))
                 .ForMember(dest => dest.Date, opt => opt.MapFrom(src => src.Date));
        }

    }
}
