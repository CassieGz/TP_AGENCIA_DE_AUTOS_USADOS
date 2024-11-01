
using SistemaGestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace TP_AGENCIA_DE_AUTOS
{
    internal class Moto : Vehiculo
    {
        //prop priv
        private string cilindrada;
        //constr
        public Moto(int id_vehiculo, string patente, int kilometro, short anio, int id_marca, 
                    string modelo, int id_segmento, int id_combustible, float precio_vta,
                    bool t_observaciones, string observaciones, string cilindrada)
                   : base(id_vehiculo, patente, kilometro, anio, id_marca,  modelo,  id_segmento, 
                    id_combustible,  precio_vta, t_observaciones, observaciones)
        {

        }
        

        //metod
        public override void Marca()
        {
            //
        }

        //public
        public string Cilindrada
        {
            get { return this.cilindrada; }
            set { this.cilindrada = value; }
        }
    }
}