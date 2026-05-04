using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public interface IBLMeeting
{
    Task<List<MeetingDto>> GetAllAsync();
    Task<MeetingDto> GetByIdAsync(int id);
    Task AddAsync(MeetingDto dto);
    Task UpdateAsync(MeetingDto dto);
    Task DeleteAsync(int id);
}

