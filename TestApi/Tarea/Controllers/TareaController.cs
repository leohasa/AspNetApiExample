using Microsoft.AspNetCore.Mvc;
using TestApi.Tarea.Models;
using TestApi.Tarea.Services;

namespace TestApi.Tarea.Controllers;

[Route("api/tareas")]
[ApiController]
public class TareaController(ITareaService tareaService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllTasks()
    {
        var tasks = await tareaService.GetAllTasks();
        return Ok(tasks);
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetTaskById(int id)
    {
        var task = await tareaService.GetTaskById(id);
        return Ok(task);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateTask(TareaCreateRequestDto task)
    {
        await tareaService.CreateTask(task);
        return Created();
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTask(int id, TareaUpdateRequestDto task)
    {
        await tareaService.UpdateTask(id, task);
        return NoContent();
    }
    
    
}