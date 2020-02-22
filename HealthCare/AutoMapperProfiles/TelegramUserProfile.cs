using AutoMapper;
using HealthCare.Models;
using HealthCare.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.AutoMapperProfiles
{
    public class TelegramUserProfile : Profile
    {
        public TelegramUserProfile()
        {
            CreateMap<TelegramUserAdd, TelegramUser>();
        }
    }
}
