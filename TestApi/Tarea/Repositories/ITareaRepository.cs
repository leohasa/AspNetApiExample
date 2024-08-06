using TestApi.Config;
using TestApi.Tarea.Models;

namespace TestApi.Tarea.Repositories;

public interface ITareaRepository
{
    Task<IEnumerable<TareaResponseDto>> GetAllTasks();
    Task<TareaResponseDto> GetTaskById(int id);
    Task CreateTask(TareaCreateRequestDto task);
    Task UpdateTask(int id, TareaUpdateRequestDto task);
}