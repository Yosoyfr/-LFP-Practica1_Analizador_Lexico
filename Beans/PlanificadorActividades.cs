using Practica1.Listas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1
{
    class PlanificadorActividades
    {

        /*
        * Atributos del planificador de actividades
        */

        private String planificador;
        private Lista_Años años_actividades;


        /*
        * Constructor del objeto planificador de actividades
        */

        public PlanificadorActividades(String planificador)
        {
            this.planificador = planificador;
            años_actividades = new Lista_Años();
        }

        /*
         * Accesores y modificadores de todos los atributos
         */

        public String Planificador
        {
            set { this.planificador = value; }
            get { return this.planificador; }
        }

        public Lista_Años Años_actividades
        {
            set { this.años_actividades = value; }
            get { return this.años_actividades; }
        }
    }
}
