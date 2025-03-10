using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Models;

namespace Core.Interfaces
{
    public interface ITareaRepository
    {
        Task<IEnumerable<Tarea>> GetAll();
        Task<Tarea> GetById(int id);
        Task Add(Tarea tarea);
        Task Update(Tarea tarea);
        Task Delete(int id);
    }

}
