
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
            public Moto(int id_vehiculo, string patente, int kilometro, short anio, int id_marca, string modelo, int id_segmento, int id_combustible, float precio_vta, bool t_observaciones, string observaciones, string cilindrada, string color) : base(id_vehiculo, patente, kilometro, anio, id_marca,  modelo,  id_segmento,  id_combustible,  precio_vta, t_observaciones, observaciones, color)
            {
                this.Id_Vehiculo = id_vehiculo;
                this.Patente = patente;
                this.Kilometro = kilometro;
                this.Anio = anio;
                this.Id_Marca = id_marca;
                this.Modelo = modelo;
                this.Id_segmento = id_segmento;
                this.Id_combustible = id_combustible;
                this.Precio_vta = precio_vta;
                this.Tobservaciones = t_observaciones;
                if (this.Tobservaciones)
                {
                    this.Observaciones = observaciones;
                }
                else
                {
                    this.Observaciones = " - ";
                }
                this.Color = color;
                this.Cilindrada = cilindrada;

            }

            //metod
            public override void MostrarDatos()
            {
                Console.WriteLine($"Id Vehiculo:{this.Id_Vehiculo} - Patente:{this.Patente} - Kilometro:{this.Kilometro} - Año:{this.Anio} - Id Marca:{this.Id_Marca} - Modelo:{this.Modelo} - Id Segmento:{this.Id_segmento} - Id Combustible:{this.Id_combustible} - Precio de venta:{this.Precio_vta} - Hay observaciones:" ,this.Tobservaciones ? "Si" : "No", $" - Observaciones:{this.Observaciones} - Color: {this.Color} - Cilindrada:{this.Cilindrada}.");
            }

            //public
            public string Cilindrada
            {
                 get { return this.cilindrada; }
                 set { this.cilindrada = value; }
            }

        }
    }
