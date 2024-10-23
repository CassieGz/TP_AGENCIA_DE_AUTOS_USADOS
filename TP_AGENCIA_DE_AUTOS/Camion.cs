using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_AGENCIA_DE_AUTOS
{
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



        //metodo

        public override void MostrarDatos()
        {
            Console.WriteLine($"Id Vehiculo:{this.Id_Vehiculo} - Patente:{this.Patente} - Kilometro:{this.Kilometro} - Año:{this.Anio} - Id Marca:{this.Id_Marca} - Modelo:{this.Modelo} - Id Segmento:{this.Id_segmento} - Id Combustible:{this.Id_combustible} - Precio de venta:{this.Precio_vta} - Hay observaciones:" ,this.Tobservaciones ? "Si" : "No",$" - Observaciones:{this.Observaciones} - Color: {this.Color} - Caja de carga:{this.Caja_carga} - Dimension:{this.Dimension_caja} - Carga maxima:{this.Carga_max}.");
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
}