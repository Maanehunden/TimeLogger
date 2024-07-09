using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Timelogger.Api.DTOs;
using Timelogger.Data.Models;
using Timelogger.Data.Repositories;

namespace Timelogger.Api.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public ProjectService(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProjectDTO>> GetProjectsAsync()
        {
            var projects = await _projectRepository.GetProjectsAsync();
            return _mapper.Map<IEnumerable<ProjectDTO>>(projects);
        }

        public async Task<ProjectDTO> GetProjectByIdAsync(int id)
        {
            var project = await _projectRepository.GetProjectByIdAsync(id);
            return _mapper.Map<ProjectDTO>(project);
        }

        public async Task AddProjectAsync(ProjectDTO project)
        {
            var projectEntity = _mapper.Map<Project>(project);
            await _projectRepository.AddProjectAsync(projectEntity);
        }

        public async Task UpdateProjectAsync(ProjectDTO project)
        {
            var projectEntity = _mapper.Map<Project>(project);
            await _projectRepository.UpdateProjectAsync(projectEntity);
        }

        public async Task DeleteProjectAsync(int id)
        {
            await _projectRepository.DeleteProjectAsync(id);
        }
    }
}
