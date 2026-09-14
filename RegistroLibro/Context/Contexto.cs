using Microsoft.EntityFrameworkCore;
using RegistroLibro.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroLibro.Context;

    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {
        }

        public DbSet<Libros> Libros { get; set; }
    }
