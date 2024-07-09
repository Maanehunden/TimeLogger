using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using Timelogger.Api.DTOs;
using Timelogger.Data.Models;
using Timelogger.Data.Repositories;

namespace Timelogger.Api.Services
{

    public class TimeRegistrationService : ITimeRegistrationService
    {
        private readonly ITimeRegistrationRepository _timeRegistrationRepository;
        private readonly IMapper _mapper;

        public TimeRegistrationService(ITimeRegistrationRepository timeRegistrationRepository, IMapper mapper)
        {
            _timeRegistrationRepository = timeRegistrationRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TimeRegistrationDTO>> GetTimeRegistrationsAsync()
        {
            var timeRegistrations = await _timeRegistrationRepository.GetTimeRegistrationsAsync();
            return _mapper.Map<IEnumerable<TimeRegistrationDTO>>(timeRegistrations);
        }

        public async Task<TimeRegistrationDTO> GetTimeRegistrationByIdAsync(int id)
        {
            var timeRegistration = await _timeRegistrationRepository.GetTimeRegistrationByIdAsync(id);
            return _mapper.Map<TimeRegistrationDTO>(timeRegistration);
        }

        public async Task AddTimeRegistrationAsync(TimeRegistrationDTO timeRegistration)
        {
            var timeRegistrationEntity = _mapper.Map<TimeRegistration>(timeRegistration);
            await _timeRegistrationRepository.AddTimeRegistrationAsync(timeRegistrationEntity);
        }

        public async Task UpdateTimeRegistrationAsync(TimeRegistrationDTO timeRegistration)
        {
            var timeRegistrationEntity = _mapper.Map<TimeRegistration>(timeRegistration);
            await _timeRegistrationRepository.UpdateTimeRegistrationAsync(timeRegistrationEntity);
        }

        public async Task DeleteTimeRegistrationAsync(int id)
        {
            await _timeRegistrationRepository.DeleteTimeRegistrationAsync(id);
        }
    }
}
