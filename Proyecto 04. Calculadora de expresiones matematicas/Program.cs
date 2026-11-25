using System;

namespace Practica4_Calculadora
{
    internal class Program
    {
        // Define la jerarquía o prioridad de los operadores matemáticos
        static int Prioridad(char operador)
        {
            if (operador == '+' || operador == '-')
                return 1; // Menor prioridad

            if (operador == '*' || operador == '/' || operador == '%')
                return 2; // Prioridad media

            if (operador == '^')
                return 3; // Mayor prioridad (exponente)

            return 0;
        }

        // Convierte una expresión matemática normal (Infija) a notación Postfija
        static string InfijaAPostfija(string expresion)
        {
            Pila pila = new Pila(); // Pila para almacenar temporalmente los operadores
            string salida = "";     // Cadena donde se va construyendo el resultado postfijo

            for (int i = 0; i < expresion.Length; i++)
            {
                char caracter = expresion[i];

                if (caracter == ' ') continue; // Ignora los espacios en blanco

                // Si el carácter es un dígito, extrae el número completo (puede ser de varios dígitos)
                if (char.IsDigit(caracter))
                {
                    string numero = "";
                    while (i < expresion.Length && char.IsDigit(expresion[i]))
                    {
                        numero += expresion[i];
                        i++;
                    }
                    i--; // Retrocede una posición para no saltarse el siguiente carácter
                    salida += numero + " "; // Añade el número a la salida con un espacio
                }
                else if (caracter == '(')
                {
                    pila.Apilar(caracter); // Si abre paréntesis, lo apila directamente
                }
                else if (caracter == ')')
                {
                    // Si cierra paréntesis, desapila operadores hasta encontrar el '(' correspondiente
                    while (!pila.Vacia() && pila.Tope() != '(')
                    {
                        salida += pila.Desapilar() + " ";
                    }
                    pila.Desapilar(); // Elimina el paréntesis '(' de la pila
                }
                else if ("+-*/%^".Contains(caracter))
                {
                    // Desapila operadores mientras tengan mayor o igual prioridad que el actual
                    while (!pila.Vacia() && Prioridad(pila.Tope()) >= Prioridad(caracter))
                    {
                        salida += pila.Desapilar() + " ";
                    }
                    pila.Apilar(caracter); // Apila el operador actual
                }
            }

            // Vacía los operadores restantes que hayan quedado en la pila
            while (!pila.Vacia())
            {
                salida += pila.Desapilar() + " ";
            }

            return salida.Trim(); // Retorna la expresión postfija limpia de espacios al final
        }

        // Función pendiente para evaluar el resultado de la expresión postfija
        static double EvaluarPostfija(string postfija)
        {
            return 0;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese la expresion infija: ");
            string expresion = Console.ReadLine(); // Lee la expresión ingresada por el usuario

            string postfija = InfijaAPostfija(expresion); // Realiza la conversión
            Console.WriteLine($"Postfija: {postfija}");   // Muestra el resultado en consola

            Console.ReadKey();
        }
    }
}
