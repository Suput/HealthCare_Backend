using System;
using System.ComponentModel.DataAnnotations;

namespace HealthCare.Models.Requests
{
    public class HealthRecordCreate
    {
        [Required]
        public int TelegramUserId { get; set; }
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
