using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp88
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcion = 0;
            int[] fibonacci=new int[DimensionarArray()];
            Console.WriteLine($"Se dimensionó un array de {fibonacci.Length} posiciones");
            PresioneTecla();
            do
            {
                Console.Clear();
                Console.WriteLine("0-Salir");
                Console.WriteLine("1-Generar Términos");
                Console.WriteLine("2-Listado");
                Console.WriteLine("3-Estadísticas");
                IngresarOpcionMenu(ref opcion);
                switch (opcion)
                {
                    case 0:
                        break;
                    case 1:
                        GenerarTerminos(fibonacci);
                        break;
                    case 2:
                        Listar(fibonacci);
                        break;
                    case 3:
                        Estadisticas(fibonacci);
                        break;
                    default:
                        break;
                }

                if (opcion == 0)
                {
                    break;
                }
            } while (true);

        }

        private static void Listar(int[] fibonacci)
        {
            Console.Clear();
            foreach (var termino in fibonacci)
            {
                Console.WriteLine(termino.ToString().PadLeft(6,' '));
            }

            Console.ReadLine();
        }

        private static void GenerarTerminos(int[] fibonacci)
        {
            for (int i = 0; i < fibonacci.Length; i++)
            {
                fibonacci[i] = GenerarTerminoFibonacci(i);
            }
        }

        private static int GenerarTerminoFibonacci(int i)
        {
            if (i<2)
            {
                return i;//caso base
            }
            else
            {
                return GenerarTerminoFibonacci(i - 1) + GenerarTerminoFibonacci(i - 2);
            }
        }

        private static int DimensionarArray()
        {
            return new Random().Next(4, 20);
        }


        private static void Estadisticas(int[] fibonacci)
        {
            var cantidadPares = ObtenerCantidadPares(fibonacci);
            var cantidadImpares = ObtenerCantidadImpares(fibonacci);
            Console.WriteLine($"Cantidad de Pares..:{cantidadPares}");
            Console.WriteLine($"Cantidad de Impares:{cantidadImpares}");

            PresioneTecla();

        }

        private static int ObtenerCantidadImpares(int[] fibonacci) => fibonacci.Count(t => t % 2 != 0);

        private static int ObtenerCantidadPares(int[] fibonacci)
        {
            //var resultado = 0;
            //foreach (var termino in fibonacci)
            //{
            //    if (termino%2==0)
            //    {
            //        resultado++;
            //    }
            //}

            //return resultado;
            return fibonacci.Count(t => t % 2 == 0);
        }


        private static void PresioneTecla()
        {
            Console.WriteLine("Tarea finalizada <Enter> para continuar");
            Console.ReadLine();
        }


        private static void IngresarOpcionMenu(ref int opcion)
        {

            do
            {

                Console.Write("Ingrese una opción:");
                if (!int.TryParse(Console.ReadLine(), out opcion))
                {
                    Console.WriteLine("Opción mal ingresada");

                }
                else if (opcion < 0 || opcion > 3)
                {
                    Console.WriteLine("Opción fuera de rango [0-3]");
                }
                else
                {
                    break;
                }
            } while (true);
        }
    }
}

