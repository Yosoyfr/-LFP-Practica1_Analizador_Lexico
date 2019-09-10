using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1
{
    class Dia
    {
        /*
          * Atributos del dia
          */

        private String descripcion, imagen;
        private int numeroDia;

        /*
         * Constructor del objeto Dia
         */

        public Dia(int numeroDia, String descripcion, String imagen)
        {
            this.numeroDia = numeroDia;
            this.descripcion = descripcion;
            this.imagen = imagen;
        }

        /*
         * Accesores y modificadores de todos los atributos
         */


        public int NumeroDia
        {
            set { this.numeroDia = value; }
            get { return this.numeroDia; }
        }
        public String Descripcion
        {
            set { this.descripcion = value; }
            get { return this.descripcion; }
        }

        public String Imagen
        {
            set { this.imagen = value; }
            get { return this.imagen; }
        }
    }


}

