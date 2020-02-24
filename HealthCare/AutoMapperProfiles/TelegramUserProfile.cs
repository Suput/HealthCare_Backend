using AutoMapper;
using HealthCare.Models;
using HealthCare.Models.Requests;
using HealthCare.Models.Responses;
using System.Linq;

namespace HealthCare.AutoMapperProfiles
{
    public class TelegramUserProfile : Profile
    {
        public TelegramUserProfile()
        {
            CreateMap<TelegramUserAdd, TelegramUser>();
            CreateMap<TelegramUser, TelegramUserResponse>()
                .ForMember(tur => tur.Syss, map => map.MapFrom(tu => tu.HealthRecords.Select(
                    hr => hr.Sys)))
                .ForMember(tur => tur.Dias, map => map.MapFrom(tu => tu.HealthRecords.Select(
                    hr => hr.Dia)))
                .ForMember(tur => tur.Pulses, map => map.MapFrom(tu => tu.HealthRecords.Select(
                    hr => hr.Pulse)))
                .ForMember(tur => tur.AverageSys, map => map.MapFrom(tu => tu.HealthRecords.Select(
                    hr => hr.Sys).Average()))
                .ForMember(tur => tur.AverageDia, map => map.MapFrom(tu => tu.HealthRecords.Select(
                    hr => hr.Dia).Average()))
                .ForMember(tur => tur.AveragePulse, map => map.MapFrom(tu => tu.HealthRecords.Select(
                    hr => hr.Pulse).Average()));
        }
    }
}
