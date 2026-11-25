using System;
using System.Collections.Generic;
using System.Text;

namespace Practica4_Calculadora
{
    public class Pila
    {
        private Nodo tope; // Apunta al elemento superior de la pila

        private class Nodo
        {
            public char Dato;       // Almacena el carácter (por ejemplo, operadores o paréntesis)
            public Nodo Siguiente;  // Puntero que apunta al nodo inferior en la pila

            public Nodo(char dato)
            {
                Dato = dato;     // Asigna el carácter recibido al nodo
                Siguiente = null; // Inicializa el siguiente como nulo
            }
        }

        public bool Vacia()
        {
            return tope == null; // Retorna true si el tope es nulo (pila vacía)
        }

        public void Apilar(char dato)
        {
            Nodo nuevo = new Nodo(dato); // Crea un nuevo nodo con el carácter
            nuevo.Siguiente = tope;      // El nuevo nodo apunta al antiguo tope
            tope = nuevo;                // El nuevo nodo se convierte en el nuevo tope
        }

        public char Desapilar()
        {
            if (Vacia())
                return '\0'; // Retorna un carácter nulo si la pila está vacía

            char dato = tope.Dato; // Guarda el dato que está en el tope
            tope = tope.Siguiente; // Mueve el tope al siguiente nodo (elimina el actual)

            return dato; // Retorna el carácter extraído
        }

        public char Tope()
        {
            if (Vacia())
                return '\0'; // Retorna un carácter nulo si la pila está vacía

            return tope.Dato; // Retorna el dato del tope sin eliminarlo
        }
    }
}