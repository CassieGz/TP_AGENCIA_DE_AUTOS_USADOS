using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_AGENCIA_DE_AUTOS
{
    internal class Combustible
    {
        //PROPIEDADES PRIVADAS
        private int id_combustible;
        private string nombre_combustible;

        //CONSTRUCTORES
        public Combustible()
        {
            this.Id_Combustible = 0;
            this.Nombre_Combustible = " ";
        }

        public Combustible(int id, string nombre)
        {
            this.Id_Combustible= id;
            this.Nombre_Combustible= nombre; 
        }

        //METODOS
        public void MostrarCombustibles()
        {
            Console.WriteLine("id Combustible:{0} Combustible: {1}",this.Id_Combustible,this.Nombre_Combustible);
        }

        //PROPIEDADES PUBLICAS

        public int Id_Combustible
        {
            get { return this.id_combustible; }
            set { this.id_combustible = value; }

        }

        public string Nombre_Combustible
        {
            get { return this.nombre_combustible; }
            set { this.nombre_combustible = value; }
        }
    }
}
