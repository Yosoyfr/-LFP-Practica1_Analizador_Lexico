using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1
{
    class Mes
    {
        /*
         * Atributos del Mes
         */

        private int numeroMes;
        private Lista_Dias dias_del_mes;


        /*
         * Constructor del objeto Mes
         */

        public Mes(int numeroMes)
        {
            this.numeroMes = numeroMes;
            dias_del_mes = new Lista_Dias();
        }

        /*
         * Accesores y modificadores de todos los atributos
         */

        public int NumeroMes
        {
            set { this.numeroMes = value; }
            get { return this.numeroMes; }
        }
       
        public Lista_Dias Dias_del_mes
        {
            set { this.dias_del_mes = value; }
            get { return this.dias_del_mes; }
        }

    }

}
