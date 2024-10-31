using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_AGENCIA_DE_AUTOS
{
    internal class Localidad
    {
        //PROPIEDADES PRIVADAS
        private int id_localidad;
        private string nombre_localidad;
        //CONSTRUCTORES
        public Localidad()
        {
            this.id_localidad = 0;
            this.nombre_localidad = "";
            
        }

        public Localidad(int id,string nombre)
        {
            this.id_localidad= id;
            this.nombre_localidad= nombre;    
        }

        //METODOS
        public void MostrarLocalidades()
        {
            Console.WriteLine("Id Localidad:[0] Localidad:[1]",this.id_localidad,this.Nombre_Localidad);  
        }

        //PROPIEDADES PUBLICAS
        public int Id_Localidad
        {
            get { return this.id_localidad; }
            set { this.id_localidad = value; }
        }
        public string Nombre_Localidad
        {
            get { return this.nombre_localidad; }
            set { this.nombre_localidad = value; }
        }
    }
}
