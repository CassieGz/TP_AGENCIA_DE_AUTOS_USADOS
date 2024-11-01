using System;
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
                string[] datos = cadena.Split(',');
               

                error = int.TryParse(datos[0], out ignoreMe);

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
            Console.WriteLine("┌─────────────┬───────────────────────────────────┐");
            Console.WriteLine("│ ID          │ SEGMENTO                          │");
            Console.WriteLine("└─────────────┴───────────────────────────────────┘");
            for (int i = 0; i < Math.Min(3, this.segments.Count); i++)
            {
                Console.WriteLine($"{segments[i].Id_Segmento} {segments[i].NombreSeg}");
            }

        }

        //CRUD Segmento
        //Agregar/carga manual segmento
        public void AgregarSegmento()
        {
            Console.Clear();
            Console.WriteLine("\nCRUD - AGREGAR\n");
            int id;
            string nombreSg;

            Console.WriteLine("Ingrese un id o código único");
            id = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese nombre del nuevo segmento");

            nombreSg = Console.ReadLine();

            Segmento nuevoSeg = new Segmento(id, nombreSg);
            this.segments.Add(nuevoSeg);

        }

        public void ListarSegmento()
        {
            Console.WriteLine("\nSEGMENTOS\n");
            foreach (Segmento Segment in this.segments)
            {
                Segment.MostrarSegmentos();
            }
        }

        public void ActualizarSegmento()
        {
            Console.WriteLine("\nCRUD - ACTUALIZAR\n");

            Console.WriteLine("Ingrese el id del segmento a modificar");

            int idIngresado = int.Parse(Console.ReadLine());
            string nuevoNombre;
            bool idEncontrado = false;

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
                FileStream Archivo = new FileStream("segmentos.xlsx", FileMode.Create);
                StreamWriter Escribir = new StreamWriter(Archivo);

                foreach (Segmento item in this.segments)
                {
                    Escribir.WriteLine(item.Id_Segmento + " " + item.NombreSeg);
                }
            }

        }

        public void EliminarSegmento()
        {
            Console.Clear();
            Console.WriteLine("\nCRUD - ELIMINAR\n");

            Console.WriteLine("Ingrese el id(código único) del segmento que quiere eliminar");

            int cod_ingresado = int.Parse(Console.ReadLine());

            for (int i = 0; i < this.segments.Count; i++)
            {
                if (cod_ingresado == this.segments[i].Id_Segmento)
                {
                    this.segments.RemoveAt(i);
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
            }
        }

        public void ListarCombustibles()
        {
            Console.WriteLine("\nCOMBUSTIBLES\n");
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
            }

            Archivo.Close();
            Leer.Close();
        }

        public void ListarProvincias()
        {
            Console.WriteLine("\nPROVINCIAS\n");

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
            }

            Archivo.Close();
            Leer.Close();
        }

        public void ListarLocalidades()
        {
            Console.WriteLine("\nLOCALIDADES\n");

            foreach (Localidad item in this.localidades)
            {
                item.MostrarLocalidades();
            }
        }
    }
}

