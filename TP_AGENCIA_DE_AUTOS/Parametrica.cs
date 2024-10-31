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
        //-------------------------MARCAS-------------------------
        public void CargarMarcas()
        {
            //FileStream Archivo= new FileStream("")
        }

        public void ListarMarcas()
        {
            Console.WriteLine("\nMARCAS\n");
            foreach (Marca item in this.marcas)
            {
                item.MostrarMarcas();
            }
        }

        //CRUD MARCAS
        //Agregar/carga manual marca
        public void AgregarMarca()
        {
            Console.Clear();
            Console.WriteLine("\nCRUD - AGREGAR\n");
            int id_marca;
            string nombreMarca;

            Console.WriteLine("Ingrese un id o código númerico para la marca a agregar");
            id_marca = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese nombre de la marca que desea agregar");

            nombreMarca = Console.ReadLine();

            Marca nuevaMarca = new Marca(id_marca, nombreMarca);
            this.marcas.Add(nuevaMarca);

        }

        public void ActualizarMarca()
        {
            Console.WriteLine("\nCRUD - ACTUALIZAR\n");

            Console.WriteLine("Ingrese el id de la marca que desea modificar");

            int idIngresado = int.Parse(Console.ReadLine());
            string nombreAct;
            bool idEncontrado = false;

            foreach (Marca item in this.marcas)
            {
                if (idIngresado == item.Id_marca)
                {
                    Console.WriteLine("Ingrese el nuevo nombre de la marca que desea actualizar");
                    nombreAct = Console.ReadLine();

                    item.Marc = nombreAct;
                    idEncontrado = true;

                }

            }

            if (idEncontrado == true)
            {
                FileStream Archivo = new FileStream("MARCAS.xlsx", FileMode.Create);
                StreamWriter Escribir = new StreamWriter(Archivo);

                foreach (Marca item in this.marcas)
                {
                    Escribir.WriteLine(item.Id_marca + " " + item.Marc);
                }
            }

        }

        public void EliminarMarca()
        {
            Console.Clear();
            Console.WriteLine("\nCRUD - ELIMINAR\n");

            Console.WriteLine("Ingrese el id(código único) de la marca que quiere eliminar");

            int cod_ingresado = int.Parse(Console.ReadLine());

            for (int i = 0; i < this.marcas.Count; i++)
            {
                if (cod_ingresado == this.marcas[i].Id_marca)
                {
                    this.marcas.RemoveAt(i);
                }
            }
        }

        //-------------------------SEGMENTOS-------------------------
        public void CargarSegmentos()
        {
            FileStream Archivo = new FileStream("SEGMENTOS.xlsx", FileMode.Open);
            StreamReader Leer = new StreamReader(Archivo);

            while (!Leer.EndOfStream)
            {
                string cadena = Leer.ReadLine();
                string[] datos = cadena.Split(',');
                Segmento Segment = new Segmento(int.Parse(datos[0]), datos[1]);
                this.segments.Add(Segment); 
            }

            for (int i = 0; i < Math.Min(2, this.segments.Count); i++)
            {
                Console.WriteLine("ID Segmento[0] Segmento",)
            }   

            Archivo.Close();
            Leer.Close();
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
            FileStream Archivo = new FileStream("COMBUSTIBLES.xlsx", FileMode.Open);
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
            FileStream Archivo = new FileStream("PROVINCIAS.xlsx", FileMode.Open);
            StreamReader Leer = new StreamReader(Archivo);

            while (!Leer.EndOfStream)
            {
                string cadena = Leer.ReadLine();
                string[]datos = cadena.Split(';');
                Provincia pcia = new Provincia(int.Parse(datos[0]), datos[1]);
            }

            Archivo.Close();    
            Leer.Close();   
        }

        public void ListarProvincias()
        {
            Console.WriteLine("\nPROVINCIAS\n");

            foreach(Provincia item in this.pcias)
            {
                item.MostrarProvincias();   
            }
        }

        //-------------------------LOCALIDADES-------------------------
        public void CargarLocalidades()
        {
            FileStream Archivo = new FileStream("LOCALIDADES.xlsx", FileMode.Open);
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


        //PROPIEDADES PUBLICAS
    }
}

