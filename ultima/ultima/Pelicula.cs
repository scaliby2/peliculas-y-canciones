using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ultima
{
     public class Pelicula : Medio
    {
        public int calificacion;

        public Pelicula(string nombre, int año, string genero, int calificacion) : base(nombre, año, genero)
        {
            this.calificacion = calificacion;
        }

        public override string MostrarDescripcion()
        {
            return "La pelicula " + nombre + " es del genero " + genero;
        }
    }
}
