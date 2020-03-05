using System.Collections.Generic;

namespace HealthCare.Models.Responses
{
    public class TelegramUserResponse
    {
        public double AverageSys { get; set; }
        public double AverageDia { get; set; }
        public double AveragePulse { get; set; }
        public List<int> Syss { get; set; }
        public List<int> Dias { get; set; }
        public List<int> Pulses { get; set; }
    }
}
