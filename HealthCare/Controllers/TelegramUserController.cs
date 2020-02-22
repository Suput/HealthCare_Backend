using AutoMapper;
using HealthCare.Data;
using HealthCare.Models;
using HealthCare.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCare.Controllers
{
    [Route("api/user")]
    public class TelegramUserController : MainController
    {
        private readonly ILogger<TelegramUserController> logger;
        private readonly HealthCareContext context;
        private readonly IMapper mapper;

        public TelegramUserController(ILogger<TelegramUserController> logger, HealthCareContext context,
            IMapper mapper)
        {
            this.logger = logger;
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddInformation([FromForm] TelegramUserAdd telegramUser)
        {
            var newUser = mapper.Map<TelegramUser>(telegramUser);
            context.TelegramUsers.Add(newUser);
            await context.SaveChangesAsync();

            logger.LogInformation($"{newUser.Id} --- row\nUser --- {newUser.UserId}\nSys - {newUser.Sys} | Dia - {newUser.Dia}\nWas added");
            return Ok();
        }
    }
}
