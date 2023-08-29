using System;

namespace EjercicioUno
{
    internal class Program
    {
        static void Main(string[] args)
        {
            calculoUno();
        }
        static void calculoUno()
        {
            int cantidadNumeros = 5;
            int[] numeros = new int[cantidadNumeros];

            for (int i = 0; i < cantidadNumeros; i++)
            {
                Console.Write($"Ingrese el número {i + 1}: ");
                numeros[i] = int.Parse(Console.ReadLine());
            }

            int maximo = numeros[0];
            int minimo = numeros[0];
            int suma = numeros[0];

            for (int i = 1; i < cantidadNumeros; i++)
            {
                maximo = Math.Max(maximo, numeros[i]);
                minimo = Math.Min(minimo, numeros[i]);
                suma += numeros[i];
            }

            double promedio = (double)suma / cantidadNumeros;

            Console.WriteLine($"Valor máximo: {maximo}");
            Console.WriteLine($"Valor mínimo: {minimo}");
            Console.WriteLine($"Promedio: {promedio}");

        }

    }
}