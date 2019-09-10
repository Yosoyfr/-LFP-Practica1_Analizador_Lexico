using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1
{
    class Lista_Dias
    {
        /*
         * Vector de dias
         */

         Dia[] ArrayDias = new Dia[100];

        /*
         * Agregando dias al mes del año del planificador
         */
        public void nuevoDia(int numeroDia, String descripcion, String rutaImagen)
        {
            String des = descripcion.Trim(new Char[] { '\"' });
            Dia nuevoDia = new Dia(numeroDia, des, rutaImagen);

            for (int i = 0; i < ArrayDias.Length; i++)
            {
                if (ArrayDias[i] == null)
                {
                    ArrayDias[i] = nuevoDia;
                    break;

                }
            }

        }

        Boolean paso;
        public Boolean buscarDia(int diaBuscado, String descripcion)
        {
            paso = true;
            String des = descripcion.Trim(new Char[] { '\"' });
            for (int i = 0; i < ArrayDias.Length; i++)
            {
                if (ArrayDias[i] != null)
                {
                    if (ArrayDias[i].NumeroDia == diaBuscado)
                    {
                        if (des.ToLower().Equals(ArrayDias[i].Descripcion.ToLower()))
                        {
                        }
                        else {
                            ArrayDias[i].Descripcion = ArrayDias[i].Descripcion + ", " + des;
                        }
                        paso = false;
                    }

                }
            }
            if (paso) { return true; }
            else { return false; }
        }

        public void mostrarDias(String plan, String año, String mes)
        {
            for (int i = 0; i < ArrayDias.Length; i++)
            {
                if (ArrayDias[i] != null)
                {
                    //Console.WriteLine("El dia es: " + ArrayDias[i].NumeroDia);
                    //Console.WriteLine("La Actividad a realizar es: " + ArrayDias[i].Descripcion);
                    //Console.WriteLine("La ruta de la imagen es: " + ArrayDias[i].Imagen);
                    /*
                    * Proceso final de inserccion de toda clase de nodos pertenecientes al planificador
                    */
                    Interface1.Singleton.addNodosTreeView(3, plan, año, mes, ArrayDias[i].NumeroDia.ToString(),
                        ArrayDias[i].Descripcion, ArrayDias[i].Imagen);
                   

                }
            }
        }

        /*
         * Metodo que verificara la actividad del dia,
         * asi como tambien el path de la imagen del dia
         */

        public void MostrarDescripciones(String dia)
        {
            try { 
                for (int i = 0; i < ArrayDias.Length; i++)
                {
                    if (ArrayDias[i] != null)
                    {
                        if (ArrayDias[i].NumeroDia == int.Parse(dia))
                        {
                            //Console.WriteLine("La descripcion del dia es: " + ArrayDias[i].Descripcion);
                            String descrip = ArrayDias[i].Descripcion.Trim(new Char[] { '\"' });
                            Interface1.Singleton.lblDescripcion.Text = descrip;
                            String pathImage = ArrayDias[i].Imagen.Trim(new Char[] { '\"' });
                            Image imagen = Image.FromFile(pathImage);
                            Interface1.Singleton.pictureBox1.Image = imagen;

                        }

                }
                }
                }
                catch { }
        }
    }
}
