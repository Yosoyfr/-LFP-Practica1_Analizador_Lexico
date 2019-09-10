using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1
{
    class Año
    {

        /*
         * Atributos del Año
         */

        private int numeroAño;
        private Lista_Meses meses_del_año;

        /*
        * Constructor del objeto Año
        */

        public Año(int numeroAño)
        {
            this.numeroAño = numeroAño;
            meses_del_año = new Lista_Meses();
        }

        /*
         * Accesores y modificadores de todos los atributos
         */

        public int NumeroAño
        {
            set { this.numeroAño = value; }
            get { return this.numeroAño; }
        }

        public Lista_Meses Meses_del_año
        {
            set { this.meses_del_año = value; }
            get { return this.meses_del_año; }
        }
    }
}
