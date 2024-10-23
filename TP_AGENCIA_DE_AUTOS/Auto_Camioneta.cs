Prog_Segmento
﻿using System;

using System;
main
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_AGENCIA_DE_AUTOS
{
    internal class Auto_Camioneta : Vehiculo
    {
Prog_Segmento

        public override void marca()
        public Auto_Camioneta(int id_vehiculo, string patente, int kilometro, short anio, int id_marca, string modelo, int id_segmento, int id_combustible, float precio_vta, bool t_observaciones, string observaciones) : base(id_vehiculo, patente, kilometro, anio, id_marca, modelo, id_segmento, id_combustible, precio_vta, t_observaciones, observaciones);


        

        //constructor
        public Auto_Camioneta(int id_vehiculo, string patente, int kilometro, short anio, int id_marca, string modelo, int id_segmento, int id_combustible, float precio_vta, bool t_observaciones, string observaciones, string color) : base(id_vehiculo, patente, kilometro, anio, id_marca, modelo, id_segmento, id_combustible, precio_vta, t_observaciones, observaciones, color)
main
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

Prog_Segmento
        public override void Marca()


        //metodo
        public override void MostrarDatos()
main
        {
            Console.WriteLine($"Id Vehiculo:{this.Id_Vehiculo} - Patente:{this.Patente} - Kilometro:{this.Kilometro} - Año:{this.Anio} - Id Marca:{this.Id_Marca} - Modelo:{this.Modelo} - Id Segmento:{this.Id_segmento} - Id Combustible:{this.Id_combustible} - Precio de venta:{this.Precio_vta} - Hay observaciones:",this.Tobservaciones ? "Si" : "No",$" - Observaciones:{this.Observaciones} - Color: {this.Color}.");
        }
        
        //sin get ni set porque todo lo toma de vehiculo de herencia

    }
}
