using System.Data;
using Dapper;
using TestApi.Config;
using TestApi.Tarea.Models;

namespace TestApi.Tarea.Repositories;

public class TareaRepository(DapperContext context) : ITareaRepository
{
    private readonly DapperContext _context = context;


    public async Task<IEnumerable<TareaResponseDto>> GetAllTasks()
    {
        const string spName = "SP_TAREA_SELECT";
        
        using var connection = _context.CreateConnection();
        var tasks = await connection
            .QueryAsync<TareaResponseDto>(spName, commandType: CommandType.StoredProcedure);
        
        return tasks.ToList();
    }

    public async Task<TareaResponseDto> GetTaskById(int id)
    {
        const string spName = "SP_TAREA_SELECT_BY_ID";

        var parameters = new DynamicParameters();
        parameters.Add("id", id, DbType.Int32);
        
        using var connection = _context.CreateConnection();
        var task = await connection
            .QueryFirstOrDefaultAsync<TareaResponseDto>(spName, parameters, commandType: CommandType.StoredProcedure);
        
        return task;
    }

    public async Task CreateTask(TareaCreateRequestDto task)
    {
        const string spName = "SP_TAREA_INSERT";

        var parameters = new DynamicParameters();
        parameters.Add("titulo", task.Titulo, DbType.String);
        parameters.Add("detalle", task.Detalle, DbType.String);
        parameters.Add("fecha_hora", task.FechaHora, DbType.DateTime);
        
        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(spName, parameters, commandType: CommandType.StoredProcedure);
    }

    public async Task UpdateTask(int id, TareaUpdateRequestDto task)
    {
        const string spName = "SP_TAREA_UPDATE";

        var parameters = new DynamicParameters();
        parameters.Add("id", id, DbType.Int32);
        parameters.Add("titulo", task.Titulo, DbType.String);
        parameters.Add("detalle", task.Detalle, DbType.String);
        parameters.Add("fecha_hora", task.FechaHora, DbType.DateTime);
        parameters.Add("estado", task.Estado, DbType.Boolean);
        
        using var connection = _context.CreateConnection();
        await connection.ExecuteAsync(spName, parameters, commandType: CommandType.StoredProcedure);
    }
}