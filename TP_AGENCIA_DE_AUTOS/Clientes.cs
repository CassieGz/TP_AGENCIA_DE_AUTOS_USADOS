using System;
using System.Collections.Generic;
using System.IO;


namespace TP_AGENCIA_DE_AUTOS
{
    internal class Clientes
    {
        private int idcli;
        private string cli;
        private long cuit;
        private string domicilio;
        private int idlocalidad;
        private long telefonos;
        private string correo;
        private static List<Clientes> listaClientes = new List<Clientes>();
      
        public Clientes() { }

        public Clientes(int idclientes, string cliente, long cuit, string domicilio,
                        int idlocalidad, long telefonos, string correo)
        {
            this.IdCli = idclientes;
            this.Cli = cliente;
            this.cuit = cuit;
            this.Domicilio = domicilio;
            this.idlocalidad = idlocalidad;
            this.Telefonos = telefonos;
            this.Correo = correo;
        }
        public int IdCli
        {
            get { return this.idcli; }
            set { this.idcli = value; }
        }
        public string Cli
        {
            get { return this.cli; }
            set { this.cli = value; }
        }
        public long Cuit
        {
            get { return this.cuit; }
            set 
            {
                if (!ValidateCUIT(value))
                {
                    throw new ArgumentException("Cuit invalido");
                }
                this.cuit = value; 
            }
        }
        private bool ValidateCUIT(long cuit)
        {
            return cuit.ToString().Length == 11;
        }
        public string Domicilio
        {
            get { return this.domicilio; }
            set { this.domicilio = value; }
        }
        public int IdLocalidad
        {
            get { return this.idlocalidad; }
            set { this.idlocalidad = value; }
        }
        public long Telefonos
        {
            get { return this.telefonos; }
            set { this.telefonos = value; }
        }
        public string Correo
        {
            get { return this.correo; }
            set { this.correo = value; }
        }

        public void CargarClientes()
        {
            using (FileStream Archivo = new FileStream("clientes.csv", FileMode.Open)) ;
            using (StreamReader Leer = new StreamReader(Archivo)) ;

            while (!Leer.EndOfStream)
            {
                string cadena = Leer.ReadLine();
                string[] datos = cadena.Split(',');
                Clientes cliente = new Clientes(int.Parse(datos[0]),datos[1],
                                                long.Parse(datos[2]),datos[3],
                                                int.Parse(datos[4]),
                                                long.Parse(datos[5]), datos[6]);
                listaClientes.Add(cliente);
            }
            Archivo.Close();
            Leer.Close();
        }

        public void Mostrarclientes()
        {
            Console.WriteLine("|===========================================================|");

            Console.WriteLine("|ID   | Cliente     |  CUIT     | Localidad     | Telefono  |");

            Console.WriteLine("|===========================================================|");

            Console.WriteLine("| Domicilio    | Correo            |                        |");

            Console.WriteLine("|===========================================================|");

            Console.WriteLine("\n");

            foreach (Clientes cliente in listaClientes)
            {
                Console.WriteLine($"| {cliente.IdCli,-5} | {cliente.Cli,-12} | " +
                                  $"{cliente.Cuit,-11} |" + $" {cliente.IdLocalidad,-9} | " +
                                  $"{cliente.Telefonos,-8} |");
                Console.WriteLine($"| Domicilio: {cliente.Domicilio}, Correo: {cliente.Correo}");
                Console.WriteLine("|--------------------------------------------------------|");
            }
        }
        public void Agregarclientes()
        {
            Console.WriteLine("Agregar un cliente");
            Console.WriteLine("Ingrese Id:");
            int idcliente = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese cliente:");
            string cliente = Console.ReadLine();
            Console.WriteLine("Ingrese cuit:");
            long cuit = long.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese domicilio:");
            string domicilio = Console.ReadLine();
            Console.WriteLine("Ingrese localidad:");
            int idlocalidad = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese telefono:");
            long telefono = long.Parse(Console.ReadLine());
            Console.WriteLine("Ingrese correo:");
            string correo = Console.ReadLine();

            Clientes nuevoCliente = new Clientes(idcliente, cliente, cuit, domicilio, idlocalidad, telefono, correo);
            listaClientes.Add(nuevoCliente);
        }

        public void EliminarClientes(int id)
        {
            Clientes cliente = listaClientes.Find(c => c.idcli == id);
            if (cliente != null)
            {
                listaClientes.Remove(cliente);
                Console.WriteLine("Cliente eliminado correctamente.");
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
            }
            Console.ReadKey();
        }

        public void ActualizarClientes(int id)
        {
            Clientes clientes = listaClientes.Find(c => c.idcli == id);
            if (clientes != null)
            {
                Console.Write("Nuevo nombre del cliente: ");
                string Cli = Console.ReadLine();
                Console.Write("Nuevo CUIT: ");
                long Cuit = long.Parse(Console.ReadLine());
                Console.Write("Nuevo domicilio: ");
                string Domicilio = Console.ReadLine();
                Console.Write("Nuevo ID Localidad: ");
                int idlocalidad = int.Parse(Console.ReadLine());
                Console.Write("Nuevo teléfono: ");
                long Telefonos = long.Parse(Console.ReadLine());
                Console.Write("Nuevo correo: ");
                string Correo = Console.ReadLine();

                Console.WriteLine("Cliente actualizado correctamente.");
            }
            else
            {
                Console.WriteLine("Cliente no encontrado.");
            }
        }

        public void ListarClientes()
        {
            Console.WriteLine("|===========================================================|");
            Console.WriteLine("|ID   | Cliente     |  CUIT     | Localidad     | Telefono  |");
            Console.WriteLine("|===========================================================|");
            Console.WriteLine("| Domicilio    | Correo            |                        |");
            Console.WriteLine("|===========================================================|");

            foreach (Clientes cliente in listaClientes)
            {
                Console.WriteLine($"ID: {cliente.IdCli},Cliente: {cliente.Cli}, " +
                                  $"CUIT: {cliente.Cuit}, " + $"Domicilio: {cliente.Domicilio}, " +
                                  $"Localidad: {cliente.IdLocalidad}, " + $"Teléfono: {cliente.Telefonos}," +
                                  $" Correo: {cliente.Correo}");
            }
        }
    }

    
}
