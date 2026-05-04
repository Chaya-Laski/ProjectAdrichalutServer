using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

public interface IBLInspiration
{
    Task<List<InspirationDto>> GetAllAsync();
    Task<InspirationDto> GetByIdAsync(int id);
    Task AddAsync(InspirationDto dto);
    Task UpdateAsync(InspirationDto dto);
    Task DeleteAsync(int id);
}

