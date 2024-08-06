using TestApi.Exceptions;
using TestApi.Tarea.Models;
using TestApi.Tarea.Repositories;

namespace TestApi.Tarea.Services;

public class TareaService(ITareaRepository tareaRepository) : ITareaService
{
    public async Task<IEnumerable<TareaResponseDto>> GetAllTasks() =>
        await tareaRepository.GetAllTasks();

    public async Task<TareaResponseDto> GetTaskById(int id)
    {
        var task = await tareaRepository.GetTaskById(id);
        
        if (task is null)
            throw new EntityNotFoundException("Task not found");
        
        return task;
    }

    public async Task CreateTask(TareaCreateRequestDto task)
    {
        await tareaRepository.CreateTask(task);
    }

    public async Task UpdateTask(int id, TareaUpdateRequestDto task)
    {
        var existingTask = await tareaRepository.GetTaskById(id);
        
        if (existingTask is null)
            throw new EntityNotFoundException("Task not found");
        
        // TODO: Implement validation for duplicated task names
        
        await tareaRepository.UpdateTask(id, task);
    }
}