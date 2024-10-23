using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TP_AGENCIA_DE_AUTOS
{
    internal class Segmento
    {
        //PROPIEDADES PRIVADAS
        private int id_segmento;
        private string nombreSeg;

        //CONSTRUCTORES

        public Segmento()
        {
            this.id_segmento = 0;
            this.nombreSeg = " ";
        }
        public Segmento(int id_Seg,string segmento)
        {
            this.id_segmento = id_Seg;
            this.nombreSeg = segmento;  
        }


        //METODOS

        public void MostrarDatosSegmento()
        {
            Console.WriteLine("Id Segmento: [0], Segmento: [1]", this.id_segmento,this.nombreSeg);
        }



        //PROPIEDADES PUBLICAS
        public int Id_Segmento
        {
            get { return this.id_segmento; }
            set { this.id_segmento = value; }
        }

        public string NombreSeg
        {
            get { return this.nombreSeg; }
            set { this.nombreSeg = value; }
        }
    }
}
