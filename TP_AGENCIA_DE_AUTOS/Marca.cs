using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_AGENCIA_DE_AUTOS
{
    
    internal class Marca
    {
        //prop priv
        private int id_marca;
        private string marc;
        
        //constr
        public Marca(int id_marca, string marc)
        {
            this.Id_marca = id_marca;
            this.Marc = marc;
        }
        //metodo
        public void MostrarDatos()
        {
            Console.WriteLine($"Id Marca: {this.Id_marca} - Marca: {this.Marc}");

        }
        //get set
        public int Id_marca
        {
            get { return this.id_marca; }
            set { this.id_marca = value; }
        }
        public string Marc
        {
            get { return this.marc; }
            set { this.marc = value; }
        }
    }
}

