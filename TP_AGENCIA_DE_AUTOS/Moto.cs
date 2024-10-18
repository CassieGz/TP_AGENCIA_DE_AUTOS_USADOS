
using SistemaGestion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_AGENCIA_DE_AUTOS
{
    internal class Moto : Vehiculo
    {
        //prop priv
        private string cilindrada;


        //constr
        public Moto()
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