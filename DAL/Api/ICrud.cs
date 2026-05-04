//using DAL.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL.Api
{
    public interface ICrud<T>
    {
        Task Delete(int id);
        Task Update(T item);
        Task Add(T item);
        Task<T> GetById(int id);
        Task<List<T>> GetAll();
    }
}