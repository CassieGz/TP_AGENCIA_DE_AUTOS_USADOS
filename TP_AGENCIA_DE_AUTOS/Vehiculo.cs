using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_AGENCIA_DE_AUTOS;

namespace TP_AGENCIA_DE_AUTOS
{
    internal class Vehiculo
    {
        // priv
        private int id_vehiculo;
        private string patente;
        private int kilometro;
        private short anio;
        private int id_marca;
        private string modelo;
        private int id_segmento;
        private int id_combustible;
        private float precio_vta;
        private bool t_observaciones;
        private string observaciones; // validacion if de si es true poder llenar el string else no poder hacerlo
        private string color;

        private List<Vehiculo> Lista_Vehiculo;
        protected List<Moto> Lista_Motos = new List<Moto>();
        protected List<Camion> Lista_Camiones = new List<Camion>();
        protected List<Auto_Camioneta> Lista_AutoCamionetas = new List<Auto_Camioneta>();


        //constructor sin sobrecarga, realizado para que no se cree el que tiene por defecto por si las dudas
        //no se puede agregar un elemento de marca.Id_marca porque no funciona el parseo en la carga de datos de archivo 
        public Vehiculo(int id_vehiculo, string patente, int kilometro, short anio, int id_marca, string modelo, int id_segmento, int id_combustible, float precio_vta, bool t_observaciones, string observaciones, string color)
        {
            this.Id_Vehiculo = id_vehiculo;
            this.Patente = patente;
            this.Kilometro = kilometro;
            this.Anio = anio;
            this.Id_Marca = id_marca;
            this.Modelo = modelo;
            this.Id_segmento = id_segmento;
            this.Id_combustible = id_combustible;
            this.Precio_vta = precio_vta;
            this.Tobservaciones = t_observaciones;
            if (this.Tobservaciones)
            {
                this.Observaciones = observaciones;
            }
            else
            {
                this.Observaciones = " - ";
            }
            this.Color = color;

        }
        //grabar archivo nuevo
        public virtual void Grabar()
        {
            //
        }


        //CRUD
        public void Carga()
        {
            //motos
            FileStream Archivo = new FileStream("Motos.xlsx", FileMode.Open);
            StreamReader Leer = new StreamReader(Archivo);

            while (!Leer.EndOfStream)
            {
                string cadena = Console.ReadLine();
                string[] datos = cadena.Split(';');
                Moto oMoto = new Moto(int.Parse(datos[0]), datos[1], int.Parse(datos[2]), short.Parse(datos[3]), int.Parse(datos[4]), datos[5], int.Parse(datos[6]), int.Parse(datos[7]), float.Parse(datos[8]), bool.Parse(datos[9]), datos[10], datos[11], datos[12]);
                //cargar en lista de motos
                Lista_Motos.Add(oMoto);

            }
            Archivo.Close();
            Leer.Close();


            //autos
            FileStream Arch = new FileStream("AutoCamionetas.xlsx", FileMode.Open);
            StreamReader Lee = new StreamReader(Arch);

            while (!Lee.EndOfStream)
            {
                string cadena = Console.ReadLine();
                string[] datos = cadena.Split(';');
                Auto_Camioneta oAutoCam = new Auto_Camioneta(int.Parse(datos[0]), datos[1], int.Parse(datos[2]), short.Parse(datos[3]), int.Parse(datos[4]), datos[5], int.Parse(datos[6]), int.Parse(datos[7]), float.Parse(datos[8]), bool.Parse(datos[9]), datos[10], datos[11]);
                Lista_AutoCamionetas.Add(oAutoCam);
            }
            Arch.Close();
            Lee.Close();


            //camiones
            FileStream Archi = new FileStream("Camiones.xlsx", FileMode.Open);
            StreamReader Read = new StreamReader(Archi);

            while (!Read.EndOfStream)
            {
                string cadena = Console.ReadLine();
                string[] datos = cadena.Split(';');
                Camion oCamion = new Camion(int.Parse(datos[0]), datos[1], int.Parse(datos[2]), short.Parse(datos[3]), int.Parse(datos[4]), datos[5], int.Parse(datos[6]), int.Parse(datos[7]), float.Parse(datos[8]), bool.Parse(datos[9]), datos[10], datos[11], bool.Parse(datos[12]), datos[13], int.Parse(datos[14]));
                Lista_Camiones.Add(oCamion);
            }
            Archivo.Close();
            Leer.Close();

        }
        public void Leer()
        {
            Console.Clear();
            Console.WriteLine("------------------");
            Console.WriteLine("------MOTOS-------");
            Console.WriteLine("------------------");
            Console.WriteLine(" ");
            foreach (Moto moto in Lista_Motos)
            {
                moto.MostrarDatos();
                Console.WriteLine(" ");
            }
            Console.WriteLine("------------------");
            Console.WriteLine("--AUTO/CAMIONETA--");
            Console.WriteLine("------------------");
            Console.WriteLine(" ");
            foreach (Auto_Camioneta auto in Lista_AutoCamionetas)
            {
                auto.MostrarDatos();
                Console.WriteLine(" ");
            }
            Console.WriteLine("------------------");
            Console.WriteLine("-----CAMIONES-----");
            Console.WriteLine("------------------");
            Console.WriteLine(" ");
            foreach (Camion camion in Lista_Camiones)
            {
                camion.MostrarDatos();
                Console.WriteLine(" ");
            }
        }
        public void Actualizar()
        {
            Console.Write("Tipo de vehiculo a modificar: ");
            string respuesta = Console.ReadLine();
            bool parsear, IdBool, mayor;
            int IdAModif, modif;

            if (respuesta.ToUpper() != "AUTO" || respuesta.ToUpper() != "CAMION" || respuesta.ToUpper() != "MOTO")
            {
                Console.WriteLine("Ingrese una opcion valida de vehiculo. Pulse cualquier tecla para continuar.");
                Console.ReadKey();
            }

            if (respuesta.ToUpper() == "AUTO")
            {
                do
                {
                    Console.Write("Ingrese el ID del item a modificar: ");
                    parsear = int.TryParse(Console.ReadLine(), out IdAModif);
                    IdBool = Lista_AutoCamionetas.FindIndex(i => i.Id_Vehiculo == IdAModif) != -1;
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

                Console.WriteLine("1) Patente");
                Console.WriteLine("2) Kilometro");
                Console.WriteLine("3) Año");
                Console.WriteLine("4) ID Marca");
                Console.WriteLine("5) Modelo");
                Console.WriteLine("6) ID segmento");
                Console.WriteLine("7) ID combustible");
                Console.WriteLine("8) Precio");
                Console.WriteLine("9) Observacion");
                Console.WriteLine("10) Color");
                Console.WriteLine("11) Ninguno");
                Console.WriteLine();

                do
                {
                    Console.Write("Campo a modificar: ");
                    parsear = int.TryParse(Console.ReadLine(), out modif);
                    mayor = modif > 0 && modif < 12;
                    if (!parsear || !mayor)
                    {
                        Console.WriteLine("Ingrese un campo valido. Pulse cualquier tecla para continuar.");
                        Console.ReadKey();
                    }
                } while (!mayor || !parsear);

                switch (modif)
                {
                    case 1:
                        Console.Clear();
                        Console.Write("Patente modificada: ");
                        string PatenteModif = Console.ReadLine();
                        Lista_AutoCamionetas[Lista_AutoCamionetas.FindIndex(i => i.Id_Vehiculo == IdAModif)].Patente = PatenteModif;
                        break;

                    case 2:
                        int kModificar;
                        do
                        {
                            Console.Write("Kilometro modificado: ");
                            parsear = int.TryParse(Console.ReadLine(), out kModificar);
                            mayor = kModificar >= 0;

                            if (!parsear || !mayor)
                            {
                                Console.WriteLine("Ingrese un numero de kilometro valido. Pulse cualquier tecla para continuar.");
                                Console.ReadKey();
                            }
                        } while (!mayor || !parsear);
                        Lista_AutoCamionetas[Lista_AutoCamionetas.FindIndex(i => i.Id_Vehiculo == IdAModif)].Kilometro = kModificar;
                        break;

                    case 3:
                        short anioModificar;
                        do
                        {
                            Console.Clear();
                            Console.Write("Año modificado: ");
                            parsear = short.TryParse(Console.ReadLine(), out anioModificar);
                            mayor = anioModificar >= 1886 && anioModificar <= DateTime.Now.Year;
                            if (!parsear || !mayor)
                            {
                                Console.WriteLine("El año ingresado no es valido. Pulse cualquier tecla para continuar.");
                                Console.ReadKey();
                            }
                        } while (!parsear || !mayor);

                        Lista_AutoCamionetas[Lista_AutoCamionetas.FindIndex(i => i.Id_Vehiculo == IdAModif)].Anio = anioModificar;
                        break;

                    case 4:
                        Console.Clear();
                        int marcaModificar;
                        do
                        {
                            Console.Write("ID marca modificada: ");
                            parsear = int.TryParse(Console.ReadLine(), out marcaModificar);
                            mayor = marcaModificar >= 0;
                            if (!mayor || !parsear)
                            {
                                Console.WriteLine("Ingrese un ID marca valido. Pulse cualquier tecla para continuar.");
                                Console.ReadKey();
                            }
                        } while (!mayor || !parsear);
                        Lista_AutoCamionetas[Lista_AutoCamionetas.FindIndex(i => i.Id_Vehiculo == IdAModif)].Id_Marca = marcaModificar;
                        break;

                    case 5:
                        string modeloModificar;
;                        do
                        {
                            Console.Write("Modelo modificado: ");
                            modeloModificar = Console.ReadLine();
                            if (modeloModificar != "Sedan" || modeloModificar != "Coupe" || modeloModificar != "SUV" || modeloModificar != "Pick Up")
                            {
                                Console.WriteLine("Ingrese un modelo valido. Pulse cualquier tecla para continuar.");
                                Console.ReadKey();
                            }
                        } while (modeloModificar != "Sedan" || modeloModificar != "Coupe" || modeloModificar != "SUV" || modeloModificar != "Pick Up");

                        Lista_AutoCamionetas[Lista_AutoCamionetas.FindIndex(i => i.Id_Vehiculo == IdAModif)].Modelo = modeloModificar.ToUpper();

                        int segModif;
                        if (modeloModificar == "Sedan")
                        {
                            segModif = 1;
                            Lista_AutoCamionetas[Lista_AutoCamionetas.FindIndex(i => i.Id_Vehiculo == IdAModif)].Id_segmento = segModif;
                        }
                        if (modeloModificar == "Coupe")
                        {
                            segModif = 2;
                            Lista_AutoCamionetas[Lista_AutoCamionetas.FindIndex(i => i.Id_Vehiculo == IdAModif)].Id_segmento = segModif;
                        }
                        if (modeloModificar == "SUV")
                        {
                            segModif = 3;
                            Lista_AutoCamionetas[Lista_AutoCamionetas.FindIndex(i => i.Id_Vehiculo == IdAModif)].Id_segmento = segModif;
                        }
                        if (modeloModificar == "Pick Up")
                        {
                            segModif = 4;
                            Lista_AutoCamionetas[Lista_AutoCamionetas.FindIndex(i => i.Id_Vehiculo == IdAModif)].Id_segmento = segModif;
                        }



                        break;

                    case 6:
                        int segmModif;
                        do
                        {
                            Console.Write("ID segmento modificado: ");
                            parsear = int.TryParse(Console.ReadLine(), out segmModif);
                            if ((!parsear) && (segmModif==1|| segmModif == 2|| segmModif == 3|| segmModif == 4))
                            {
                                Console.WriteLine("Ingrese un ID segmento valido. Pulse cualquier tecla para continuar.");
                                Console.ReadKey();
                            }
                        } while ((!parsear) && (segmModif != 1 || segmModif != 2 || segmModif != 3 || segmModif != 4));

                        Lista_AutoCamionetas[Lista_AutoCamionetas.FindIndex(i => i.Id_Vehiculo == IdAModif)].Id_segmento = segmModif;

                        if(segmModif == 1)
                        {
                            string modModificar = "Sedan";
                            Lista_AutoCamionetas[Lista_AutoCamionetas.FindIndex(i => i.Id_Vehiculo == IdAModif)].Modelo = modModificar.ToUpper();
                        }
                        else if (segmModif == 2)
                        {
                            string modModificar = "Coupe";
                            Lista_AutoCamionetas[Lista_AutoCamionetas.FindIndex(i => i.Id_Vehiculo == IdAModif)].Modelo = modModificar.ToUpper();
                        }
                        else if (segmModif == 3)
                        {
                            string modModificar = "SUV";
                            Lista_AutoCamionetas[Lista_AutoCamionetas.FindIndex(i => i.Id_Vehiculo == IdAModif)].Modelo = modModificar.ToUpper();
                        }
                        else
                        {
                            string modModificar = "Pick Up";
                            Lista_AutoCamionetas[Lista_AutoCamionetas.FindIndex(i => i.Id_Vehiculo == IdAModif)].Modelo = modModificar.ToUpper();
                        }

                        break;

                    case 7:
                        int combModif;
                        do
                        {
                            Console.Write("ID combustible modificado: ");
                            parsear = int.TryParse(Console.ReadLine(), out combModif);
                            mayor = combModif >= 0;
                            if (!mayor || !parsear)
                            {
                                Console.WriteLine("Ingrese un ID combustible valido. Pulse cualquier tecla para continuar.");
                                Console.ReadKey();
                            }
                        } while (!mayor || !parsear);
                        Lista_AutoCamionetas[Lista_AutoCamionetas.FindIndex(i => i.Id_Vehiculo == IdAModif)].Id_combustible = combModif;
                        break;

                    case 8:
                        float precioModif;
                        do
                        {
                            Console.Write("Precio de venta modificado: ");
                            parsear = float.TryParse(Console.ReadLine(), out precioModif);
                            mayor = precioModif >= 0;
                            if (!mayor || !parsear)
                            {
                                Console.WriteLine("Ingrese un precio valido. Pulse cualquier tecla para continuar.");
                                Console.ReadKey();
                            }
                        } while (!parsear || !mayor);
                        Lista_AutoCamionetas[Lista_AutoCamionetas.FindIndex(i => i.Id_Vehiculo == IdAModif)].Precio_vta = precioModif;
                        break;

                    case 9:
                        string rta;
                        do
                        {
                            Console.Write("Tiene Observaciones(si, no): ");
                            rta = Console.ReadLine();

                            if (rta.ToUpper() != "SI" || rta.ToUpper() != "NO")
                            {
                                Console.WriteLine("Ingrese una respuesta valida. Pulse cualquier tecla para continuar.");
                                Console.ReadKey();
                            }

                        } while (rta.ToUpper() != "SI" || rta.ToUpper() != "NO");
                        if (rta.ToUpper() == "SI")
                        {
                            bool tob = true;
                            Lista_AutoCamionetas[Lista_AutoCamionetas.FindIndex(i => i.Id_Vehiculo == IdAModif)].Tobservaciones = tob;
                            Console.WriteLine("Observacion a realizar: ");
                            string obs = Console.ReadLine();
                            Lista_AutoCamionetas[Lista_AutoCamionetas.FindIndex(i => i.Id_Vehiculo == IdAModif)].Observaciones = obs;
                        }
                        else
                        {
                            bool tob = false;
                            Lista_AutoCamionetas[Lista_AutoCamionetas.FindIndex(i => i.Id_Vehiculo == IdAModif)].Tobservaciones = tob;
                            string obs = " - ";
                            Lista_AutoCamionetas[Lista_AutoCamionetas.FindIndex(i => i.Id_Vehiculo == IdAModif)].Observaciones = obs;
                        }
                        break;

                    case 10:
                        Console.Write("Color modificado: ");
                        string colorModif = Console.ReadLine();
                        Lista_AutoCamionetas[Lista_AutoCamionetas.FindIndex(i => i.Id_Vehiculo == IdAModif)].Color = colorModif;
                        break;

                    case 11:
                        break;
                }
                Auto_Camioneta oAuto = new Auto_Camioneta(0, " ", 0, 2000, 1, " ", 1, 1, 5000, false, " - ", "Rojo");
                oAuto.Grabar();

                Grabar();
            }

            if (respuesta.ToUpper() == "MOTO")
            {
                do
                {
                    Console.Write("Ingrese el ID del item a modificar: ");
                    parsear = int.TryParse(Console.ReadLine(), out IdAModif);
                    IdBool = Lista_Motos.FindIndex(i => i.Id_Vehiculo == IdAModif) != -1;
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

                Console.WriteLine("1) Patente");
                Console.WriteLine("2) Kilometro");
                Console.WriteLine("3) Año");
                Console.WriteLine("4) ID Marca");
                Console.WriteLine("5) Modelo");
                Console.WriteLine("6) ID segmento");
                Console.WriteLine("7) ID combustible");
                Console.WriteLine("8) Precio");
                Console.WriteLine("9) Observacion");
                Console.WriteLine("10) Color");
                Console.WriteLine("11) Cilindrada");
                Console.Write("12) Ninguno");
                Console.WriteLine();

                do
                {
                    Console.Write("Campo a modificar: ");
                    parsear = int.TryParse(Console.ReadLine(), out modif);
                    mayor = modif > 0 && modif < 13;
                    if (!parsear || !mayor)
                    {
                        Console.WriteLine("Ingrese un campo valido. Pulse cualquier tecla para continuar.");
                        Console.ReadKey();
                    }
                } while (!mayor || !parsear);

                switch (modif)
                {
                    case 1:
                        Console.Clear();
                        Console.Write("Patente modificada: ");
                        string PatenteModif = Console.ReadLine();
                        Lista_Motos[Lista_Motos.FindIndex(i => i.Id_Vehiculo == IdAModif)].Patente = PatenteModif;
                        break;

                    case 2:
                        int kModificar;
                        do
                        {
                            Console.Write("Kilometro modificado: ");
                            parsear = int.TryParse(Console.ReadLine(), out kModificar);
                            mayor = kModificar >= 0;

                            if (!parsear || !mayor)
                            {
                                Console.WriteLine("Ingrese un numero de kilometro valido. Pulse cualquier tecla para continuar.");
                                Console.ReadKey();
                            }
                        } while (!mayor || !parsear);
                        Lista_Motos[Lista_Motos.FindIndex(i => i.Id_Vehiculo == IdAModif)].Kilometro = kModificar;
                        break;

                    case 3:
                        short anioModificar;
                        do
                        {
                            Console.Clear();
                            Console.Write("Año modificado: ");
                            parsear = short.TryParse(Console.ReadLine(), out anioModificar);
                            mayor = anioModificar >= 1886 && anioModificar <= DateTime.Now.Year;
                            if (!parsear || !mayor)
                            {
                                Console.WriteLine("El año ingresado no es valido. Pulse cualquier tecla para continuar.");
                                Console.ReadKey();
                            }
                        } while (!parsear || !mayor);

                        Lista_Motos[Lista_Motos.FindIndex(i => i.Id_Vehiculo == IdAModif)].Anio = anioModificar;
                        break;

                    case 4:
                        Console.Clear();
                        int marcaModificar;
                        do
                        {
                            Console.Write("ID marca modificado: ");
                            parsear = int.TryParse(Console.ReadLine(), out marcaModificar);
                            mayor = marcaModificar >= 0;
                            if (!mayor || !parsear)
                            {
                                Console.WriteLine("Ingrese un ID marca valido. Pulse cualquier tecla para continuar.");
                                Console.ReadKey();
                            }
                        } while (!mayor || !parsear);
                        Lista_Motos[Lista_Motos.FindIndex(i => i.Id_Vehiculo == IdAModif)].Id_Marca = marcaModificar;
                        break;
                    //

                    case 5:
                        string modeloModificar;
                        do
                        {
                            Console.Write("Modelo modificado: ");
                            modeloModificar = Console.ReadLine();
                            if (modeloModificar != "Enduro" || modeloModificar != "Rutera" || modeloModificar != "Scooter")
                            {
                                Console.WriteLine("Ingrese un modelo valido de moto. Pulse cualquier tecla para continuar.");
                                Console.ReadKey();
                            }
                        } while (modeloModificar != "Enduro" || modeloModificar != "Rutera" || modeloModificar != "Scooter");

                        Lista_Motos[Lista_Motos.FindIndex(i => i.Id_Vehiculo == IdAModif)].Modelo = modeloModificar.ToUpper();

                        int segModif;
                        if (modeloModificar == "Enduro")
                        {
                            segModif = 5;
                            Lista_Motos[Lista_Motos.FindIndex(i => i.Id_Vehiculo == IdAModif)].Id_segmento = segModif;
                        }
                        if (modeloModificar == "Rutera")
                        {
                            segModif = 6;
                            Lista_Motos[Lista_Motos.FindIndex(i => i.Id_Vehiculo == IdAModif)].Id_segmento = segModif;
                        }
                        if (modeloModificar == "Scooter")
                        {
                            segModif = 7;
                            Lista_Motos[Lista_Motos.FindIndex(i => i.Id_Vehiculo == IdAModif)].Id_segmento = segModif;
                        }
                        break;

                    case 6:
                        int segmModif;
                        do
                        {
                            Console.Write("ID segmento modificado: ");
                            parsear = int.TryParse(Console.ReadLine(), out segmModif);
                            if ((!parsear) && (segmModif == 5 || segmModif == 6 || segmModif == 7))
                            {
                                Console.WriteLine("Ingrese un ID segmento valido. Pulse cualquier tecla para continuar.");
                                Console.ReadKey();
                            }
                        } while ((!parsear) && (segmModif != 5 || segmModif != 6 || segmModif != 7));

                        Lista_AutoCamionetas[Lista_AutoCamionetas.FindIndex(i => i.Id_Vehiculo == IdAModif)].Id_segmento = segmModif;

                        if (segmModif == 5)
                        {
                            string modModificar = "Enduro";
                            Lista_AutoCamionetas[Lista_AutoCamionetas.FindIndex(i => i.Id_Vehiculo == IdAModif)].Modelo = modModificar.ToUpper();
                        }
                        else if (segmModif == 6)
                        {
                            string modModificar = "Rutera";
                            Lista_AutoCamionetas[Lista_AutoCamionetas.FindIndex(i => i.Id_Vehiculo == IdAModif)].Modelo = modModificar.ToUpper();
                        }
                        else
                        {
                            string modModificar = "Scooter";
                            Lista_AutoCamionetas[Lista_AutoCamionetas.FindIndex(i => i.Id_Vehiculo == IdAModif)].Modelo = modModificar.ToUpper();
                        }
                        
                        break;
                    case 7:
                        int combModif;
                        do
                        {
                            Console.Write("ID combustible modificado: ");
                            parsear = int.TryParse(Console.ReadLine(), out combModif);
                            
                            if (!parsear || combModif==3)
                            {
                                Console.WriteLine("Ingrese un ID combustible valido. Pulse cualquier tecla para continuar.");
                                Console.ReadKey();
                            }

                        } while (!parsear && combModif==3);
                        Lista_Motos[Lista_Motos.FindIndex(i => i.Id_Vehiculo == IdAModif)].Id_combustible = combModif;
                        break;

                    case 8:
                        float precioModif;
                        do
                        {
                            Console.Write("Precio de venta modificado: ");
                            parsear = float.TryParse(Console.ReadLine(), out precioModif);
                            mayor = precioModif >= 0;
                            if (!mayor || !parsear)
                            {
                                Console.WriteLine("Ingrese un precio valido. Pulse cualquier tecla para continuar.");
                                Console.ReadKey();
                            }
                        } while (!parsear || !mayor);
                        Lista_Motos[Lista_Motos.FindIndex(i => i.Id_Vehiculo == IdAModif)].Precio_vta = precioModif;
                        break;

                    case 9:
                        string rta;
                        do
                        {
                            Console.Write("Tiene Observaciones(si, no): ");
                            rta = Console.ReadLine();

                            if (rta.ToUpper() != "SI" || rta.ToUpper() != "NO")
                            {
                                Console.WriteLine("Ingrese una respuesta valida. Pulse cualquier tecla para continuar.");
                                Console.ReadKey();
                            }

                        } while (rta.ToUpper() != "SI" || rta.ToUpper() != "NO");
                        if (rta.ToUpper() == "SI")
                        {
                            bool tob = true;
                            Lista_Motos[Lista_Motos.FindIndex(i => i.Id_Vehiculo == IdAModif)].Tobservaciones = tob;
                            Console.WriteLine("Observacion a realizar: ");
                            string obs = Console.ReadLine();
                            Lista_Motos[Lista_Motos.FindIndex(i => i.Id_Vehiculo == IdAModif)].Observaciones = obs;
                        }
                        else
                        {
                            bool tob = false;
                            Lista_Motos[Lista_Motos.FindIndex(i => i.Id_Vehiculo == IdAModif)].Tobservaciones = tob;
                            string obs = " - ";
                            Lista_Motos[Lista_Motos.FindIndex(i => i.Id_Vehiculo == IdAModif)].Observaciones = obs;
                        }
                        break;

                    case 10:
                        Console.Write("Color modificado: ");
                        string colorModif = Console.ReadLine();
                        Lista_Motos[Lista_Motos.FindIndex(i => i.Id_Vehiculo == IdAModif)].Color = colorModif;
                        break;

                    case 11:
                        string cModificar;
                        Console.WriteLine("Cilindrada nueva: ");
                        cModificar = Console.ReadLine();
                        Lista_Motos[Lista_Motos.FindIndex(i => i.Id_Vehiculo == IdAModif)].Cilindrada = cModificar;
                        break;

                    case 12:
                    default:
                        Console.ReadKey();
                        break;

                }
                Moto moto = new Moto(0, " ", 0, 2000, 1, " ", 1, 1, 5000, false, " - ", "Rojo", "110");
                moto.Grabar();
            }

            if (respuesta.ToUpper() == "CAMION")
            {
                do
                {
                    Console.Write("Ingrese el ID del item a modificar: ");
                    parsear = int.TryParse(Console.ReadLine(), out IdAModif);
                    IdBool = Lista_AutoCamionetas.FindIndex(i => i.Id_Vehiculo == IdAModif) != -1;
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

                Console.WriteLine("1) Patente");
                Console.WriteLine("2) Kilometro");
                Console.WriteLine("3) Año");
                Console.WriteLine("4) ID Marca");
                Console.WriteLine("5) Modelo");
                Console.WriteLine("6) ID segmento");
                Console.WriteLine("7) ID combustible");
                Console.WriteLine("8) Precio");
                Console.WriteLine("9) Observacion");
                Console.WriteLine("10) Color");
                Console.WriteLine("11) Caja, Dimension, Carga maxima");
                Console.Write("12) Ninguno");
                Console.WriteLine();

                do
                {
                    Console.Write("Campo a modificar: ");
                    parsear = int.TryParse(Console.ReadLine(), out modif);
                    mayor = modif > 0 && modif < 13;
                    if (!parsear || !mayor)
                    {
                        Console.WriteLine("Ingrese un campo valido. Pulse cualquier tecla para continuar.");
                        Console.ReadKey();
                    }
                } while (!mayor || !parsear);
                switch (modif)
                {
                    case 1:
                        Console.Clear();
                        Console.Write("Patente modificada: ");
                        string PatenteModif = Console.ReadLine();
                        Lista_Camiones[Lista_Camiones.FindIndex(i => i.Id_Vehiculo == IdAModif)].Patente = PatenteModif;
                        break;

                    case 2:
                        int kModificar;
                        do
                        {
                            Console.Write("Kilometro modificado: ");
                            parsear = int.TryParse(Console.ReadLine(), out kModificar);
                            mayor = kModificar >= 0;

                            if (!parsear || !mayor)
                            {
                                Console.WriteLine("Ingrese un numero de kilometro valido. Pulse cualquier tecla para continuar.");
                                Console.ReadKey();
                            }
                        } while (!mayor || !parsear);
                        Lista_Camiones[Lista_Camiones.FindIndex(i => i.Id_Vehiculo == IdAModif)].Kilometro = kModificar;
                        break;

                    case 3:
                        short anioModificar;
                        do
                        {
                            Console.Clear();
                            Console.Write("Año modificado: ");
                            parsear = short.TryParse(Console.ReadLine(), out anioModificar);
                            mayor = anioModificar >= 1886 && anioModificar <= DateTime.Now.Year;
                            if (!parsear || !mayor)
                            {
                                Console.WriteLine("El año ingresado no es valido. Pulse cualquier tecla para continuar.");
                                Console.ReadKey();
                            }
                        } while (!parsear || !mayor);

                        Lista_Camiones[Lista_Camiones.FindIndex(i => i.Id_Vehiculo == IdAModif)].Anio = anioModificar;
                        break;

                    case 4:
                        Console.Clear();
                        int marcaModificar;
                        do
                        {
                            Console.Write("ID marca modificado: ");
                            parsear = int.TryParse(Console.ReadLine(), out marcaModificar);
                            mayor = marcaModificar >= 0;
                            if (!mayor || !parsear)
                            {
                                Console.WriteLine("Ingrese un ID marca valido. Pulse cualquier tecla para continuar.");
                                Console.ReadKey();
                            }
                        } while (!mayor || !parsear);
                        Lista_Camiones[Lista_Camiones.FindIndex(i => i.Id_Vehiculo == IdAModif)].Id_Marca = marcaModificar;
                        break;

                    case 5:
                        Console.Write("Modelo modificado: ");
                        string modeloModificar = Console.ReadLine();
                        Lista_Camiones[Lista_Camiones.FindIndex(i => i.Id_Vehiculo == IdAModif)].Modelo = modeloModificar.ToUpper();
                        break;

                    case 6:
                        int segmModif;
                        do
                        {
                            Console.Write("ID segmento modificado: ");
                            parsear = int.TryParse(Console.ReadLine(), out segmModif);
                            mayor = segmModif >= 0;
                            if (!mayor || !parsear)
                            {
                                Console.WriteLine("Ingrese un ID segmento valido. Pulse cualquier tecla para continuar.");
                                Console.ReadKey();
                            }
                        } while (!mayor || !parsear);
                        Lista_Camiones[Lista_Camiones.FindIndex(i => i.Id_Vehiculo == IdAModif)].Id_segmento = segmModif;
                        break;

                    case 7:
                        int combModif;
                        do
                        {
                            Console.Write("ID combustible modificado: ");
                            parsear = int.TryParse(Console.ReadLine(), out combModif);
                            mayor = combModif >= 0;
                            if (!mayor || !parsear)
                            {
                                Console.WriteLine("Ingrese un ID combustible valido. Pulse cualquier tecla para continuar.");
                                Console.ReadKey();
                            }
                        } while (!mayor || !parsear);
                        Lista_Camiones[Lista_Camiones.FindIndex(i => i.Id_Vehiculo == IdAModif)].Id_combustible = combModif;
                        break;

                    case 8:
                        float precioModif;
                        do
                        {
                            Console.Write("Precio de venta modificado: ");
                            parsear = float.TryParse(Console.ReadLine(), out precioModif);
                            mayor = precioModif >= 0;
                            if (!mayor || !parsear)
                            {
                                Console.WriteLine("Ingrese un precio valido. Pulse cualquier tecla para continuar.");
                                Console.ReadKey();
                            }
                        } while (!parsear || !mayor);
                        Lista_Camiones[Lista_Camiones.FindIndex(i => i.Id_Vehiculo == IdAModif)].Precio_vta = precioModif;
                        break;

                    case 9:
                        string rta;
                        do
                        {
                            Console.Write("Tiene Observaciones(si, no): ");
                            rta = Console.ReadLine();

                            if (rta.ToUpper() != "SI" || rta.ToUpper() != "NO")
                            {
                                Console.WriteLine("Ingrese una respuesta valida. Pulse cualquier tecla para continuar.");
                                Console.ReadKey();
                            }

                        } while (rta.ToUpper() != "SI" || rta.ToUpper() != "NO");
                        if (rta.ToUpper() == "SI")
                        {
                            bool tob = true;
                            Lista_Camiones[Lista_Camiones.FindIndex(i => i.Id_Vehiculo == IdAModif)].Tobservaciones = tob;
                            Console.WriteLine("Observacion a realizar: ");
                            string obs = Console.ReadLine();
                            Lista_Camiones[Lista_Camiones.FindIndex(i => i.Id_Vehiculo == IdAModif)].Observaciones = obs;
                        }
                        else
                        {
                            bool tob = false;
                            Lista_Camiones[Lista_Camiones.FindIndex(i => i.Id_Vehiculo == IdAModif)].Tobservaciones = tob;
                            string obs = " - ";
                            Lista_Camiones[Lista_Camiones.FindIndex(i => i.Id_Vehiculo == IdAModif)].Observaciones = obs;
                        }
                        break;

                    case 10:
                        Console.Write("Color modificado: ");
                        string colorModif = Console.ReadLine();
                        Lista_Camiones[Lista_Camiones.FindIndex(i => i.Id_Vehiculo == IdAModif)].Color = colorModif;
                        break;

                    case 11:
                        string resp;
                        do
                        {
                            Console.Write("Tiene caja de carga(si, no): ");
                            resp = Console.ReadLine();

                            if (resp.ToUpper() != "SI" || resp.ToUpper() != "NO")
                            {
                                Console.WriteLine("Ingrese una respuesta valida. Pulse cualquier tecla para continuar.");
                                Console.ReadKey();
                            }

                        } while (resp.ToUpper() != "SI" || resp.ToUpper() != "NO");

                        if (resp.ToUpper() == "SI")
                        {
                            bool cajB = true;
                            Lista_Camiones[Lista_Camiones.FindIndex(i => i.Id_Vehiculo == IdAModif)].Caja_carga = cajB;
                            Console.WriteLine("Dimension de la caja: ");
                            string dim = Console.ReadLine();
                            Console.WriteLine(" ");
                            Lista_Camiones[Lista_Camiones.FindIndex(i => i.Id_Vehiculo == IdAModif)].Dimension_caja = dim;
                            int carMax;
                            do
                            {
                                Console.Write("Carga Maxima de la caja: ");
                                parsear = int.TryParse(Console.ReadLine(), out carMax);
                                mayor = carMax >= 0;
                                if (!mayor || !parsear)
                                {
                                    Console.WriteLine("Ingrese un numero valido de carga. Pulse cualquier tecla para continuar.");
                                    Console.ReadKey();
                                }
                            } while (!parsear || !mayor);

                            Lista_Camiones[Lista_Camiones.FindIndex(i => i.Id_Vehiculo == IdAModif)].Carga_max = carMax;

                        }
                        else
                        {
                            bool cajB = false;
                            Lista_Camiones[Lista_Camiones.FindIndex(i => i.Id_Vehiculo == IdAModif)].Caja_carga = cajB;
                            string dim = " - ";
                            Lista_Camiones[Lista_Camiones.FindIndex(i => i.Id_Vehiculo == IdAModif)].Dimension_caja = dim;
                            int carMax = 0;
                            Lista_Camiones[Lista_Camiones.FindIndex(i => i.Id_Vehiculo == IdAModif)].Carga_max = carMax;

                        }
                        break;

                    case 12:
                        break;
                }
                Camion oCamion = new Camion(0, " ", 0, 2000, 1, " ", 1, 1, 5000, false, " - ", "Rojo", false, " - ", 0);
                oCamion.Grabar();
            }
        }

        public void Agregar()
        {
            Console.Clear();
            string respuesta;
            do
            {
                Console.WriteLine("Ingrese tipo de vehiculo a agregar: auto, moto o camion.");
                respuesta = Console.ReadLine();

                if (respuesta.ToUpper() != "AUTO" && respuesta.ToUpper() != "MOTO" && respuesta.ToUpper() != "CAMION")
                {
                    Console.WriteLine("Ingrese un tipo de vehiculo valido. Pulse cualquier tecla para continuar.");
                    Console.ReadKey();
                }
            } while (respuesta.ToUpper() != "AUTO" && respuesta.ToUpper() != "MOTO" && respuesta.ToUpper() != "CAMION");

            int nuevoId = (Lista_Vehiculo.Count > 0) ? Lista_Vehiculo[Lista_Vehiculo.Count - 1].id_vehiculo + 1 : 1;
            int id_vehiculo = nuevoId;

            Console.Write("Patente: ");
            string patente = Console.ReadLine();

            int kilometro;
            bool parsear, mayor;
            do
            {
                Console.Write("Kilometro: ");
                parsear = int.TryParse(Console.ReadLine(), out kilometro);
                mayor = kilometro >= 0;

                if (!parsear || !mayor)
                {
                    Console.WriteLine("Ingrese un kilometraje valido. Pulse para continuar. ");
                    Console.ReadKey();
                }
            } while (!parsear || !mayor);


            short anio;
            do
            {
                Console.Clear();
                Console.Write("Año: ");
                parsear = short.TryParse(Console.ReadLine(), out anio);

                mayor = anio >= 1886 && anio <= DateTime.Now.Year;
                if (!parsear || !mayor)
                {
                    Console.WriteLine("El año ingresado no es valido. Pulse cualquier tecla para continuar.");
                    Console.ReadKey();
                }
            } while (!parsear || !mayor);



            int id_marca;
            do
            {
                Console.Clear();
                Console.Write("Ingrese ID de marca: ");
                parsear = int.TryParse(Console.ReadLine(), out id_marca);
                mayor = id_marca >= 0;
                if (!parsear || !mayor)
                {
                    Console.WriteLine("El ID ingresado no es valido. Pulse cualquier tecla para continuar.");
                    Console.ReadKey();
                    //falta validar datos con los txt
                }
            } while (!parsear || !mayor);

            Console.Write("Modelo: ");
            string modelo = Console.ReadLine();

            int id_segmento;
            do
            {
                Console.Clear();
                Console.Write("Ingrese ID de segmento: ");
                parsear = int.TryParse(Console.ReadLine(), out id_segmento);
                mayor = id_segmento >= 0;
                if (!parsear || !mayor)
                {
                    Console.WriteLine("El ID ingresado no es valido. Pulse cualquier tecla para continuar.");
                    Console.ReadKey();
                }
                //falta validar datos con los xlsx
            } while (!parsear || !mayor);


            int id_combustible;
            do
            {
                Console.Clear();
                Console.Write("Ingrese ID de combustible: ");
                parsear = int.TryParse(Console.ReadLine(), out id_combustible);
                mayor = id_combustible >= 0;
                if (!parsear || !mayor)
                {
                    Console.WriteLine("El ID ingresado no es valido. Pulse cualquier tecla para continuar.");
                    Console.ReadKey();
                }
                //falta validar datos
            } while (!parsear || !mayor);

            float precio_vta;
            do
            {
                Console.Clear();
                Console.Write("Precio de Venta: ");
                parsear = float.TryParse(Console.ReadLine(), out precio_vta);
                mayor = precio_vta >= 0;
                if (!parsear || !mayor)
                {
                    Console.WriteLine("El precio ingresado no es valido. Pulse cualquier tecla para continuar.");
                    Console.ReadKey();
                }
            } while (!parsear || !mayor);

            bool t_observaciones = false;
            string observaciones = " - ";
            Console.Write("Tiene observaciones: ");
            Console.ReadLine();
            if (Console.ReadLine().ToUpper() == "SI")
            {
                t_observaciones = true;
                Console.Write("Observaciones: ");
                observaciones = Console.ReadLine();
            }

            Console.Write("Color: ");
            string color = Console.ReadLine();
            //

            bool caja_carga = false;
            string dimension_caja = " - ";
            int carga_max = 0;
            string cilindrada;

            if (respuesta.ToUpper() == "CAMION")
            {
                Console.Write("Tiene caja de carga: ");
                string rta = Console.ReadLine();
                while (rta.ToUpper() != "SI" || rta.ToUpper() != "NO")
                {
                    Console.Write("La respuesta no es valida: ");
                    rta = Console.ReadLine();
                }
                if (rta.ToUpper() == "SI")
                {
                    caja_carga = true;
                    Console.Write("Dimension de la caja: ");
                    dimension_caja = Console.ReadLine();
                    do
                    {
                        Console.Write("Carga maxima: ");
                        parsear = int.TryParse(Console.ReadLine(), out carga_max);
                        mayor = carga_max > 0;
                        if (!parsear || !mayor)
                        {
                            Console.WriteLine("Ingrese un numero valido. Pulse cualquier tecla para continuar.");
                        }
                    } while (!parsear || !mayor);
                }
                Camion oCamion = new Camion(id_vehiculo, patente, kilometro, anio, id_marca, modelo, id_segmento, id_combustible, precio_vta, t_observaciones, observaciones, color, caja_carga, dimension_caja, carga_max);
                Lista_Camiones.Add(oCamion);
                oCamion.Grabar();
            }
            else if (respuesta.ToUpper() == "MOTO")
            {
                Console.Write("Cilindrada: ");
                cilindrada = Console.ReadLine();
                Moto oMoto = new Moto(id_vehiculo, patente, kilometro, anio, id_marca, modelo, id_segmento, id_combustible, precio_vta, t_observaciones, observaciones, color, cilindrada);
                Lista_Motos.Add(oMoto);
                oMoto.Grabar();
            }

            if (respuesta.ToUpper() == "AUTO")
            {
                Auto_Camioneta oAutoCamioneta = new Auto_Camioneta(id_vehiculo, patente, kilometro, anio, id_marca, modelo, id_segmento, id_combustible, precio_vta, t_observaciones, observaciones, color);
                Lista_AutoCamionetas.Add(oAutoCamioneta);
                oAutoCamioneta.Grabar();
            }

            Console.Clear();
        }


        public void Eliminar()
        {
            Console.Clear();
            string respuesta;
            do
            {
                Console.WriteLine("Ingrese tipo de vehiculo a eliminar: auto, moto o camion.");
                respuesta = Console.ReadLine();

                if (respuesta.ToUpper() != "AUTO" && respuesta.ToUpper() != "MOTO" && respuesta.ToUpper() != "CAMION")
                {
                    Console.WriteLine("Ingrese un tipo de vehiculo valido. Pulse cualquier tecla para continuar.");
                    Console.ReadKey();
                }
            } while (respuesta.ToUpper() != "AUTO" && respuesta.ToUpper() != "MOTO" && respuesta.ToUpper() != "CAMION");

            bool rta, IdBool = false;
            int IdEliminar;
            if (respuesta.ToUpper() == "AUTO")
            {
                do
                {
                    Console.WriteLine(" ");
                    Console.Write("Ingrese el ID del item que desea eliminar: ");
                    rta = int.TryParse(Console.ReadLine(), out IdEliminar);


                    foreach (Auto_Camioneta oAut in Lista_AutoCamionetas)
                    {
                        if (oAut.Id_Vehiculo == IdEliminar)
                        {
                            IdBool = true;
                        }
                    }
                    if (!rta)
                    {
                        Console.WriteLine("Ingrese un ID existente. Pulse cualquier tecla para continuar.");
                        Console.ReadKey();
                    }
                    if (!IdBool)
                    {
                        Console.WriteLine("Ingrese un ID existente.Pulse cualquier tecla para continuar.");
                        Console.ReadKey();
                    }

                } while (!rta || !IdBool);
                Lista_AutoCamionetas.RemoveAt(Lista_AutoCamionetas.FindIndex(i => i.Id_Vehiculo == IdEliminar));
                Auto_Camioneta oAuto= new Auto_Camioneta(0, " ", 0, 2000, 1, " ", 1, 1, 5000, false, " - ", "Rojo");
                oAuto.Grabar();
            }
            if (respuesta.ToUpper() == "MOTO")
            {
                do
                {
                    Console.WriteLine(" ");
                    Console.Write("Ingrese el ID del item que desea eliminar: ");
                    rta = int.TryParse(Console.ReadLine(), out IdEliminar);


                    foreach (Moto oMot in Lista_Motos)
                    {
                        if (oMot.Id_Vehiculo == IdEliminar)
                        {
                            IdBool = true;
                        }
                    }
                    if (!rta)
                    {
                        Console.WriteLine("Ingrese un ID existente. Pulse cualquier tecla para continuar.");
                        Console.ReadKey();
                    }
                    if (!IdBool)
                    {
                        Console.WriteLine("Ingrese un ID existente.Pulse cualquier tecla para continuar.");
                        Console.ReadKey();
                    }

                } while (!rta || !IdBool);
                Lista_Motos.RemoveAt(Lista_Motos.FindIndex(i => i.Id_Vehiculo == IdEliminar));
                Moto oMoto= new Moto(0, " ", 0, 2000, 1, " ", 1, 1, 5000, false, " - ", "Rojo","110");
                oMoto.Grabar();
            }
            if (respuesta.ToUpper() == "CAMION")
            {
                do
                {
                    Console.WriteLine(" ");
                    Console.Write("Ingrese el ID del item que desea eliminar: ");
                    rta = int.TryParse(Console.ReadLine(), out IdEliminar);


                    foreach (Camion oCam in Lista_Camiones)
                    {
                        if (oCam.Id_Vehiculo == IdEliminar)
                        {
                            IdBool = true;
                        }
                    }
                    if (!rta)
                    {
                        Console.WriteLine("Ingrese un ID existente. Pulse cualquier tecla para continuar.");
                        Console.ReadKey();
                    }
                    if (!IdBool)
                    {
                        Console.WriteLine("Ingrese un ID existente.Pulse cualquier tecla para continuar.");
                        Console.ReadKey();
                    }

                } while (!rta || !IdBool);
                Lista_Camiones.RemoveAt(Lista_Camiones.FindIndex(i => i.Id_Vehiculo == IdEliminar));
                Camion oCamion = new Camion(0, " ", 0, 2000, 1, " ", 1, 1, 5000, false, " - ", "Rojo", false, " - ", 0);
                oCamion.Grabar();
            }

        }

        //remove at se utiliza para quitar un elemento de una lista en el indice especifico
        //Se utiliza findindex para simplicidad de codigo y eficiencia para eliminacion y, para evitar excepciones si no se encuentra

   


        // metodo
        public virtual void MostrarDatos()
        {
            //
        }
        

        //get set
        public int Id_Vehiculo
        {
            get { return this.id_vehiculo; }
            set { this.id_vehiculo = value; }
        }
        public string Patente
        {
            get { return this.patente; }
            set { this.patente = value; }
        }

        public int Kilometro
        {
            get { return this.kilometro; }
            set { this.kilometro = value; }
        }

        public short Anio
        {
            get { return this.anio; }
            set { this.anio = value; }
        }
        public int Id_Marca
        {
            get { return this.id_marca; }
            set { this.id_marca = value; }
        }

        public string Modelo
        {
            get { return this.modelo; }
            set { this.modelo = value; }
        }

        public int Id_segmento
        {
            get { return this.id_segmento; }
            set { this.id_segmento = value; }
        }
        public int Id_combustible
        {
            get { return this.id_combustible; }
            set { this.id_combustible = value; }
        }

        public float Precio_vta
        {
            get { return this.precio_vta; }
            set { this.precio_vta = value; }
        }
        public bool Tobservaciones
        {
            get { return this.t_observaciones; }
            set { this.t_observaciones = value; }   
        }
        public string Observaciones
        {
            get { return this.observaciones; }
            set { this.observaciones = value; }
        }

        public string Color
        {
            get { return this.color; }
            set { this.color = value; }
        }
    }
}
    // --------------------------------------------------------------------------------------------
    internal class Moto : Vehiculo
    {
        //prop priv
        private string cilindrada;
        

        //constr
        public Moto(int id_vehiculo, string patente, int kilometro, short anio, int id_marca, string modelo, int id_segmento, int id_combustible, float precio_vta, bool t_observaciones, string observaciones, string color, string cilindrada) : base(id_vehiculo, patente, kilometro, anio, id_marca, modelo, id_segmento, id_combustible, precio_vta, t_observaciones, observaciones, color)
        {
            this.Id_Vehiculo = id_vehiculo;
            this.Patente = patente;
            this.Kilometro = kilometro;
            this.Anio = anio;
            this.Id_Marca = id_marca;
            this.Modelo = modelo;
            this.Id_segmento = id_segmento;
            this.Id_combustible = id_combustible;
            this.Precio_vta = precio_vta;
            this.Tobservaciones = t_observaciones;
            if (this.Tobservaciones)
            {
                this.Observaciones = observaciones;
            }
            else
            {
                this.Observaciones = " - ";
            }
            this.Color = color;

            this.Cilindrada = cilindrada;
        }

        //metod
        public override void MostrarDatos()
        {
            Console.WriteLine($"Id Vehiculo:{this.Id_Vehiculo} - Patente:{this.Patente} - Kilometro:{this.Kilometro} - Año:{this.Anio} - Id Marca:{this.Id_Marca} - Modelo:{this.Modelo} - Id Segmento:{this.Id_segmento} - Id Combustible:{this.Id_combustible} - Precio de venta:{this.Precio_vta} - Hay observaciones:", this.Tobservaciones ? "Si" : "No", $" - Observaciones:{this.Observaciones} - Color: {this.Color} - Cilindrada:{this.Cilindrada}.");
        }

    public override void Grabar()
    {
        if (File.Exists("Motos.xlsx"))
        {
            File.Delete("Motos.xlsx");
        }
        FileStream Archivo = new FileStream("Motos.xlsx", FileMode.Create);
        StreamWriter Grabar = new StreamWriter(Archivo);
        
            foreach (Moto item in Lista_Motos)
            {
                Grabar.WriteLine($"{this.Id_Vehiculo};{this.Patente};{this.Kilometro};{this.Anio};{this.Id_Marca};{this.Modelo};{this.Id_segmento};{this.Id_combustible};{this.Precio_vta};{this.Tobservaciones};{this.Observaciones};{this.Color}; {this.Cilindrada}");
            }
        
        Grabar.Close();
        Archivo.Close();
    }
    //public
    public string Cilindrada
        {
            get { return this.cilindrada; }
            set { this.cilindrada = value; }
        }

    }
    // --------------------------------------------------------------------------------------------

    internal class Auto_Camioneta : Vehiculo
    {
        //constructor
        public Auto_Camioneta(int id_vehiculo, string patente, int kilometro, short anio, int id_marca, string modelo, int id_segmento, int id_combustible, float precio_vta, bool t_observaciones, string observaciones, string color) : base(id_vehiculo, patente, kilometro, anio, id_marca, modelo, id_segmento, id_combustible, precio_vta, t_observaciones, observaciones, color)
        {
            this.Id_Vehiculo = id_vehiculo;
            this.Patente = patente;
            this.Kilometro = kilometro;
            this.Anio = anio;
            this.Id_Marca = id_marca;
            this.Modelo = modelo;
            this.Id_segmento = id_segmento;
            this.Id_combustible = id_combustible;
            this.Precio_vta = precio_vta;
            this.Tobservaciones = t_observaciones;
            if (this.Tobservaciones)
            {
                this.Observaciones = observaciones;
            }
            else
            {
                this.Observaciones = " - ";
            }
            this.Color = color;
        }

        //metodo
        public override void MostrarDatos()
        {
            Console.WriteLine($"Id Vehiculo:{this.Id_Vehiculo} - Patente:{this.Patente} - Kilometro:{this.Kilometro} - Año:{this.Anio} - Id Marca:{this.Id_Marca} - Modelo:{this.Modelo} - Id Segmento:{this.Id_segmento} - Id Combustible:{this.Id_combustible} - Precio de venta:{this.Precio_vta} - Hay observaciones:", this.Tobservaciones ? "Si" : "No", $" - Observaciones:{this.Observaciones} - Color: {this.Color}.");
        }

        public override void Grabar()
        {
            if (File.Exists("AutoCamionetas.xlsx"))
            {
                File.Delete("AutoCamionetas.xlsx");
            }
            FileStream Archivo = new FileStream("AutoCamionetas.xlsx", FileMode.Create);
            StreamWriter Grabar = new StreamWriter(Archivo);

            foreach (Auto_Camioneta item in Lista_AutoCamionetas)
            {
                Grabar.WriteLine($"{this.Id_Vehiculo};{this.Patente};{this.Kilometro};{this.Anio};{this.Id_Marca};{this.Modelo};{this.Id_segmento};{this.Id_combustible};{this.Precio_vta};{this.Tobservaciones};{this.Observaciones};{this.Color}");
            }

            Grabar.Close();
            Archivo.Close();
        }

    //sin get ni set porque todo lo toma de vehiculo de herencia
}

    // --------------------------------------------------------------------------------------------

    internal class Camion : Vehiculo
    {
        //prop priv
        private bool caja_carga;
        private string dimension_caja;
        private int carga_max;


        //constructor
        public Camion(int id_vehiculo, string patente, int kilometro, short anio, int id_marca, string modelo, int id_segmento, int id_combustible, float precio_vta, bool t_observaciones, string observaciones, string color, bool caja_carga, string dimension_caja, int carga_max) : base(id_vehiculo, patente, kilometro, anio, id_marca, modelo, id_segmento, id_combustible, precio_vta, t_observaciones, observaciones, color)
        {
            this.Id_Vehiculo = id_vehiculo;
            this.Patente = patente;
            this.Kilometro = kilometro;
            this.Anio = anio;
            this.Id_Marca = id_marca;
            this.Modelo = modelo;
            this.Id_segmento = id_segmento;
            this.Id_combustible = id_combustible;
            this.Precio_vta = precio_vta;
            this.Tobservaciones = t_observaciones;
            if (this.Tobservaciones)
            {
                this.Observaciones = observaciones;
            }
            else
            {
                this.Observaciones = " - ";
            }
            this.Color = color;
            this.Caja_carga = caja_carga;
            this.Dimension_caja = dimension_caja;
            this.Carga_max = carga_max;
        }

        //metod
        public override void MostrarDatos()
        {
            Console.WriteLine($"Id Vehiculo:{this.Id_Vehiculo} - Patente:{this.Patente} - Kilometro:{this.Kilometro} - Año:{this.Anio} - Id Marca:{this.Id_Marca} - Modelo:{this.Modelo} - Id Segmento:{this.Id_segmento} - Id Combustible:{this.Id_combustible} - Precio de venta:{this.Precio_vta} - Hay observaciones:", this.Tobservaciones ? "Si" : "No", $" - Observaciones:{this.Observaciones} - Color: {this.Color} - Caja de carga:{this.Caja_carga} - Dimension:{this.Dimension_caja} - Carga maxima:{this.Carga_max}.");
        }
    public override void Grabar()
    {
        if (File.Exists("Camiones.xlsx"))
        {
            File.Delete("Camiones.xlsx");
        }
        FileStream Archivo = new FileStream("Camiones.xlsx", FileMode.Create);
        StreamWriter Grabar = new StreamWriter(Archivo);

        foreach (Camion item in Lista_Camiones)
        {
            Grabar.WriteLine($"{this.Id_Vehiculo};{this.Patente};{this.Kilometro};{this.Anio};{this.Id_Marca};{this.Modelo};{this.Id_segmento};{this.Id_combustible};{this.Precio_vta};{this.Tobservaciones};{this.Observaciones};{this.Color};{this.Caja_carga};{this.Dimension_caja};{this.Carga_max}");
        }

        Grabar.Close();
        Archivo.Close();
    }


    //get set
    public bool Caja_carga
        {
            get { return this.caja_carga; }
            set { this.caja_carga = value; }
        }
        public string Dimension_caja
        {
            get { return dimension_caja; }
            set { dimension_caja = value; }
        }
        public int Carga_max
        {
            get { return this.carga_max; }
            set { this.carga_max = value; }
        }
    }

