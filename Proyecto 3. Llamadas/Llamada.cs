using System;
namespace Proyecto3_PilaLlamadas
{
    public class Llamada
    {
        public string NombreFuncion { get; set; } // Almacena el nombre de la función simulada

        public Llamada(string nombreFuncion)
        {
            NombreFuncion = nombreFuncion; // Constructor para inicializar el objeto con el nombre de la función
        }

        public void Mostrar()
        {
            System.Console.Write($"{NombreFuncion}()"); // Método para imprimir el formato de la función en consola
        }
    }
}