using AutoMapper;
using AutoMapper.QueryableExtensions;
using HealthCare.Data;
using HealthCare.Models;
using HealthCare.Models.Options;
using HealthCare.Models.Requests;
using HealthCare.Models.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
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
        private readonly string BotToken;

        public TelegramUserController(ILogger<TelegramUserController> logger, HealthCareContext context,
            IMapper mapper, IOptions<BotOptions> options)
        {
            this.logger = logger;
            this.context = context;
            this.mapper = mapper;
            this.BotToken = options.Value.Token;
        }

        [HttpPost]
        public async Task<IActionResult> AddInformation([FromBody] TelegramUserAdd telegramUser)
        {
            if (!GetToken(BotToken).Equals(telegramUser.Token))
                return BadRequest("Invalid bot token");

            var newUser = mapper.Map<TelegramUser>(telegramUser);
            context.TelegramUsers.Add(newUser);
            await context.SaveChangesAsync();

            //logger.LogInformation($"{newUser.Id} --- row\n\tUser --- {newUser.UserId}\n\tSys - {newUser.Sys} | Dia - {newUser.Dia}\n\tWas added");
            return Ok();
        }

        [HttpGet("{userId:int}/{token}")]
        public async Task<ActionResult<TelegramUserResponse>> GetInformation(int userId, string token)
        {
            if (!GetToken(BotToken).Equals(token))
                return BadRequest("Invalid bot token");

            TelegramUser user = await context.TelegramUsers
                .FirstOrDefaultAsync(tu => tu.UserId == userId);
            if (user == null)
                return NotFound("Can't find user");

            return await context.TelegramUsers
                .Where(tu => tu.Id == user.Id)
                .ProjectTo<TelegramUserResponse>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }

        private string GetToken(string token)
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
