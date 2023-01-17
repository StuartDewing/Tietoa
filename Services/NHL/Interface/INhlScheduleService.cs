using Tietoa.Domain.Models.Schedule;

namespace Services.NHL.Interface

{
    public interface INhlScheduleService
    {
        Task<List<ScheduleDto>> ScheduleRequest();
    }
}