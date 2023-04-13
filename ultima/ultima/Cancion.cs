using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ultima
{
    public class Cancion:Medio
    {
        public string artista;

        public Cancion(string nombre, int año, string genero, string artista) : base(nombre, año, genero)
        {
            this.artista = artista;
        }

        public override string MostrarDescripcion()
        {
           return artista;
        }
    }
}
