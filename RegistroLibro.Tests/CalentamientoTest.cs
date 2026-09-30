using System;
using System.Collections.Generic;
using System.Text;

namespace RegistroLibro.Tests;

[Fact]
public void Sumar_DosNumeros_DebeRetornarResultadoCorrecto()
{
	var a = 10; var b = 20;     //Arrange
	var resultado = a + b;      // Act
	Assert.Equal(30, resultado);   // Assert
}