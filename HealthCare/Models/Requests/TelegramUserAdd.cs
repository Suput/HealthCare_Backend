using System;
using System.ComponentModel.DataAnnotations;

namespace HealthCare.Models.Requests
{
    public class TelegramUserAdd
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int Sys { get; set; }
        [Required]
        public int Dia { get; set; }
        [Required]
        public int Pulse { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Required]
        public string Token { get; set; }
    }
}
