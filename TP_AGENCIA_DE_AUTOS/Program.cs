using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TP_AGENCIA_DE_AUTOS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Animar(200, "    AGENCIA DE AUTOS USADOS   \n");

            string[] Menu = { "Vehículos\n", "Clientes\n", "Ventas\n", "Paramétricas\n", "Salir" };

            int posicion = 0; //posición actual

            Console.CursorVisible = false;
            ConsoleKeyInfo tecla;
            bool bucle = true;

            while (bucle)
            {
                Console.Clear();
                Console.ResetColor();
                Console.WriteLine("MENU PRINCIPAL");
                Console.WriteLine("──────────────────────────────────────────────");
                Console.WriteLine("Seleccione una opción con las flechas ↓ y ↑");
                Console.WriteLine("──────────────────────────────────────────────");

                //armado de menu
                for (int i = 0; i < Menu.Length; i++)
                {
                    if (posicion == i)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkMagenta;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(" " + (char)62 + " ");
                    }
                    else
                    {
                        Console.Write(" ► ");
                    }

                    Console.Write(Menu[i]);
                    Console.ResetColor();
                }
                Console.WriteLine("\n──────────────────────────────────────────────");

                tecla = Console.ReadKey();

                //manejo de opciones con las flechas y color en la posicion actual
                switch (tecla.Key)
                {
                    case ConsoleKey.UpArrow:
                        posicion = Math.Max(0, posicion - 1);
                        break;

                    case ConsoleKey.DownArrow:
                        posicion = Math.Min(Menu.Length - 1, posicion + 1);
                        break;

                    case ConsoleKey.Enter:
                    case ConsoleKey.Spacebar:

                        if (posicion == Menu.Length - 1)
                        {
                            bucle = false;
                        }
                        else
                        {
                            //llamar al procedimiento/método de la posicion
                            Console.WriteLine("\n\nSeleccionaste " + Menu[posicion]);
                            Console.ReadKey();
                            
                        }

                    break;


                }

            }

            Console.ReadKey();
           
        }



        //método fuera del Main
        static void Animar(int velocidad, string cadena)
        {
            //animación
            for (int i = 0; i < cadena.Length; i++)
            {
                Console.Write(cadena[i]);
                Thread.Sleep(velocidad);
            }

            //centrado de titulo

            int anchoConsola = Console.WindowWidth;
            int largoCadena = cadena.Length;

            int espacios = (anchoConsola - largoCadena) / 2;

          //Centra el titulo. Espacios es el valor del eje x y la posicion actual del cursor es el eje y.
            Console.SetCursorPosition(espacios, Console.CursorTop);
        }

    }
}
