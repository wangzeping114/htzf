using AutoMapper;
using WS.HTZF.Application.Dtos;
using WS.HTZF.Application.Resources;
using WS.HTZF.Core.Entites.Sys;

namespace WS.HTZF.Application.MappingProfile
{
    /// <summary>
    /// 商品
    /// </summary>
    public class CdyProfile:Profile
    {
        /// <summary>
        /// ctor.
        /// </summary>
        public CdyProfile()
        {

            CreateMap<StockDto, Stock>();

            CreateMap<AddCdyDto, Commodity>()
                .ForMember(c=>c.Stock,o=>o.MapFrom(s=>s.StockDto));

            CreateMap<ModifyCdyDto, Commodity>()
                .ForMember(c => c.Stock, o => o.MapFrom(s => s.StockDto));

            CreateMap<Commodity, CdyRescource>()
                .ForMember(c=>c.CategoryName,o=>o.MapFrom(s=>s.Category.Name))
                .ForMember(c => c.HaveSalesQuantity, o => o.MapFrom(s => s.Stock.HaveSalesQuantity))
                .ForMember(c => c.Quantity, o => o.MapFrom(s => s.Stock.Quantity))
                .ForMember(c => c.ReservedQuantity, o => o.MapFrom(s => s.Stock.ReservedQuantity));
              

            CreateMap<CdyDPrictureDto, CommodityDetailPirture>()
                .ForMember(c=>c.CommodityDetailId,o=>o.MapFrom(c=>c.CdDId)).ReverseMap();

            CreateMap<SaveCdyDetailDto, CommodityDetail>()
                 .ForMember(c => c.Id, o => o.MapFrom(s => s.CommdiyId))
                 .ForMember(c => c.CommodityDetailPirtures, o => o.MapFrom(s => s.CdyDPrictureDtos));

            CreateMap<CommodityDetail, CdyDetailResource>()
                .ForMember(c=>c.CommdiyId,o=>o.MapFrom(c=>c.Id))
                .ForMember(c=>c.CdyDPrictureDtos,o=>o.MapFrom(c=>c.CommodityDetailPirtures));
        }
    }
}
