using System.ComponentModel.DataAnnotations;

namespace Jose_Estrella_P1_AP1.Models;

public class Ingresos
{
    [Key]
    public int IngresoId { get; set; }

    [Required(ErrorMessage = "Es obligatorio introducir una fecha.")]
    public DateTime Fecha { get; set; } = DateTime.Now;

    [Required(ErrorMessage = "Es obligatorio introducir un concepto.")]
    public string? Concepto { get; set; }

    [Required(ErrorMessage = "Es obligatorio introducir un monto.")]
    [Range(minimum: 0, maximum: double.MaxValue, ErrorMessage = "El monto debe ser mayor o igual a 0.")]
    public double Monto { get; set; }
}
