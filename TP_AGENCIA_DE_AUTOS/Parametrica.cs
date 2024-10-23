using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TP_AGENCIA_DE_AUTOS
{
    internal class Parametrica
    {
        //PROPIEDADES PRIVADAS
        List<Segmento> segments;

        //CONSTRUCTORES
        public Parametrica()
        {
            List<Segmento> segmentos = new List<Segmento>();
        }

        //METODOS

        //SEGMENTO
        public void CargarSegmentos()
        {
            FileStream Archivo = new FileStream("segmentos.xlsx", FileMode.Open);
            StreamReader Leer = new StreamReader(Archivo);

            while (!Leer.EndOfStream)
            {
                string cadena = Console.ReadLine();
                string[] datos = cadena.Split(',');
                Segmento Segment = new Segmento(int.Parse(datos[0]), datos[1]);
            }

            Archivo.Close();
            Leer.Close();
        }

        public void GenerarReporte()
        {
            Console.WriteLine("\nSEGMENTOS\n");
            foreach (Segmento Segment in this.segments)
            {
                Segment.MostrarDatosSegmento();
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

        public void ActualizarSegmento()
        {
            Console.WriteLine("\nCRUD - ACTUALIZAR\n");

            Console.WriteLine("Ingrese el id del segmento a modificar");

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

        //PROPIEDADES PUBLICAS
    }
}
