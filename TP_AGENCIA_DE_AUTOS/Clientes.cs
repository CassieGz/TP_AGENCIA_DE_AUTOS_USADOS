using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_AGENCIA_DE_AUTOS
{
    internal class Clientes
    {
        private int IdCli;
        private string Cli;
        private long Cuit;
        private string Domicilio;
        private int IdLocalidad;
        private long Telefonos;
        private string Correo;

        public Clientes()
        {

        }
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
        public int idcli
        {
            get { return this.idcli; }
            set { this.idcli = value; }
        }
        public string cliente
        {
            get { return this.cliente; }
            set { this.cliente = value; }
        }
        public long cuit
        {
            get { return this.cuit; }
            set { this.cuit = value; }
        }
        public string domicilio
        {
            get { return this.domicilio; }
            set { this.domicilio = value; }
        }
        public int idlocalidad
        {
            get { return this.idlocalidad; }
            set { this.idlocalidad = value; }
        }
        public long telefonos
        {
            get { return this.telefonos; }
            set { this.telefonos = value; }
        }
        public string correo
        {
            get { return this.correo; }
            set { this.correo = value; }
        }
        private void Mostrarclientes()
        {
            Console.WriteLine("|===========================================================|");

            Console.WriteLine("|ID   | Cliente     |  CUIT     | Localidad     | Telefono  |");

            Console.WriteLine("|===========================================================|");

            Console.WriteLine("| Domicilio    | Correo            |                        |");

            Console.WriteLine("|===========================================================|");

            Console.WriteLine("\n");
        }
        private void Agregarclientes()
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
        }
        private void Eliminarclientes()
        {
            Clientes cliente = listaClientes.Find(c => c.idClientes == id);
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

        private void Actualizarclientes()
        {
            Clientes clientes = listaClientes.Find(c => c.idClientes == id);
            if (cliente != null)
            {
                Console.Write("Nuevo nombre del cliente: ");
                string Clientes = Console.ReadLine();
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
        public void listarclientes()
        { 

        }

    }
}
