using AutoMapper;
using HealthCare.Data;
using HealthCare.Models;
using HealthCare.Models.Options;
using HealthCare.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Controllers
{
    [Route("api/user")]
    public class TelegramUserController : MainController
    {
        private readonly ILogger<TelegramUserController> logger;
        private readonly HealthCareContext context;
        private readonly IMapper mapper;
        private readonly BotOptions options;

        public TelegramUserController(ILogger<TelegramUserController> logger, HealthCareContext context,
            IMapper mapper, IOptions<BotOptions> options)
        {
            this.logger = logger;
            this.context = context;
            this.mapper = mapper;
            this.options = options.Value;
        }

        [HttpPost]
        public async Task<IActionResult> AddInformation([FromForm] TelegramUserAdd telegramUser)
        {
            if (!GetTokenHash(options.Token).Equals(telegramUser.Token))
                return BadRequest("Invalid bot token");

            var newUser = mapper.Map<TelegramUser>(telegramUser);
            context.TelegramUsers.Add(newUser);
            await context.SaveChangesAsync();

            logger.LogInformation($"{newUser.Id} --- row\n\tUser --- {newUser.UserId}\n\tSys - {newUser.Sys} | Dia - {newUser.Dia}\n\tWas added");
            return Ok();
        }

        private string GetTokenHash(string token)
        {
            StringBuilder sb = new StringBuilder();
            using (var hash = SHA256.Create())
            {
                Byte[] hash_bytes = hash.ComputeHash(Encoding.UTF8.GetBytes(token));
                foreach (Byte b in hash_bytes)
                    sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
