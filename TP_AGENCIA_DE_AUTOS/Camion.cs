using SistemaGestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_AGENCIA_DE_AUTOS
{
    internal class Camion : Vehiculo
    {
        //
        private bool caja_carga;
        private string dimension_caja;
        private int carga_max;


        //
        public Camion(int id_vehiculo, string patente, int kilometro, short anio, int id_marca, string modelo, int id_segmento, int id_combustible, float precio_vta, bool t_observaciones, string observaciones, bool caja_carga, string dimension_caja, int carga_max) : base(id_vehiculo, patente, kilometro, anio, id_marca, modelo, id_segmento, id_combustible, precio_vta, t_observaciones, observaciones)
        {

        }



        //
        public override void Marca()
        {
            //
        }

        //
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