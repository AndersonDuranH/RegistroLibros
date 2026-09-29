using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroLibro.Models;

public class Prestamos
{
    [Key]
    public int PrestamoId { get; set; }

    [Required(ErrorMessage = "Debe seleccionar un estudiante.")]
    [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un estudiante valido.")]
    public int EstudianteId { get; set; }

    [ForeignKey("EstudianteId")]
    public virtual Estudiante? Estudiante { get; set; }

    [Required(ErrorMessage = "Debe seleccionar un libro.")]
    [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un libro valido.")]
    public int LibroId { get; set; }

    [ForeignKey("LibroId")]
    public virtual Libros? Libro { get; set; }

    [Required(ErrorMessage = "Es necesario ingresar la fecha del prestamo.")]
    public DateTime FechaPrestamo { get; set; } = DateTime.Today;

    [Required(ErrorMessage = "Es necesario ingresar la fecha estimada de devolucion.")]
    public DateTime FechaDevolucion { get; set; } = DateTime.Today.AddDays(7);

    [Required(ErrorMessage = "Es necesario ingresar el concepto u observaciones.")]
    public string Concepto { get; set; } = string.Empty;
}
