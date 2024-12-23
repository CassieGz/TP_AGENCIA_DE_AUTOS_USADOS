﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_AGENCIA_DE_AUTOS
{
    internal class Venta
    {
        private int id_cli;
        private int id_veh;
        private DateTime fec_compra;
        private DateTime fec_entrega;
        private double sub_t;
        private double iva;
        private double desc;
        private static List<Venta> listaVentas = new List<Venta>();

        public Venta() { }
        public Venta(int idcliente, int idvehiculo, DateTime fechacompra, DateTime fechaentrega,
                      double subtotal, double iva, double descuento)
        {
            if (fechacompra > fechaentrega)
                throw new ArgumentException("La fecha de compra no puede ser posterior a la fecha de entrega.");

            this.id_cli = idcliente;
            this.id_veh = idvehiculo;
            this.fec_compra = fechacompra;
            this.fec_entrega = fechaentrega;
            this.sub_t = subtotal;
            this.iva = iva;
            this.desc = descuento;
           // this.Total = total;
        }
        public int IdCli
        {
            get { return this.IdCli; }
            set { this.IdCli = value; }
        }
        public int IdVeh
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
        //propiedades de solo lectura
        public double Iva
        {
            get { return (SubTotal - Desc) * (Iva / 100); }
        
            //get { return this.iva; }
            //set { this.iva = value; }
        }
        public double Desc
        {
            get { return SubTotal * (desc / 100); }
            //get { return this.Desc; }
            //set { this.Desc = value; }
        }
        public double Total
        {
            get { return (SubTotal - Desc) + Iva; }
           // get { return this.total; }
            //set { this.total = value; }
        }
        public void CargarVentas()
        {
            FileStream Archivo = new FileStream("ventas.csv", FileMode.Open);
            StreamReader Leer = new StreamReader(Archivo);

            while (!Leer.EndOfStream)
            {
                string cadena = Leer.ReadLine();
                string[] datos = cadena.Split(',');
                Venta ventas = new Venta();
                listaVentas.Add(ventas);
            }
            Archivo.Close();
            Leer.Close();
        }
        public void Mostrarventa()
        {
            Console.WriteLine("|======================================================================|");

            Console.WriteLine("|  ID  |   Cliente   |   Vehiculo   |  Fecha Compra  |  Fecha Entrega  |");

            Console.WriteLine("|======================================================================|");

            Console.WriteLine("|     Subtotal     |    IVA    |     Descuento     |       Total       |");

            Console.WriteLine("|======================================================================|");

            Console.WriteLine("\n");
        }
        public void Agregarventa()
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

            Venta nuevaVenta = new Venta(idcliente, idvehiculo, fechacompra, fechaentrega, subtotal, iva,
                                           descuento);
            listaVentas.Add(nuevaVenta);

            Console.WriteLine("¡Venta agregada con éxito!");
        }


        public void EliminarVenta(int idcli)
        {
            Venta venta = listaVentas.Find(v => v.IdCli == idcli);
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
        public void Actualizarventa(int idcli)
        {
            Venta ventas = listaVentas.Find(v => v.IdCli == idcli);
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
                //double nuevoTotal = nuevoSubtotal + nuevoIVA - nuevoDescuento;
                //ventas.fec_entrega = nuevaFechaEntrega;
                //ventas.sub_t= nuevoSubtotal;
                //ventas.Iva = nuevoIVA;
                //ventas.Desc = nuevoDescuento;
                //ventas.Total = nuevoTotal;

                Console.WriteLine("¡Venta actualizada con éxito!");
            }
            else
            {
                Console.WriteLine("No se encontró una venta con ese ID de cliente.");
            }
        }
        public void Listarventa()
        {
            Console.WriteLine("|======================================================================|");
            Console.WriteLine("|  ID  |   Cliente   |   Vehiculo   |  Fecha Compra  |  Fecha Entrega  |");
            Console.WriteLine("|======================================================================|");
            Console.WriteLine("|     Subtotal     |    IVA    |     Descuento     |       Total       |");
            Console.WriteLine("|======================================================================|");

            foreach (Venta ventas in listaVentas)
            {
                Console.WriteLine($"ID: {ventas.IdCli},Cliente:" + $"Vehiculo: {ventas.id_veh}, " + 
                                  $"Fecha Compra: {ventas.fec_compra}, " +
                                  $"Fecha Entrega: {ventas.fec_entrega}, " + $"Subtotal: {ventas.SubTotal}," +
                                  $" IVA: {ventas.iva}"+ $"Descuento: {ventas.Desc}" + $"Total:{ventas.Total}");
            }
        }
    }
}
    

