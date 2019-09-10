using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1.Listas
{
    class Lista_Años
    {
        /*
         * Vector de años
         */

        Año[] ArrayAños = new Año[100];

        public void nuevoAño(int numeroAño)
        {
            /*
             * Vector de años
             */

            Año nuevoAño = new Año(numeroAño);

            /*
             * Agregando años al planificador
             */

            for (int i = 0; i < ArrayAños.Length; i++)
            {
                if (ArrayAños[i] == null)
                {
                    ArrayAños[i] = nuevoAño;
                    break;

                }
            }

        }

        /*
         * Agrengando mes al año del planificador
         */

        public void AgregarMes(int AñoBuscar, int mes)
        {
            for (int i = 0; i < ArrayAños.Length; i++)
            {
                if (ArrayAños[i] != null)
                {
                    if (AñoBuscar == ArrayAños[i].NumeroAño)
                    {
                        ArrayAños[i].Meses_del_año.nuevoMes(mes);
                        break;
                    }

                }
            }
        }

        /*
         * Agregando dias al mes del año del planificador
         */

        public void agregarDia(int AñoBuscar, int mesBuscar, int dia, String descrip, String imagen)
        {
            for (int i = 0; i < ArrayAños.Length; i++)
            {
                if (ArrayAños[i] != null)
                {
                    if (AñoBuscar == ArrayAños[i].NumeroAño)
                    {
                        ArrayAños[i].Meses_del_año.agregarDia(mesBuscar, dia, descrip, imagen);
                        break;
                    }

                }
            }
        }

        /*
         * Metodo que devuelve un valor booleano que representa si el año a insertar en el planificador
         * ya existe o no
         */

        Boolean paso;
        public Boolean buscarAño(int añoBuscado)
        {
            paso = true;
            for (int i = 0; i < ArrayAños.Length; i++)
            {
                if (ArrayAños[i] != null)
                {
                    if (ArrayAños[i].NumeroAño == añoBuscado) {
                        paso = false;
                    }


                }
            }
            if (paso) { return true; }
            else { return false; }
        }

        /*
         * Metodo que hereda de la clase lista_Meses para buscar desde su instancia si el mes ya existe
         * en el año seleccionado del planificador
         */

        public Boolean buscarMes(int añoBuscado, int mesBuscado)
        {
            paso = true;
            for (int i = 0; i < ArrayAños.Length; i++)
            {
                if (ArrayAños[i] != null)
                {
                    if (ArrayAños[i].NumeroAño == añoBuscado)
                    {
                        if (!ArrayAños[i].Meses_del_año.buscarMes(mesBuscado)) {
                            //Console.WriteLine("Encontre el mes en AÑo");
                            paso = false;
                        }
                        
                    }


                }
            }
            if (paso) { return true; }
            else { return false; }
        }

        /*
         * Metodo que hereda de la clase lista_meses y esta hereda de lista_dias, para verificar si ya existe 
         * el dia en el mes seleccionado de dicho año seleccionado del planificador
         */
        public Boolean buscarDia(int añoBuscado, int mesBuscado, int diaBuscado, String descrip)
        {
            paso = true;
            for (int i = 0; i < ArrayAños.Length; i++)
            {
                if (ArrayAños[i] != null)
                {
                    if (ArrayAños[i].NumeroAño == añoBuscado)
                    {
                        if (!ArrayAños[i].Meses_del_año.buscarDia(mesBuscado, diaBuscado, descrip))
                        {
                            //Console.WriteLine("Encontre el dia del mes en AÑo");
                            paso = false;
                        }

                    }


                }
            }
            if (paso) { return true; }
            else { return false; }
        }

        /*
         * Metodo que agrega el planificador al treeView y al calendario
         */

        public void mostrarAño(String plan)
        {
            for (int i = 0; i < ArrayAños.Length; i++)
            {
                if (ArrayAños[i] != null)
                {
                    //Console.WriteLine("El Año es: " + ArrayAños[i].NumeroAño);
                    Interface1.Singleton.addNodosTreeView(1, plan, ArrayAños[i].NumeroAño.ToString(), "", "", "", "");
                    /*
                     * Proceso que manda a crear nodos meses para los años del planificador
                     */
                    ArrayAños[i].Meses_del_año.mostrarMeses(plan, ArrayAños[i].NumeroAño.ToString());


                }
            }
        }

        /*
         * Metodo que hereda de lista_meses y esta de lista_dias par verificar la actividad del dia,
         * asi como tambien el path de la imagen del dia
         */

        public void MostrarDescrpiciones(String año, String mes, String dia)
        {
            for (int i = 0; i < ArrayAños.Length; i++)
            {
                if (ArrayAños[i] != null)
                {
                    if (ArrayAños[i].NumeroAño == int.Parse(año))
                    {
                        ArrayAños[i].Meses_del_año.MostrarDescripciones(mes, dia);
                    }


                }
            }
        }
    }
}
