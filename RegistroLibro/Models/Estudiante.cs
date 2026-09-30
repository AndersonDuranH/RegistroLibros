using System.ComponentModel.DataAnnotations;

namespace RegistroLibro.Models;

public class Estudiante
{
    [Key] public int EstudianteId { get; set; }
    [Required(ErrorMessage = "Es necesario ingresar El ID del estudiante")]
    public string Nombres { get; set; } = string.Empty;
    [Required(ErrorMessage = "Es necesario ingresar los nombres del estudiante")]
    public string Direccion { get; set; } = string.Empty;
    [Required(ErrorMessage = "Es necesario ingresar la direccion")]
    
    public string Email { get; set; } = string.Empty;
    [Required(ErrorMessage = "Es necesario ingresar el correo electrónico")]
    [EmailAddress(ErrorMessage = "Ingrese un correo electrónico valido")]

    public DateOnly? FechaNacimiento { get; set; }
}