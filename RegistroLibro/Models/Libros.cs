using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RegistroLibro.Models;

    public class Libros
    {
        [Key]
        public int LibroId { get; set; }

        [Required(ErrorMessage = "Es necesario ingresar un titulo")]
        public string Titulo { get; set; } = null!;

        [Required(ErrorMessage = "Es necesario ingresar un autor")]

        public string Autor { get; set; } = null!;

        [Required(ErrorMessage = "Es necesario ingresar un año")]

        public int AnoPublicacion { get; set; }

    }

