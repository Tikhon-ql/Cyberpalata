using CSharpFunctionalExtensions;
using Cyberpalata.Common;
using Cyberpalata.DataProvider.Models.Devices;
using Cyberpalata.Logic.Models.Devices;

namespace Cyberpalata.Logic.Configuration.MapperConfiguration
{
    internal static class PcMapConfig
    {
        public static void CreateMap(AppMappingProfile profile)
        {
            profile.CreateMap<Pc, PcDto>()
                .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dst => dst.Hdd, opt => opt.MapFrom(src => src.Hdd))
                .ForMember(dst => dst.Ssd, opt => opt.MapFrom(src => src.Ssd))
                .ForMember(dst => dst.Ram, opt => opt.MapFrom(src => src.Ram))
                .ForMember(dst => dst.Cpu, opt => opt.MapFrom(src => src.Cpu))
                .ForMember(dst => dst.Gpu, opt => opt.MapFrom(src => src.Gpu));
            profile.CreateMap<PcDto, Pc>();
            profile.CreateMap<PagedList<Pc>, PagedList<PcDto>>();
            profile.CreateMap<Maybe<Pc>, Maybe<PcDto>>();
            profile.CreateMap<Maybe<List<Pc>>, Maybe<List<PcDto>>>();
        }
    }
}
