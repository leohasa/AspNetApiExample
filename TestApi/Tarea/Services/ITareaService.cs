using TestApi.Tarea.Models;

namespace TestApi.Tarea.Services;

public interface ITareaService
{
    Task<IEnumerable<TareaResponseDto>> GetAllTasks();
    Task<TareaResponseDto> GetTaskById(int id);
    Task CreateTask(TareaCreateRequestDto task);
    Task UpdateTask(int id, TareaUpdateRequestDto task);
}