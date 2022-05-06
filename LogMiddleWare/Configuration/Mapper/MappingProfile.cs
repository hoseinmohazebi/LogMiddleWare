using AutoMapper;
using LogMiddleWare.Data.Entities;
using LogMiddleWare.Models;

namespace LogMiddleWare.Configuration.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<LogEvent, LogVm>()
                .ForMember(t => t.Date, m => m.MapFrom(q => q.TimeStamp.ToString("yyyy/MM/mm")))
                .ForMember(t => t.Time, m => m.MapFrom(q => q.TimeStamp.ToString("HH:mm")))
                .ForMember(t => t.ResponseBody, m => m.MapFrom(q => q.ResponseBody != null ? q.ResponseBody.Substring(0, 100) : ""));
        }
    }
}
