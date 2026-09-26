using System.ComponentModel.DataAnnotations;

namespace RegistroLibro.Models;

public class Estudiante
{
    [Key] public int EstudianteId { get; set; }
    [Required(ErrorMessage = "Es necesario ingresar los nombres")]
    public string Nombres { get; set; } = string.Empty;
    [Required(ErrorMessage = "Es necesario ingresar la dirección")]
    public string Direccion { get; set; } = string.Empty;
    [Required(ErrorMessage = "Es necesario ingresar el correo electrónico")]
    [EmailAddress(ErrorMessage = "Ingrese un correo electrónico válido")]
    public string Email { get; set; } = string.Empty;
    [Required(ErrorMessage = "Es necesario ingresar la fecha de nacimiento")]
    public DateOnly? FechaNacimiento { get; set; }
}