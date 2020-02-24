using System.Collections.Generic;

namespace HealthCare.Models
{
    public class TelegramUser
    {
        public int Id { get; set; }

        // telegram user id
        public int UserId { get; set; }
        public List<HealthRecord> HealthRecords { get; set; }
    }
}
