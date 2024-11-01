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
            this.Id_Segmento = 0;
            this.NombreSeg = " ";
        }
        public Segmento(int id_Seg,string segmento)
        {
            this.Id_Segmento = id_Seg;
            this.NombreSeg = segmento;  
        }


        //METODOS

        public void MostrarSegmentos()
        {
            Console.WriteLine("Id Segmento: {0}, Segmento: {1}", this.Id_Segmento,this.NombreSeg);
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
