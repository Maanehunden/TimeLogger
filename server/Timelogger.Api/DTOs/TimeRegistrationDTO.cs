using System;

namespace Timelogger.Api.DTOs
{
    public class TimeRegistrationDTO
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string ProjectName { get; set; } // Optional: If you want to display project name
        public DateTime Date { get; set; }
        public double Hours { get; set; }
    }
}
