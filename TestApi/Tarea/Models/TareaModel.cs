
using System.ComponentModel.DataAnnotations;

namespace TestApi.Tarea.Models;

public class TareaModel
{
    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Detalle { get; set; }
    public DateTime FechaHora { get; set; }
    public bool Estado { get; set; }
}

public record TareaCreateRequestDto(
    string Titulo,
    string? Detalle,
    DateTime FechaHora
);

public record TareaUpdateRequestDto
(
    string Titulo, 
    string? Detalle,
    DateTime FechaHora,
    bool Estado
);

public record TareaResponseDto
(
    int Id,
    string Titulo,
    string Detalle,
    DateTime FechaHora,
    bool Estado
);