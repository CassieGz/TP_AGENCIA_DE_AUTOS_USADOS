﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TP_AGENCIA_DE_AUTOS
{
    internal class Parametrica
    {
        //PROPIEDADES PRIVADAS
        List<Segmento> segments;
        List<Marca> marcas;
        List<Combustible> combustibles;
        List<Provincia> pcias;
        List<Localidad> localidades;

        //CONSTRUCTORES
        public Parametrica()
        {
            this.segments = new List<Segmento>();
            this.marcas = new List<Marca>();
            this.combustibles = new List<Combustible>();
            this.localidades = new List<Localidad>();
            this.pcias = new List<Provincia>();
        }

        //METODOS

        //-------------------------SEGMENTOS-------------------------
        public void CargarSegmentos()
        {
            FileStream Archivo = new FileStream("Segmentos.csv", FileMode.Open);
            StreamReader Leer = new StreamReader(Archivo);

            bool error;
            int ignoreMe;

            while (!Leer.EndOfStream)
            {

                string cadena = Leer.ReadLine();
                string[] datos = cadena.Split(';');

                //intenta convertir la primera ubicacion del vector a entero, guarda el rtdo en ignoreMw
                error = int.TryParse(datos[0], out ignoreMe);

                //si es entero agrega a la lista segmentos. Si no lo ignora
                if (error)
                {
                    Segmento Segment = new Segmento(ignoreMe, datos[1]);
                    this.segments.Add(Segment);
                }

            }

            Archivo.Close();
            Leer.Close();
        }

        public void Mostrar3seg()
        {
            Console.WriteLine("┌─────┬───────────────────────────────────┐");
            Console.WriteLine("│ ID  │ SEGMENTO                          │");
            Console.WriteLine("└─────┴───────────────────────────────────┘");
            for (int i = 0; i < Math.Min(3, this.segments.Count); i++)
            {
                Console.WriteLine($"{segments[i].Id_Segmento} {segments[i].NombreSeg}");
            }

        }

        //CRUD Segmento
        //Agregar/carga manual segmento
        public void AgregarSegmento()
        {
            string[] opcionesAct = { "CRUD Agregar\n", "<Volver\n" };
            ConsoleKeyInfo tecla;
            int indicePosic = 0;
            bool bucle = true;


            while (bucle)
            {
                Console.Clear();
                Console.WriteLine("Seleccione una opción con las flechas ↓ y ↑ del teclado");
                Console.WriteLine("────────────────────────────────────────────────────────");

                for (int i = 0; i < opcionesAct.Length; i++)
                {
                    if (indicePosic == i)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkCyan;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("");
                    }
                    else
                    {
                        Console.WriteLine(" ");
                    }

                    Console.Write(opcionesAct[i]);
                    Console.ResetColor();
                }

                tecla = Console.ReadKey();

                switch (tecla.Key)
                {

                    case ConsoleKey.UpArrow:
                        indicePosic = Math.Max(0, indicePosic - 1);
                        break;

                    case ConsoleKey.DownArrow:
                        indicePosic = Math.Min(opcionesAct.Length - 1, indicePosic + 1);
                        break;

                    case ConsoleKey.Spacebar:
                    case ConsoleKey.Enter:

                        if (indicePosic == opcionesAct.Length - 1)
                        {
                            bucle = false;
                        }
                        else
                        {
                            Console.Clear();
                            Console.BackgroundColor= ConsoleColor.DarkCyan;
                            Console.ForegroundColor= ConsoleColor.White;
                            Console.WriteLine("CRUD - AGREGAR\n");
                            Console.ResetColor();
                            int id;
                            string nombreSg;

                            Console.WriteLine("Ingrese un id o código único");
                            Console.CursorVisible = true;
                            id = int.Parse(Console.ReadLine());

                            Console.WriteLine("Ingrese nombre del nuevo segmento");

                            nombreSg = Console.ReadLine();

                            Segmento nuevoSeg = new Segmento(id, nombreSg);
                            this.segments.Add(nuevoSeg);

                        }
                        break;
                }
            }
        }

        public void ListarSegmentos()
        {
            Console.Clear();
            Console.WriteLine("SEGMENTOS\n");
            foreach (Segmento item in this.segments)
            {
                item.MostrarSegmentos();
            }
        }

        // ACTUALIZAR SEGMENTO
        public void ActualizarSegmento()
        {
          
            string[] opcionesAct = { "CRUD Actualizar\n", "<Volver\n" };
            ConsoleKeyInfo tecla;
            int indicePosic = 0;
            bool bucle = true;

           
            while (bucle)
            {
                Console.Clear();
                Console.WriteLine("Seleccione una opción con las flechas ↓ y ↑ del teclado");
                Console.WriteLine("────────────────────────────────────────────────────────");

                for (int i = 0; i<opcionesAct.Length; i++)
                {
                    if (indicePosic == i)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkCyan;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("");
                    }
                    else
                    {
                        Console.WriteLine(" ");
                    }

                    Console.Write(opcionesAct[i]);
                    Console.ResetColor();
                }

                tecla = Console.ReadKey();

                switch (tecla.Key)
                {

                    case ConsoleKey.UpArrow:
                        indicePosic = Math.Max(0, indicePosic-1);
                    break;

                    case ConsoleKey.DownArrow:
                        indicePosic = Math.Min(opcionesAct.Length-1,indicePosic+1);
                    break;

                    case ConsoleKey.Spacebar:
                    case ConsoleKey.Enter:

                        if (indicePosic == opcionesAct.Length - 1)
                        {
                            bucle = false;
                        }
                        else
                        {
                            
                            Console.WriteLine("\nIngrese el id del segmento a modificar");
                            Console.CursorVisible = true;
                            int idIngresado = int.Parse(Console.ReadLine());
                            string nuevoNombre;
                            bool idEncontrado=false;

                            foreach (Segmento item in this.segments)
                            {
                                if (idIngresado == item.Id_Segmento)
                                {
                                    Console.WriteLine("Ingrese el nuevo nombre para el segmento");
                                    nuevoNombre = Console.ReadLine();

                                    item.NombreSeg = nuevoNombre;
                                    idEncontrado = true;

                                }
                            }

                            if (idEncontrado == true)
                            {
                                FileStream Archivo = new FileStream("segmentos.csv", FileMode.Create);
                                StreamWriter Escribir = new StreamWriter(Archivo);

                                foreach (Segmento item in this.segments)
                                {
                                    Escribir.WriteLine(item.Id_Segmento + " " + item.NombreSeg);
                                }
                            }
                            else
                            {
                                Console.CursorVisible = false;
                                Console.BackgroundColor = ConsoleColor.DarkYellow;
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.WriteLine("\n»»» ID no encontrado. Ingrese un id válido ««« ");
                                Console.ReadKey();
                                Console.ResetColor();
                            }

                        }
                    break;

                }

            }
        }

        // ELIMINAR SEGMENTO
        public void EliminarSegmento()
        {
            string[] opcionesAct = { "CRUD Eliminar\n", "<Volver\n" };
            ConsoleKeyInfo tecla;
            int indicePosic = 0;
            bool bucle = true;


            while (bucle)
            {
                Console.Clear();
                Console.WriteLine("Seleccione una opción con las flechas ↓ y ↑ del teclado");
                Console.WriteLine("────────────────────────────────────────────────────────");

                for (int i = 0; i < opcionesAct.Length; i++)
                {
                    if (indicePosic == i)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkCyan;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("");
                    }
                    else
                    {
                        Console.WriteLine(" ");
                    }

                    Console.Write(opcionesAct[i]);
                    Console.ResetColor();
                }

                tecla = Console.ReadKey();

                switch (tecla.Key)
                {

                    case ConsoleKey.UpArrow:
                        indicePosic = Math.Max(0, indicePosic - 1);
                        break;

                    case ConsoleKey.DownArrow:
                        indicePosic = Math.Min(opcionesAct.Length - 1, indicePosic + 1);
                        break;

                    case ConsoleKey.Spacebar:
                    case ConsoleKey.Enter:

                        if (indicePosic == opcionesAct.Length - 1)
                        {
                            bucle = false;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("CRUD - ELIMINAR\n");

                            Console.WriteLine("Ingrese el id(código único) del segmento que quiere eliminar");
                            Console.CursorVisible = true;
                            int cod_ingresado = int.Parse(Console.ReadLine());

                            for (int i = 0; i < this.segments.Count; i++)
                            {
                                if (cod_ingresado == this.segments[i].Id_Segmento)
                                {
                                    this.segments.RemoveAt(i);
                                }
                            }
                        }
                        break;
                }
            }
        }

        //-------------------------COMBUSTIBLES-------------------------
        public void CargarCombustibles()
        {
            FileStream Archivo = new FileStream("Combustibles.csv", FileMode.Open);
            StreamReader Leer = new StreamReader(Archivo);

            while (!Leer.EndOfStream)
            {
                string cadena = Leer.ReadLine();
                string[] datos = cadena.Split(';');

                Combustible combustible = new Combustible(int.Parse(datos[0]), datos[1]);
                this.combustibles.Add(combustible);
            }
        }

        public void ListarCombustibles()
        {
            Console.Clear();
            Console.WriteLine("COMBUSTIBLES\n");
            foreach (Combustible item in this.combustibles)
            {
                item.MostrarCombustibles();
            }
        }

        //-------------------------PROVINCIAS-------------------------

        public void CargarProvincias()
        {
            FileStream Archivo = new FileStream("Provincias.csv", FileMode.Open);
            StreamReader Leer = new StreamReader(Archivo);

            while (!Leer.EndOfStream)
            {
                string cadena = Leer.ReadLine();
                string[] datos = cadena.Split(';');
                Provincia pcia = new Provincia(int.Parse(datos[0]), datos[1]);
                this.pcias.Add(pcia);
            }

            Archivo.Close();
            Leer.Close();
        }

        public void ListarProvincias()
        {
            Console.Clear();
            Console.WriteLine("PROVINCIAS\n");

            foreach (Provincia item in this.pcias)
            {
                item.MostrarProvincias();
            }
        }

        //-------------------------LOCALIDADES-------------------------
        public void CargarLocalidades()
        {
            FileStream Archivo = new FileStream("Localidades.csv", FileMode.Open);
            StreamReader Leer = new StreamReader(Archivo);

            while (!Leer.EndOfStream)
            {
                string cadena = Leer.ReadLine();
                string[] datos = cadena.Split(';');
                Localidad localidad = new Localidad(int.Parse(datos[0]), datos[1]);
                this.localidades.Add(localidad);
            }

            Archivo.Close();
            Leer.Close();
        }

        public void ListarLocalidades()
        {
            Console.Clear();
            Console.WriteLine("LOCALIDADES\n");

            foreach (Localidad item in this.localidades)
            {
                item.MostrarLocalidades();
            }
        }
    }
}

