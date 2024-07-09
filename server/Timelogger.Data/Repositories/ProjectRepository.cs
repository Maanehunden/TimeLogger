
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Timelogger.Data.Repositories;
using Timelogger.Data.Models;

namespace Timelogger.Data.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly IDbConnection _dbConnection;

        public ProjectRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<Project>> GetProjectsAsync()
        {
            var sql = "SELECT * FROM Projects";
            return await _dbConnection.QueryAsync<Project>(sql);
        }

        public async Task<Project> GetProjectByIdAsync(int id)
        {
            var sql = "SELECT * FROM Projects WHERE Id = @Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<Project>(sql, new { Id = id });
        }

        public async Task AddProjectAsync(Project project)
        {
            var sql = "INSERT INTO Projects (Name, Deadline, CustomerId) VALUES (@Name, @Deadline, @CustomerId)";
            await _dbConnection.ExecuteAsync(sql, project);
        }

        public async Task UpdateProjectAsync(Project project)
        {
            var sql = "UPDATE Projects SET Name = @Name, Deadline = @Deadline, CustomerId = @CustomerId WHERE Id = @Id";
            await _dbConnection.ExecuteAsync(sql, project);
        }

        public async Task DeleteProjectAsync(int id)
        {
            var sql = "DELETE FROM Projects WHERE Id = @Id";
            await _dbConnection.ExecuteAsync(sql, new { Id = id });
        }
    }
}

