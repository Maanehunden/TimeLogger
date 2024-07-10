using System;

namespace Timelogger.Api.DTOs
{
    public class ProjectDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Deadline { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; } // This could be useful to display customer information
    }
}       
