using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1
{
    class Lista_Meses
    {
        /*
         * Vector de dias
         */

         Mes[] ArrayMeses = new Mes[100];

        /*
         * Agrengando mes al año del planificador
         */

        public void nuevoMes(int numeroMes)
        {
           
            Mes nuevoMes = new Mes(numeroMes);

            for (int i = 0; i < ArrayMeses.Length; i++)
            {
                if (ArrayMeses[i] == null)
                {
                    ArrayMeses[i] = nuevoMes;
                    break;

                }
            }

        }

        /*
         * Agregando dias al mes del año del planificador
         */

        public void agregarDia(int mesBuscar, int dia, String descrip, String imagen)
        {
            for (int i = 0; i < ArrayMeses.Length; i++)
            {
                if (ArrayMeses[i] != null)
                {
                    if (mesBuscar == ArrayMeses[i].NumeroMes) {
                        ArrayMeses[i].Dias_del_mes.nuevoDia(dia, descrip, imagen);
                        break;
                    }

                }
            }
        }

        /*
         * Metodo que devuelve un booleano que representa si existe el mes en el año del 
         * planificador seleccionado
         */

        Boolean paso;
        public Boolean buscarMes(int mesBuscado)
        {
            paso = true;
            for (int i = 0; i < ArrayMeses.Length; i++)
            {
                if (ArrayMeses[i] != null)
                {
                    if (ArrayMeses[i].NumeroMes == mesBuscado)
                    {
                        //Console.WriteLine("Encontre el mes en mes");
                        paso = false;
                    }

                }
            }
            if (paso) { return true; }
            else { return false; }
        }

        /*
         * Metodo que hereda de Lista_dias que devuelve un valor booleano si el dia ya 
         * existe en el mes del año del planificador seleccionado
         */

        public Boolean buscarDia(int mesBuscado, int diaBuscado, String descrip)
        {
            paso = true;
            for (int i = 0; i < ArrayMeses.Length; i++)
            {
                if (ArrayMeses[i] != null)
                {
                    if (ArrayMeses[i].NumeroMes == mesBuscado)
                    {
                        if (!ArrayMeses[i].Dias_del_mes.buscarDia(diaBuscado, descrip)) {
                            //Console.WriteLine("Encontre el dia del mes en mes");
                            paso = false;
                        }
                       
                    }

                }
            }
            if (paso) { return true; }
            else { return false; }
        }

        /*
         * Metodo que agrega el dia al mes del año seleccionado del planificador
         * al treeView y al calendario
         */


        public void mostrarMeses(String plan, String año)
        {
            for (int i = 0; i < ArrayMeses.Length; i++)
            {
                if (ArrayMeses[i] != null)
                {
                    //Console.WriteLine("El mes es: " + ArrayMeses[i].NumeroMes);
                    Interface1.Singleton.addNodosTreeView(2, plan, año, ArrayMeses[i].NumeroMes.ToString(), "", "", "");
                    /*
                    * Proceso que manda a crear nodos dias para los meses de los años del planificador
                    */
                    ArrayMeses[i].Dias_del_mes.mostrarDias(plan, año, ArrayMeses[i].NumeroMes.ToString());
                    

                }
            }
        }

        /*
         * Metodo que hereda de lista_dias par verificar la actividad del dia,
         * asi como tambien el path de la imagen del dia
         */

        public void MostrarDescripciones(String mes, String dia)
        {
            for (int i = 0; i < ArrayMeses.Length; i++)
            {
                if (ArrayMeses[i] != null)
                {
                    if (ArrayMeses[i].NumeroMes == int.Parse(mes))
                    {
                        ArrayMeses[i].Dias_del_mes.MostrarDescripciones(dia);
                    }

                }
            }
        }
    }
}
