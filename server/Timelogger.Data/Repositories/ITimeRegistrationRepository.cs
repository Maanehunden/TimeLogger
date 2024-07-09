using System.Collections.Generic;
using System.Threading.Tasks;
using Timelogger.Data.Models;

namespace Timelogger.Data.Repositories
{
    public interface ITimeRegistrationRepository
    {
        Task<IEnumerable<TimeRegistration>> GetTimeRegistrationsAsync();
        Task<TimeRegistration> GetTimeRegistrationByIdAsync(int id);
        Task AddTimeRegistrationAsync(TimeRegistration timeRegistration);
        Task UpdateTimeRegistrationAsync(TimeRegistration timeRegistration);
        Task DeleteTimeRegistrationAsync(int id);
    }
}
