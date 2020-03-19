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
        public async Task<IActionResult> AddInformation([FromBody] HealthRecordCreate healthRecordcreate)
        {
            if (!BotToken.Equals(healthRecordcreate.Token))
                return BadRequest("Invalid bot token");

            TelegramUser user = await context.TelegramUsers
                .FirstOrDefaultAsync(tu => tu.UserId == healthRecordcreate.TelegramUserId);
            if (user == null)
            {
                user = new TelegramUser
                {
                    UserId = healthRecordcreate.TelegramUserId
                };
                context.TelegramUsers.Add(user);
                await context.SaveChangesAsync();
            }

            var newRecord = mapper.Map<HealthRecord>(healthRecordcreate);
            newRecord.TelegramUserId = user.Id;

            context.HealthRecords.Add(newRecord);
            await context.SaveChangesAsync();

            logger.LogInformation($"{newRecord.Id}: {newRecord.TelegramUserId} --- row\n\tUser --- {newRecord.TelegramUserId}\n\tSys - {newRecord.Sys} | Dia - {newRecord.Dia}\n\tWas added");
            return Ok();
        }

        [HttpGet("{userId:int}/{token}")]
        public async Task<ActionResult<TelegramUserResponse>> GetInformation(int userId, string token)
        {
            if (!BotToken.Equals(token))
                return BadRequest("Invalid bot token");

            TelegramUser user = await context.TelegramUsers
                .FirstOrDefaultAsync(tu => tu.UserId == userId);
            if (user == null)
                return NotFound("Can't find user");

            var data = await context.TelegramUsers
                .Where(tu => tu.Id == user.Id)
                .ProjectTo<TelegramUserResponse>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            data.Syss = data.Syss.Skip(Math.Max(0, data.Syss.Count - 10)).ToList();
            data.Dias = data.Dias.Skip(Math.Max(0, data.Dias.Count - 10)).ToList();
            data.Pulses = data.Pulses.Skip(Math.Max(0, data.Pulses.Count - 10)).ToList();
            return data;
        }
    }
}
