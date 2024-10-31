using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_AGENCIA_DE_AUTOS
{
    
    class Marca
    {
        //prop priv
        private int id_marca;
        private string marc;
        public  List<Marca> Lista_MarcasAC = new List<Marca>();
        public List<Marca> Lista_MarcasMoto = new List<Marca>();
        public List<Marca> Lista_MarcasCamion = new List<Marca>();

        //constr
        public Marca(int id_marca, string marc)
        {
            this.Id_marca = id_marca;
            this.Marc = marc;
        }

        //CRUD

        public void CargarMarca()
        {
            
            FileStream Archivo = new FileStream("MarcasAC.xlsx", FileMode.Open);
            StreamReader Leer = new StreamReader(Archivo);

            while (!Leer.EndOfStream)
            {
                string cadena = Console.ReadLine();
                string[] datos = cadena.Split(';');
                Marca oMarca = new Marca(int.Parse(datos[0]), datos[1]);
                Lista_MarcasAC.Add(oMarca);
            }
            Archivo.Close();
            Leer.Close();

            FileStream Archi = new FileStream("MarcasMoto.xlsx", FileMode.Open);
            StreamReader Lee = new StreamReader(Archi);

            while (!Lee.EndOfStream)
            {
                string cadena = Console.ReadLine();
                string[] datos = cadena.Split(';');
                Marca oMarca = new Marca(int.Parse(datos[0]), datos[1]);
                Lista_MarcasMoto.Add(oMarca);
            }
            Archi.Close();
            Lee.Close();

            FileStream Archiv = new FileStream("MarcasCamion.xlsx", FileMode.Open);
            StreamReader Read = new StreamReader(Archiv);

            while (!Read.EndOfStream)
            {
                string cadena = Console.ReadLine();
                string[] datos = cadena.Split(';');
                Marca oMarca = new Marca(int.Parse(datos[0]), datos[1]);
                Lista_MarcasCamion.Add(oMarca);
            }
            Archiv.Close();
            Read.Close();
        }

        public void Grabar(string file,string grabar, List<Marca> vehiculos)
        {
            if (File.Exists(grabar))
            {
                
                File.Delete(grabar);
            }

            FileStream Archivo = new FileStream(file, FileMode.Create);
            StreamWriter Grabar = new StreamWriter(Archivo);

            foreach (Marca item in vehiculos)
            {
                Grabar.WriteLine($"{Id_marca};{Marc}");
            }

            Grabar.Close();
            Archivo.Close();
        }


        public void Leer()
        {
            Console.WriteLine("Marcas de Autos o camionetas");
            foreach (Marca oMarca in Lista_MarcasAC)
            {
                oMarca.MostrarDatos();
                Console.WriteLine(" ");
            }
            Console.WriteLine("Marcas de Motos");
            foreach (Marca oMarca in Lista_MarcasMoto)
            {
                oMarca.MostrarDatos();
                Console.WriteLine(" ");
            }
            Console.WriteLine("Marcas de Camiones");
            foreach (Marca oMarca in Lista_MarcasCamion)
            {
                oMarca.MostrarDatos();
                Console.WriteLine(" ");
            }
        }

   
        public void Agregar()       
        {
            Console.Clear();
            string respuesta;
            int nuevoId;
            int id_marc;
          
            {
                Console.WriteLine("Ingrese tipo de vehiculo a agregar la marca: auto, moto o camion.");
                respuesta = Console.ReadLine();

                if (respuesta.ToUpper() != "AUTO" && respuesta.ToUpper() != "MOTO" && respuesta.ToUpper() != "CAMION")
                {
                    Console.WriteLine("Ingrese un tipo de vehiculo valido. Pulse cualquier tecla para continuar.");
                    Console.ReadKey();
                }
            } while (respuesta.ToUpper() != "AUTO" && respuesta.ToUpper() != "MOTO" && respuesta.ToUpper() != "CAMION");

            if(respuesta.ToUpper()== "AUTO")
            {
                nuevoId = (Lista_MarcasAC.Count > 0) ? Lista_MarcasAC[Lista_MarcasAC.Count - 1].Id_marca + 1 : 1;
                id_marc = nuevoId;
                Console.WriteLine("Ingrese la nueva marca: ");
                string nombreMarca = Console.ReadLine();
                Marca oMarca = new Marca(id_marc, nombreMarca);
                Lista_MarcasAC.Add(oMarca);
                Grabar("MarcasAC.xlsx", "MarcasAC.xlsx", Lista_MarcasAC);
            }
            if (respuesta.ToUpper() == "MOTO")
            {
                nuevoId = (Lista_MarcasMoto.Count > 0) ? Lista_MarcasMoto[Lista_MarcasMoto.Count - 1].Id_marca + 1 : 1;
                id_marc = nuevoId;
                Console.WriteLine("Ingrese la nueva marca: ");
                string nombreMarca = Console.ReadLine();
                Marca oMarca = new Marca(id_marc, nombreMarca);
                Lista_MarcasMoto.Add(oMarca);
                Grabar("MarcasMoto.xlsx", "MarcasMoto.xlsx", Lista_MarcasMoto) ;
            }
            if (respuesta.ToUpper() == "CAMION")
            {
                nuevoId = (Lista_MarcasCamion.Count > 0) ? Lista_MarcasCamion[Lista_MarcasCamion.Count - 1].Id_marca + 1 : 1;
                id_marc = nuevoId;
                Console.WriteLine("Ingrese la nueva marca: ");
                string nombreMarca = Console.ReadLine();
                Marca oMarca = new Marca(id_marc, nombreMarca);
                Lista_MarcasCamion.Add(oMarca);
                Grabar("MarcasCamion.xlsx", "MarcasCamion.xlsx", Lista_MarcasCamion);
            }

        }

        public void Modificar()
        {
            Console.Clear();
            string respuesta;
            {
                Console.WriteLine("Ingrese tipo de vehiculo a modificar la marca: auto, moto o camion.");
                respuesta = Console.ReadLine();

                if (respuesta.ToUpper() != "AUTO" && respuesta.ToUpper() != "MOTO" && respuesta.ToUpper() != "CAMION")
                {
                    Console.WriteLine("Ingrese un tipo de vehiculo valido. Pulse cualquier tecla para continuar.");
                    Console.ReadKey();
                }
            } while (respuesta.ToUpper() != "AUTO" && respuesta.ToUpper() != "MOTO" && respuesta.ToUpper() != "CAMION") ;

            bool parsear, IdBool;
            int IdAModif;
            
            if (respuesta.ToUpper() == "AUTO")
            {
                do
                {
                    Console.Write("Ingrese el ID de la marca a modificar: ");
                    parsear = int.TryParse(Console.ReadLine(), out IdAModif);
                    IdBool = Lista_MarcasAC.FindIndex(i => i.Id_marca == IdAModif) != -1;
                    if (!parsear)
                    {
                        Console.WriteLine("Ingrese un ID valido.Pulse cualquier tecla para continuar.");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    if (!IdBool)
                    {
                        Console.WriteLine("Ingrese un ID valido.Pulse cualquier tecla para continuar.");
                        Console.ReadKey();
                        Console.Clear();
                    }
                } while (!parsear || !IdBool);

                Console.WriteLine("Ingrese marca modificada: ");
                string nuevoNombre = Console.ReadLine();
                Lista_MarcasAC[Lista_MarcasAC.FindIndex(i => i.Id_marca == IdAModif)].Marc = nuevoNombre;
                Grabar("MarcasAC.xlsx", "MarcasAC.xlsx", Lista_MarcasAC);

            }
            else if (respuesta.ToUpper() == "MOTO")
            {
                do
                {
                    Console.Write("Ingrese el ID de la marca a modificar: ");
                    parsear = int.TryParse(Console.ReadLine(), out IdAModif);
                    IdBool = Lista_MarcasMoto.FindIndex(i => i.Id_marca == IdAModif) != -1;
                    if (!parsear)
                    {
                        Console.WriteLine("Ingrese un ID valido.Pulse cualquier tecla para continuar.");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    if (!IdBool)
                    {
                        Console.WriteLine("Ingrese un ID valido.Pulse cualquier tecla para continuar.");
                        Console.ReadKey();
                        Console.Clear();
                    }
                } while (!parsear || !IdBool);

                Console.WriteLine("Ingrese marca modificada: ");
                string nuevoNombre = Console.ReadLine();
                Lista_MarcasMoto[Lista_MarcasMoto.FindIndex(i => i.Id_marca == IdAModif)].Marc = nuevoNombre;
                Grabar("MarcasMoto.xlsx", "MarcasMoto.xlsx", Lista_MarcasMoto);

            }
            else if (respuesta.ToUpper() == "CAMION")
            {
                do
                {
                    Console.Write("Ingrese el ID de la marca a modificar: ");
                    parsear = int.TryParse(Console.ReadLine(), out IdAModif);
                    IdBool = Lista_MarcasCamion.FindIndex(i => i.Id_marca == IdAModif) != -1;
                    if (!parsear)
                    {
                        Console.WriteLine("Ingrese un ID valido.Pulse cualquier tecla para continuar.");
                        Console.ReadKey();
                        Console.Clear();
                    }
                    if (!IdBool)
                    {
                        Console.WriteLine("Ingrese un ID valido.Pulse cualquier tecla para continuar.");
                        Console.ReadKey();
                        Console.Clear();
                    }
                } while (!parsear || !IdBool);

                Console.WriteLine("Ingrese marca modificada: ");
                string nuevoNombre = Console.ReadLine();
                Lista_MarcasCamion[Lista_MarcasCamion.FindIndex(i => i.Id_marca == IdAModif)].Marc = nuevoNombre;
                Grabar("MarcasCamion.xlsx", "MarcasCamion.xlsx", Lista_MarcasCamion);
            }
        }

       /* public void EliminarSegmento()
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
       */

        //metodo
        public void MostrarMarcas()
        {
            Console.WriteLine($"Id Marca: {this.Id_marca} Marca: {this.Marc}");

        }
        //get set
        public int Id_marca
        {
            get { return this.id_marca; }
            set { this.id_marca = value; }
        }
        public string Marc
        {
            get { return this.marc; }
            set { this.marc = value; }
        }
    }
}

