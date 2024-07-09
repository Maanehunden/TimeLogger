using System.Collections.Generic;
using System.Threading.Tasks;
using Timelogger.Api.DTOs;

namespace Timelogger.Api.Services
{
    public interface IProjectService
    {
        Task<IEnumerable<ProjectDTO>> GetProjectsAsync();
        Task<ProjectDTO> GetProjectByIdAsync(int id);
        Task AddProjectAsync(ProjectDTO project);
        Task UpdateProjectAsync(ProjectDTO project);
        Task DeleteProjectAsync(int id);
    }
}
