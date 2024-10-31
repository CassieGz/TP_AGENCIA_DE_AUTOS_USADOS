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
            this.id_combustible = 0;
            this.nombre_combustible = " ";
        }

        public Combustible(int id, string nombre)
        {
            this.id_combustible= id;
            this.nombre_combustible= nombre; 
        }

        //METODOS
        public void MostrarCombustibles()
        {
            Console.WriteLine("id Combustible:[0] Combustible: [1]",this.Id_Combustible,this.Nombre_Combustible);
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
            set { this.Nombre_Combustible = value; }
        }
    }
}
