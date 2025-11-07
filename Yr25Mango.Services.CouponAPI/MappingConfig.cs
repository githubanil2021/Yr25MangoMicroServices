

using Yr25Mango.Services.CouponAPI.Models;
using Yr25Mango.Services.CouponAPI.Models.DTO;

namespace Yr25Mango.Services.CouponAPI
{
    public static class MappingConfig
    {
        public static AutoMapper.MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Coupon, CouponDTO>().ReverseMap();

            });
            return mappingConfig;
        }
    }
}
