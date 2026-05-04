using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public interface IBLWeeklySchedule
{
    Task<List<WeeklyScheduleDto>> GetAllAsync();
    Task<WeeklyScheduleDto> GetByIdAsync(int id);
    Task AddAsync(WeeklyScheduleDto dto);
    Task UpdateAsync(WeeklyScheduleDto dto);
    Task DeleteAsync(int id);
}
