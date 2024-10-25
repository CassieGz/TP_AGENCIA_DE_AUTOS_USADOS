using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_AGENCIA_DE_AUTOS
{
    internal class Ventas
    {
        private int IdCli;
        private int IdVeh;
        private DateTime FecCompra;
        private DateTime FecEntrega;
        private double SubT;
        private double Iva;
        private double Desc;
        private double Total;

        public Ventas()
        {
        }
        public Ventas(int idcliente, int idvehiculo, DateTime fechacompra, DateTime fechaentrega,
                      double subtotal, double iva, double descuento, double total)
        {
            this.IdCli = idcliente;
            this.IdVeh = idvehiculo;
            this.FecCompra = fechacompra;
            this.FecEntrega = fechaentrega;
            this.SubT = subtotal;
            this.Iva = iva;
            this.Desc = descuento;
            this.Total = total;
        }
        public int IdClientes
        {
            get { return this.IdCli; }
            set { this.IdCli = value; }
        }
        public int IdVehiculo
        {
            get { return this.IdVeh; }
            set { this.IdVeh = value; }
        }
        public DateTime FechaCompra
        {
            get { return this.FechaCompra; }
            set { this.FechaCompra = value; }
        }
        public DateTime FechaEntrega
        {
            get { return this.FechaEntrega; }
            set { this.FechaEntrega = value; }
        }
        public double SubTotal
        {
            get { return this.SubTotal; }
            set { this.SubTotal = value; }
        }
        public double iva
        {
            get { return this.iva; }
            set { this.iva = value; }
        }
        public double Descuento
        {
            get { return this.Desc; }
            set { this.Desc = value; }
        }
        public double total
        {
            get { return this.total; }
            set { this.total = value; }
        }
        private void Mostrarventas()
        {
            Console.WriteLine("|======================================================================|");

            Console.WriteLine("|  ID  |   Cliente   |   Vehiculo   |  Fecha Compra  |  Fecha Entrega  |");

            Console.WriteLine("|======================================================================|");

            Console.WriteLine("|     Subtotal     |    IVA    |     Descuento     |       Total       |");

            Console.WriteLine("|======================================================================|");

            Console.WriteLine("\n");
        }
        private void Agregarventas()
        {
            Console.WriteLine("Agregar una venta");
            Console.WriteLine("-----------------");
            Console.WriteLine("Ingrese Id de cliente");
            int idcliente = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingresar vehiculo");
            int idvehiculo = int.Parse(Console.ReadLine());
            Console.WriteLine("Ingresar fecha de compra");
            DateTime fechacompra = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Ingresar fecha de entrega");
            DateTime fechaentrega = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Ingresar subtotal");
            double subtotal = Double.Parse(Console.ReadLine());
            Console.WriteLine("Ingresar IVA");
            double iva = Double.Parse(Console.ReadLine());
            Console.WriteLine("Ingresar descuento");
            double descuento = Double.Parse(Console.ReadLine());
            //Console.WriteLine("Ingresar total");
            //double total = Double.Parse(Console.ReadLine());
            double total = subtotal + iva - descuento;

            Ventas nuevaVenta = new Ventas(idcliente, idvehiculo, fechacompra, fechaentrega, subtotal, iva,
                                           descuento, total);
            //listaVentas.Add(nuevaVenta);

            Console.WriteLine("¡Venta agregada con éxito!");
        }


        private void EliminarVentas()
        {
            Ventas venta = listaVentas.Find(v => v.IdCli == idcliente);
            if (venta != null)
            {
                listaVentas.Remove(venta);
                Console.WriteLine("¡Venta eliminada con éxito!");
            }
            else
            {
                Console.WriteLine("No se encontró una venta con ese ID de cliente.");
            }
        }
        private void Actualizarventas()
        {
            Ventas ventas = listaVentas.Find(v => v.IdCli == idcliente);
            if (ventas != null)
            {
                Console.WriteLine("Actualizar los datos de la venta:");
                Console.Write("Ingresar nueva fecha de entrega (dd/MM/yyyy): ");
                DateTime nuevaFechaEntrega = DateTime.Parse(Console.ReadLine());
                Console.Write("Ingresar nuevo subtotal: ");
                double nuevoSubtotal = double.Parse(Console.ReadLine());
                Console.Write("Ingresar nuevo IVA: ");
                double nuevoIVA = double.Parse(Console.ReadLine());
                Console.Write("Ingresar nuevo descuento: ");
                double nuevoDescuento = double.Parse(Console.ReadLine());
                double nuevoTotal = nuevoSubtotal + nuevoIVA - nuevoDescuento;

                ventas.FecEntrega = nuevaFechaEntrega;
                ventas.SubT = nuevoSubtotal;
                ventas.Iva = nuevoIVA;
                ventas.Desc = nuevoDescuento;
                ventas.Total = nuevoTotal;

                Console.WriteLine("¡Venta actualizada con éxito!");
            }
            else
            {
                Console.WriteLine("No se encontró una venta con ese ID de cliente.");
            }

        }
        public void listarventas()
        {
            
        }


    }
}
