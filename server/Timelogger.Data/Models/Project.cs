using System;

namespace Timelogger.Data.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public DateTime Deadline { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }
}
