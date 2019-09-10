using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1.Listas
{
    class Lista_Planificadores
    {

        /*
         * Patron Singleton
         */

        public static Lista_Planificadores instance = null;

        public static Lista_Planificadores Singleton
        {
            get
            {
                if (instance == null)
                {
                    instance = new Lista_Planificadores();

                }
                return instance;
            }
        }

        /*
         * Termina el Singleton
         */

        /*
         * Vector de Planificadores
         */

        static PlanificadorActividades[] ArrayPlanificador = new PlanificadorActividades[100];

        /*
         * Metodo para crear nuevos planificadores
         */
        Boolean existenciaPlan;

        public void nuevoPlanificadorActividades(String planificador)
        {
            existenciaPlan = true;

            PlanificadorActividades nuevoPlanificadorActividades = new PlanificadorActividades(planificador.Trim(new Char[] { '\"' }));

            /*
             * Si ya existe el planificador no lo agregara
             */

            for (int i = 0; i < ArrayPlanificador.Length; i++)
            {

                if (ArrayPlanificador[i] != null && ArrayPlanificador[i].Planificador.Equals(planificador.Trim(new Char[] { '\"' })))
                {
                    
                    existenciaPlan = false;
                }
            }

            /*
             *Si no existe el planificador lo agregara
             */

            for (int i = 0; i < ArrayPlanificador.Length; i++)
            {
                
                if (ArrayPlanificador[i] == null && existenciaPlan)
                {
                    ArrayPlanificador[i] = nuevoPlanificadorActividades;
                    break;

                }
            }

        }

        /*
         * Metodo para agregar año al planificador buscado
         */
        Boolean existenciaAño;
        public void AgregarAño(String planificadorBuscar, int año)
        {

            /*
             * Si ya existe el año no lo agregara
             */

            existenciaAño = true;

            for (int i = 0; i < ArrayPlanificador.Length; i++)
            {
                if (ArrayPlanificador[i] != null)
                {
                    if (planificadorBuscar.Trim(new Char[] { '\"' }).Equals(ArrayPlanificador[i].Planificador))
                    {
                        if (!ArrayPlanificador[i].Años_actividades.buscarAño(año)) {
                            
                            existenciaAño = false;
                        }
                    }

                }
            }

            /*
             * Si no existe lo agregara normal en el planificador especificado
             */

            for (int i = 0; i < ArrayPlanificador.Length; i++)
            {
                if (ArrayPlanificador[i] != null)
                {
                    if (planificadorBuscar.Trim(new Char[] { '\"' }).Equals(ArrayPlanificador[i].Planificador) && existenciaAño)
                    {
                        ArrayPlanificador[i].Años_actividades.nuevoAño(año);
                        break;
                    }

                }
            }
        }

        /*
         * Metodo para agregar mes al año del planificador buscado
         */
        Boolean existenciaMes;
        public void AgregarMes(String planificadorBuscar, int añoBuscar, int mes)
        {

            /*
             * Si ya existe el mes no lo agregara
             */

            existenciaMes = true;
            for (int i = 0; i < ArrayPlanificador.Length; i++)
            {
                if (ArrayPlanificador[i] != null)
                {
                    if (planificadorBuscar.Trim(new Char[] { '\"' }).Equals(ArrayPlanificador[i].Planificador))
                    {
                        if (!ArrayPlanificador[i].Años_actividades.buscarMes(añoBuscar, mes))
                        {
                            //Console.WriteLine("Encontre mes en plan");
                            existenciaMes = false;
                        }
                    }

                }
            }

            /*
             * Si no existe lo agregara normal y pasara a leer en que año va
             */

            for (int i = 0; i < ArrayPlanificador.Length; i++)
            {
                if (ArrayPlanificador[i] != null)
                {
                    if (planificadorBuscar.Trim(new Char[] { '\"' }).Equals(ArrayPlanificador[i].Planificador) && existenciaMes)
                    {
                        ArrayPlanificador[i].Años_actividades.AgregarMes(añoBuscar, mes);
                        break;
                    }

                }
            }
        }

        /*
         *Metodo para agregar dias a los meses
         * del los años del planificador a buscar
         */
        Boolean existenciaDia;
        public void agregarDia(String planificadorBuscar, int añoBuscar, int mesBuscar, int dia, String descrip, String imagen)
        {
            existenciaDia = true;

            /*
             * Si ya existe el dia solo agregara mas descripcion
             */

            for (int i = 0; i < ArrayPlanificador.Length; i++)
            {
                if (ArrayPlanificador[i] != null)
                {
                    if (planificadorBuscar.Trim(new Char[] { '\"' }).Equals(ArrayPlanificador[i].Planificador))
                    {
                        if (!ArrayPlanificador[i].Años_actividades.buscarDia(añoBuscar, mesBuscar, dia, descrip))
                        {
                            //Console.WriteLine("Encontre el dia en plan");
                            existenciaDia = false;
                        }
                    }

                }
            }

            /*
             * Si no existe, lo agrega como uno nuevo
             */

            for (int i = 0; i < ArrayPlanificador.Length; i++)
            {
                if (ArrayPlanificador[i] != null)
                {
                    if (planificadorBuscar.Trim(new Char[] { '\"' }).Equals(ArrayPlanificador[i].Planificador) && existenciaDia)
                    {
                        ArrayPlanificador[i].Años_actividades.agregarDia(añoBuscar, mesBuscar, dia, descrip, imagen);
                        
                        break;
                    }

                }
            }
        }

        /*
         * Metodo que agregar el planificador al treeView
         */

        public void mostrarPlanificadorActividades()
        {
            for (int i = 0; i < ArrayPlanificador.Length; i++)
            {
                if (ArrayPlanificador[i] != null)
                {
                    Interface1.Singleton.addNodosTreeView(0, ArrayPlanificador[i].Planificador, "", "", "", "", "");
                    /*
                     * Proceso que manda a crear nodos años para el planificador
                     */
                    ArrayPlanificador[i].Años_actividades.mostrarAño(ArrayPlanificador[i].Planificador);


                }
            }
        }

        /*
         * Metodo que envia el planificador, año, mes y dia a buscar para obtener
         * la descripcion del dia y el path de la imagen de ese dia
         */

        public void MostrarDescripciones(String planificadorBuscar, String añoBuscar, String mesBuscar, String dia)
        {
            for (int i = 0; i < ArrayPlanificador.Length; i++)
            {
                if (ArrayPlanificador[i] != null)
                {
                    if (ArrayPlanificador[i].Planificador.Equals(planificadorBuscar)) {

                        ArrayPlanificador[i].Años_actividades.MostrarDescrpiciones(añoBuscar, mesBuscar, dia);
                    }

                    


                }
            }
        }

    }
}
