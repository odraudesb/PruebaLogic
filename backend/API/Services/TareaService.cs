using Core.Interfaces;
using System.Threading;
using Core.Models;
namespace API.Services
{
    public class TareaService
    {
        private readonly ITareaRepository _tareaRepository;

        public TareaService(ITareaRepository tareaRepository)
        {
            _tareaRepository = tareaRepository;
        }

        public async Task<IEnumerable<Tarea>> GetAllTareasAsync() => await _tareaRepository.GetAll();
        public async Task<Tarea> GetTareaByIdAsync(int id) => await _tareaRepository.GetById(id);
        public async Task AddTareaAsync(Tarea tarea) => await _tareaRepository.Add(tarea);
        public async Task UpdateTareaAsync(Tarea tarea) => await _tareaRepository.Update(tarea);
        public async Task DeleteTareaAsync(int id) => await _tareaRepository.Delete(id);
    }

}
