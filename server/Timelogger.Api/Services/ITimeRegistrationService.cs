using System.Collections.Generic;
using System.Threading.Tasks;
using Timelogger.Api.DTOs;
using Timelogger.Data.Models;

namespace ExampleProject.Services
{
    public interface ITimeRegistrationService
    {
        Task<IEnumerable<TimeRegistrationDTO>> GetTimeRegistrationsAsync();
        Task<TimeRegistrationDTO> GetTimeRegistrationByIdAsync(int id);
        Task AddTimeRegistrationAsync(TimeRegistrationDTO timeRegistration);
        Task UpdateTimeRegistrationAsync(TimeRegistrationDTO timeRegistration);
        Task DeleteTimeRegistrationAsync(int id);
    }
}