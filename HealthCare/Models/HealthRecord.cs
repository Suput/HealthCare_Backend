using System;

namespace HealthCare.Models
{
    public class HealthRecord
    {
        public int Id { get; set; }

        public int TelegramUserId { get; set; }
        public TelegramUser TelegramUser { get; set; }

        public int Sys { get; set; }
        public int Dia { get; set; }
        public int Pulse { get; set; }

        // when message was received
        public DateTime DateTime { get; set; }
    }
}
