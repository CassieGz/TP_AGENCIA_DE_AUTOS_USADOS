
using SistemaGestion;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sistemagestion
{
    internal class auto_camioneta : Vehiculo
    { 
        public auto_camioneta(int id_vehiculo, string patente, int kilometro, short anio, 
                              int id_marca, string modelo, int id_segmento, int id_combustible,
                              float precio_vta, bool t_observaciones, string observaciones) 
                              : base(id_vehiculo, patente, kilometro, anio, id_marca, modelo, id_segmento, 
                                    id_combustible, precio_vta, t_observaciones, observaciones)

        {
           
        }
        public override void Marca()
        {
         
        }

    }
}
