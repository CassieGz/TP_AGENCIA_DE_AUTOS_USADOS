using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_AGENCIA_DE_AUTOS
{
    internal class Provincia
    {
        //PROPIEDADES PRIVADAS
        private int id_provincia;
        private string nombre_provincia;

        //CONSTRUCTORES
        public Provincia()
        {
            this.id_provincia = 0;
            this.nombre_provincia = " ";
        }

        public Provincia(int id_pcia,string nombrePro)
        {
            this.id_provincia=id_pcia;
            this.nombre_provincia=nombrePro;    
        }

        //METODOS
        public void MostrarProvincias()
        {
            Console.WriteLine("id Provincia: [0] Provincia: [1]", this.Id_provincia, this.Nombre_Provincia);
        }

        //PROPIEDADES PUBLICAS

        public int Id_provincia
        {
            get { return this.id_provincia; }
            set { this.id_provincia = value; }
        }

        public string Nombre_Provincia
        {
            get { return this.nombre_provincia; }
            set { this.nombre_provincia = value; }
        }
        
    }
}
