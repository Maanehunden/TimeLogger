using System;

namespace Timelogger.Data.Models
{
    public class TimeRegistration
    {
        public int TimeRegistrationId { get; set; }
        public DateTime Date { get; set; }
        public double Hours { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public int Id { get; set; }
    }
}
