using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ultima
{
   public abstract class  Medio
    {
        public string nombre, genero;
        public int año;
        public  Medio(string nombre, int año, string genero)
        {
            this.nombre = nombre;
            this.año = año;
            this.genero = genero;
        }
        public abstract string MostrarDescripcion();
        
    }
}
