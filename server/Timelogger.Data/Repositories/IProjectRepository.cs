using System.Collections.Generic;
using System.Threading.Tasks;
using Timelogger.Data.Models;

namespace Timelogger.Data.Repositories
{
    public interface IProjectRepository
    {
        Task<IEnumerable<Project>> GetProjectsAsync();
        Task<Project> GetProjectByIdAsync(int id);
        Task AddProjectAsync(Project project);
        Task UpdateProjectAsync(Project project);
        Task DeleteProjectAsync(int id);
    }
}
