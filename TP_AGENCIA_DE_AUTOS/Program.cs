using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TP_AGENCIA_DE_AUTOS
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.CursorVisible = false;
            int anchoConsola = Console.WindowWidth;

            Console.WriteLine("\n");
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Animar(175, " AGENCIA DE VEHÍCULOS USADOS\n");
            Console.ResetColor();
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Gray;

            CentrarAscii("██████╗██╗ ██████╗██╗      ██████╗  ██████╗ █████╗ ██████╗", anchoConsola);
            CentrarAscii("██╔════╝██║██╔════╝██║     ██╔═══██╗██╔════╝██╔══██╗██╔══██╗", anchoConsola);
            CentrarAscii("██║     ██║██║     ██║     ██║   ██║██║     ███████║██████╔╝", anchoConsola);
            CentrarAscii("██║     ██║██║     ██║     ██║   ██║██║     ██╔══██║██╔══██╗", anchoConsola);
            CentrarAscii("╚██████╗██║╚██████╗███████╗╚██████╔╝╚██████╗██║  ██║██║  ██║", anchoConsola);
            CentrarAscii("╚═════╝╚═╝ ╚═════╝╚══════╝ ╚═════╝  ╚═════╝╚═╝  ╚═╝╚═╝  ╚═╝", anchoConsola);

            Console.WriteLine("\n");

            Console.WriteLine("                      ___..............._\r\n             __.. ' _'.\"\"\"\"\"\"\\\\\"\"\"\"\"\"\"\"- .`-._\r\n ______.-'         (_) |      \\\\           ` \\\\`-. _\r\n/_       --------------'-------\\\\---....______\\\\__`.`  -..___\r\n| T      _.----._           Xxx|x...           |          _.._`--. _\r\n| |    .' ..--.. `.         XXX|XXXXXXXXXxx==  |       .'.---..`.     -._\r\n\\_j   /  /  __  \\  \\        XXX|XXXXXXXXXXX==  |      / /  __  \\ \\        `-.\r\n _|  |  |  /  \\  |  |       XXX|\"\"'            |     / |  /  \\  | |          |\r\n|__\\_j  |  \\__/  |  L__________|_______________|_____j |  \\__/  | L__________J\r\n     `'\\ \\      / ./__________________________________\\ \\      / /___________\\\r\n        `.`----'.'                                     `.`----'.'\r\n          `\"\"\"\"'                                         `\"\"\"\"'");

            Console.WriteLine("\n");

            Deslizar("BIENVENIDO!");

            //MENU PRINCIPAL
            string[] Menu = { "Vehículos\n", "Clientes\n", "Ventas\n", "Paramétricas\n", "Salir" };

            int posicion = 0; //posición actual

            Console.CursorVisible = false;
            ConsoleKeyInfo tecla;
            bool bucle = true;

            while (bucle)
            {
                Console.Clear();
                Console.ResetColor();
                Console.WriteLine("┌─────────────────────────────────────────────────────┐");
                Console.WriteLine("│ MENU PRINCIPAL                                      │");
                Console.WriteLine("├─────────────────────────────────────────────────────┤");
                Console.WriteLine("│ Seleccione una opción con las flechas ↓ y ↑         │");
                Console.WriteLine("└─────────────────────────────────────────────────────┘");

                //armado de menu
                for (int i = 0; i < Menu.Length; i++)
                {
                    if (posicion == i)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(" " + (char)62 + " ");
                    }
                    else
                    {
                        Console.Write("  ");
                    }

                    Console.Write(Menu[i]);
                    Console.ResetColor();
                }
                Console.Write("\n");
                //Console.WriteLine("───────────────────────────────────────────────");

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

                        if (posicion == Menu.Length - 1) //salir del menú
                        {
                            bucle = false;
                        }
                        else
                        {
                            //Se especifica procedimiento/método de la posición
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine("\nSeleccionaste " + Menu[posicion]);
                            Console.ResetColor();
                            Console.ReadKey();


                            //Instancio la clase program para usar métodos
                            Program instanciaProg = new Program();

                            switch (Menu[posicion].Trim())
                            {
                                case "Vehículos":
                                    instanciaProg.MostrarSubMenu(Menu[posicion].Trim());
                                    break;
                                case "Clientes":
                                    instanciaProg.MostrarSubMenu(Menu[posicion].Trim());

                                    break;
                                case "Ventas":
                                    instanciaProg.MostrarSubMenu(Menu[posicion].Trim());

                                    break;
                                case "Paramétricas":
                                    instanciaProg.MostrarSubmenuParametricas();     
                                    break;
                                default:
                                    Console.WriteLine("Opción inválida");
                                    break;
                            }
                        }


                        break;


                }

            }

            Console.ReadKey();
        }


        //METODOS PARA SUBMENÚES
        //Submenu vehículos, clientes y ventas
        public void MostrarSubMenu(string opcion)// recibo el parámetro enviado
        {
            string[] CRUD = { "Agregar ", "Listar ", "Actualizar ", "Eliminar ", "Volver\n" };
            int posicion = 0;

            Console.CursorVisible = false;
            ConsoleKeyInfo tecla;
            bool bucleCrud = true;

            while (bucleCrud)
            {
                Console.Clear();
                Console.ResetColor();
                Console.WriteLine("┌─────────────────────────────────────────────────────┐");
                Console.WriteLine("│ Submenú                                             │");
                Console.WriteLine("└─────────────────────────────────────────────────────┘");
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" CRUD " + opcion.ToUpper());
                Console.ResetColor();
                Console.WriteLine("┌─────────────────────────────────────────────────────┐");
                Console.WriteLine("│ Seleccione una opción con las flechas ← y →         │");
                Console.WriteLine("└─────────────────────────────────────────────────────┘");

                for (int i = 0; i < CRUD.Length; i++)
                {
                    if (posicion == i)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(" → ");
                    }
                    else
                    {
                        Console.Write("  ");
                    }


                    Console.Write(CRUD[i]);
                    Console.ResetColor();
                }

                tecla = Console.ReadKey();

                //manejo de opciones con las flechas y color en la posición actual
                switch (tecla.Key)
                {
                    case ConsoleKey.LeftArrow:
                        posicion = Math.Max(0, posicion - 1);
                        break;

                    case ConsoleKey.RightArrow:
                        posicion = Math.Min(CRUD.Length - 1, posicion + 1);
                        break;

                    case ConsoleKey.Enter:
                    case ConsoleKey.Spacebar:

                        if (posicion == CRUD.Length - 1) //volver mwnu principal
                        {
                            bucleCrud = false;
                        }
                        else
                        {
                            //A los fines prácticos ---para borrar
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine("\nSeleccionaste " + CRUD[posicion]);
                            Console.ResetColor();
                            Console.ReadKey();

                            string valor = CRUD[posicion];
<<<<<<< HEAD
                            Ventas ventas = new Ventas();
=======
                            Venta ventas =new Venta();
>>>>>>> 6e059d3209407c669410ca66a0362683fd961a30


                            Vehiculo oVehiculo = new Vehiculo(0, " ", 0, 2000, 1, " ", 1, 1, 5000, "NO", " - ", "Rojo");

                            oVehiculo.Carga();


                            switch (opcion)
                            {
                                case "Vehículos":

                                    switch (valor)
                                    {
                                        //-----HACER PARA CADA VEHICULO-----
                                        case "Agregar":
                                            oVehiculo.Agregar();
                                            break;
                                        case "Listar":
                                            oVehiculo.Leer();
                                            break;
                                        case "Actualizar":
                                            oVehiculo.Actualizar();
                                            break;
                                        case "Eliminar":
                                            oVehiculo.Eliminar();
                                            break;
                                        default:
                                            Console.WriteLine("Opción inválida");
                                            break;
                                    }
                                    break;

                                case "Clientes":
                                    //aca cargar lista
<<<<<<< HEAD
=======
                                    List<Cliente> listaCliente = new List<Cliente>();
                                    Cliente oCliente = new Cliente(); 
>>>>>>> 6e059d3209407c669410ca66a0362683fd961a30

                                    switch (valor)
                                    {
                                        case "Agregar":
                                            //metodo agregar de clientes
<<<<<<< HEAD

                                            break;
                                        case "Listar":

                                            break;
                                        case "Actualizar":
                                            //metodo actualizar de clientes

                                            break;
                                        case "Eliminar":
                                            //metodo eliminar de clientes

=======
                                            oCliente.AgregarClientes();
                                            break;
                                        case "Listar":
                                            oCliente.ListarClientes();
                                            break;
                                        case "Actualizar":
                                            //metodo actualizar de clientes
                                            Console.WriteLine("Ingrese ID del cliente a actualizar:");
                                            int idClienteActualizar = int.Parse(Console.ReadLine());
                                            oCliente.ActualizarCliente(idClienteActualizar);
                                            break;
                                        case "Eliminar":
                                            //metodo eliminar de clientes
                                            Console.WriteLine("Ingrese ID del cliente a eliminar:");
                                            int idClienteEliminar = int.Parse(Console.ReadLine());
                                            oCliente.EliminarClientes(idClienteEliminar);
>>>>>>> 6e059d3209407c669410ca66a0362683fd961a30
                                            break;
                                        default:
                                            Console.WriteLine("Opción inválida");
                                            break;
                                    }
                                    break;

                                case "Venta":
                                    //aca cargar lista
<<<<<<< HEAD

=======
                                    List<Venta> listaVenta = new List<Venta>();
                                    Venta oVenta = new Venta();
>>>>>>> 6e059d3209407c669410ca66a0362683fd961a30
                                    switch (valor)
                                    {
                                        case "Agregar":
                                            //metodo agregar de ventas
                                            oVenta.Agregarventa();
                                            break;
                                        case "Listar":
                                            oVenta.Listarventa();
                                            break;
                                        case "Actualizar":
                                            //metodo actualizar de ventas
<<<<<<< HEAD
                                            // ventas.Actualizarventas();
                                            break;
                                        case "Eliminar":
                                            //metodo eliminar de ventas
                                            //ventas.EliminarVentas();
=======
                                            Console.WriteLine("Ingrese ID de la venta a actualizar:");
                                            int idVentaActualizar = int.Parse(Console.ReadLine());
                                            oVenta.Actualizarventa(idVentaActualizar);
                                            break;
                                        case "Eliminar":
                                            //metodo eliminar de ventas
                                            Console.WriteLine("Ingrese ID de la venta a eliminar:");
                                            int idVentaEliminar = int.Parse(Console.ReadLine());
                                            oVenta.EliminarVenta(idVentaEliminar); 
>>>>>>> 6e059d3209407c669410ca66a0362683fd961a30
                                            break;
                                            
                                        default:
                                            Console.WriteLine("Opción inválida");
                                            break;
                                    }
                                    break;

                            }

                        }
                        break;
                }


            }

        }

        //Submenú Paramétricas
        public void MostrarSubmenuParametricas()
        {
            string[] SubMenuParametricas = { "Marcas\n", "Segmentos\n", "Combustibles\n", "Provincias\n", "Localidades\n", "Volver\n" };
            int posicion = 0; //posición actual

            Console.CursorVisible = false;
            ConsoleKeyInfo tecla;
            bool bucleSubmenuParaMetricas = true;

            while (bucleSubmenuParaMetricas)
            {
                Console.Clear();
                Console.ResetColor();
                Console.WriteLine("┌─────────────────────────────────────────────────────┐");
                Console.WriteLine("│ Submenú paramétricas                                │");
                Console.WriteLine("├─────────────────────────────────────────────────────┤");
                Console.WriteLine("│ Seleccione una opción con las flechas ↓ y ↑         │");
                Console.WriteLine("└─────────────────────────────────────────────────────┘");

                //armado de submenu
                for (int i = 0; i < SubMenuParametricas.Length; i++)
                {
                    if (posicion == i)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(" " + (char)62 + " ");
                    }
                    else
                    {
                        Console.Write("  ");
                    }


                    Console.Write(SubMenuParametricas[i]);
                    Console.ResetColor();
                }
                //Console.WriteLine("\n──────────────────────────────────────────────");

                tecla = Console.ReadKey();

                //manejo de opciones con las flechas y color en la posición actual
                switch (tecla.Key)
                {
                    case ConsoleKey.UpArrow:
                        posicion = Math.Max(0, posicion - 1);
                        break;

                    case ConsoleKey.DownArrow:
                        posicion = Math.Min(SubMenuParametricas.Length - 1, posicion + 1);
                        break;

                    case ConsoleKey.Enter:
                    case ConsoleKey.Spacebar:

                        if (posicion == SubMenuParametricas.Length - 1) //volver menu principal
                        {
                            bucleSubmenuParaMetricas = false;
                        }
                        else
                        {
                            //llamar al procedimiento/método de la posicion
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine("\nSeleccionaste " + SubMenuParametricas[posicion]);
                            Console.ResetColor();

                            string op = SubMenuParametricas[posicion].Trim();
                            Program progPara = new Program();
                            Parametrica parametric = new Parametrica();

                            //crud parametrica
                            switch (op)
                            {
                                case "Marcas":
                                    progPara.CrudParametricas(op);
                                    break;
                                case "Segmentos":
                                    progPara.CrudParametricas(op);
                                    break;
                                case "Combustibles":
                                    parametric.CargarCombustibles();
                                    parametric.ListarCombustibles();
                                    break;
                                case "Provincias":
                                    parametric.CargarProvincias();
                                    parametric.ListarProvincias();
                                    break;
                                case "Localidades":
                                    parametric.CargarLocalidades(); 
                                    parametric.ListarLocalidades();
                                    break;

                            }


                        }
                        Console.ReadKey();

                        break;
                }

            }



        }

        public void CrudParametricas(string eleccion)
        {
            string[] CRUD_Parametrica = { "Agregar ", "Listar ", "Actualizar ", "Eliminar ", "Volver\n" };
            int posicion = 0;

            Console.CursorVisible = false;
            ConsoleKeyInfo tecla;
            bool bucleCrud = true;

            while (bucleCrud)
            {
                Console.Clear();
                Console.ResetColor();
                Console.WriteLine("┌─────────────────────────────────────────────────────┐");
                Console.WriteLine("│ Submenú                                             │");
                Console.WriteLine("└─────────────────────────────────────────────────────┘");
                Console.BackgroundColor = ConsoleColor.DarkCyan;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(" CRUD PARAMÉTRICA " + eleccion.ToUpper());
                Console.ResetColor();
                Console.WriteLine("┌─────────────────────────────────────────────────────┐");
                Console.WriteLine("│ Seleccione una opción con las flechas ← y →         │");
                Console.WriteLine("└─────────────────────────────────────────────────────┘");

                for (int i = 0; i < CRUD_Parametrica.Length; i++)
                {
                    if (posicion == i)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(" → ");
                    }
                    else
                    {
                        Console.Write("  ");
                    }


                    Console.Write(CRUD_Parametrica[i]);
                    Console.ResetColor();
                }


                tecla = Console.ReadKey();

                //manejo de opciones con las flechas y color en la posición actual
                switch (tecla.Key)
                {
                    case ConsoleKey.LeftArrow:
                        posicion = Math.Max(0, posicion - 1);
                        break;

                    case ConsoleKey.RightArrow:
                        posicion = Math.Min(CRUD_Parametrica.Length - 1, posicion + 1);
                        break;

                    case ConsoleKey.Enter:
                    case ConsoleKey.Spacebar:

                        if (posicion == CRUD_Parametrica.Length - 1) //volver mwnu principal
                        {
                            bucleCrud = false;
                        }
                        else
                        {
                            //A los fines prácticos ---para borrar
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.WriteLine("\nSeleccionaste " + CRUD_Parametrica[posicion]);
                            Console.ResetColor();
                            Console.ReadKey();


                            string valor = CRUD_Parametrica[posicion].Trim();
                            Program objProg = new Program();
                            
                            //Marca oMarca = new Marca(1, " ");
                            //oMarca.CargarMarca();
                            switch (eleccion)
                            {
                                case "Marcas":

                                    //switch (valor)
                                    //{
                                    //    //-----HACER PARA CADA MARCA-----
                                    //    case "Agregar":
                                    //        oMarca.Agregar();
                                    //    break;
                                    //    case "Listar":
                                    //        oMarca.Leer();
                                    //    break;
                                    //    case "Actualizar":
                                    //        oMarca.Modificar();
                                    //    break;
                                    //    case "Eliminar":
                                    //        oMarca.Eliminar();
                                    //    break;
                                    //    default:
                                    //        Console.WriteLine("Opción inválida");
                                    //    break;
                                    //}
                                break;

                                case "Segmentos":
                                    objProg.CRUD_Seg(valor);
                                break;
                            }

                        }

                    break;
                }


            }
        }

        public void CRUD_Seg(string valor)
        {

            Parametrica p = new Parametrica();
            p.CargarSegmentos();

            switch (valor)
            {
                case "Agregar":
                    p.AgregarSegmento();
                    break;
                case "Listar":
                    p.ListarSegmentos();
                    Console.ReadLine();
                    break;
                case "Actualizar":
                    p.ActualizarSegmento();
                    break;
                case "Eliminar":
                    p.EliminarSegmento();
                    break;
                default:
                    Console.WriteLine("Opción i");
                    break;
            }

        }

        //METODOS FUERA DEL MAIN

        static void Animar(int velocidad, string cadena)
        {
            Console.CursorVisible = false;
            //centrado de titulo
            int anchoVentana = Console.WindowWidth;
            int largoCadena = cadena.Length;

            int espacios = (anchoVentana - largoCadena) / 2;

            //Centra el titulo. Espacios es el valor del eje x y cursorTop es el valor en el eje y(filas).
            Console.SetCursorPosition(espacios, Console.CursorTop);

            //animación
            for (int i = 0; i < cadena.Length; i++)
            {
                Console.Write(cadena[i]);
                Thread.Sleep(velocidad);
            }

        }

        //Mostrar dibujo

        static void CentrarAscii(string asciiArte, int anchoConsola)
        {
            Console.CursorVisible = false;
            int rellenoIzq = (anchoConsola - asciiArte.Length) / 2;

            //rellena con espacios
            for (int i = 0; i < rellenoIzq; i++)
            {
                Console.Write(" ");
            }

            Console.WriteLine(asciiArte);
        }

        static void Deslizar(string saludo)
        {
            Console.CursorVisible = false;

            byte b; //porque trabajo con valor pequeño y es mas eficiente.

            for (b = 0; b <= 90; b++)
            {
                Console.SetCursorPosition(b, 25);
                Console.WriteLine(" " + saludo);
                System.Threading.Thread.Sleep(50);
            }
        }

    }
}
