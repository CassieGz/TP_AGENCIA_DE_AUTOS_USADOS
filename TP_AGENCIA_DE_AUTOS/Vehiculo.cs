using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestion
{
    internal abstract class Vehiculo
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
        private string observaciones;
        // validacion if de si es true poder llenar el string else no poder hacerlo

        private string color;


        //

        public Vehiculo(int id_vehiculo, string patente, int kilometro, short anio, int id_marca, string modelo, int id_segmento, int id_combustible, float precio_vta, bool t_observaciones, string observaciones)
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
            this.Observaciones = observaciones;
        }

     


        //
        
        public abstract void Marca();


        //
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

        //


    }
}