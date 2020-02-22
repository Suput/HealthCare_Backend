﻿using System;

namespace HealthCare.Models
{
    public class TelegramUser
    {
        public int Id { get; set; }

        // telegram user id
        public int UserId { get; set; }
        public int Sys { get; set; }
        public int Dia { get; set; }
        public int Pulse { get; set; }

        // when message was received
        public DateTime DateTime { get; set; }
    }
}
