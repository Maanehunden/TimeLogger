using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Timelogger.Data.Models;

namespace Timelogger.Data.Repositories
{
    public class TimeRegistrationRepository : ITimeRegistrationRepository
    {
        private readonly IDbConnection _dbConnection;

        public TimeRegistrationRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<TimeRegistration>> GetTimeRegistrationsAsync()
        {
            var sql = "SELECT * FROM TimeRegistrations";
            return await _dbConnection.QueryAsync<TimeRegistration>(sql);
        }

        public async Task<TimeRegistration> GetTimeRegistrationByIdAsync(int id)
        {
            var sql = "SELECT * FROM TimeRegistrations WHERE Id = @Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<TimeRegistration>(sql, new { Id = id });
        }

        public async Task AddTimeRegistrationAsync(TimeRegistration timeRegistration)
        {
            var sql = "INSERT INTO TimeRegistrations (ProjectId, Date, Hours) VALUES (@ProjectId, @Date, @Hours)";
            await _dbConnection.ExecuteAsync(sql, timeRegistration);
        }

        public async Task UpdateTimeRegistrationAsync(TimeRegistration timeRegistration)
        {
            var sql = "UPDATE TimeRegistrations SET ProjectId = @ProjectId, Date = @Date, Hours = @Hours WHERE Id = @Id";
            await _dbConnection.ExecuteAsync(sql, timeRegistration);
        }

        public async Task DeleteTimeRegistrationAsync(int id)
        {
            var sql = "DELETE FROM TimeRegistrations WHERE Id = @Id";
            await _dbConnection.ExecuteAsync(sql, new { Id = id });
        }
    }
}
