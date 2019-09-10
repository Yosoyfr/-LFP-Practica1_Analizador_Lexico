using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1
{
    class Token
    {
        /*
         * Lista de Tokens permitidos para esta practica
         */
        public enum Tipo
        {
            Reservada_Planificador,
            Reservada_Anio,
            Reservada_Mes,
            Reservada_Dia,
            Signo_Corchete_Izq,
            Signo_Corchete_Dech,
            Signo_Parentesis_Dech,
            Signo_Parentesis_Izq,
            Signo_Llaves_Dech,
            Signo_Llaves_Izq,
            Signo_Dos_Puntos,
            Signo_Punto_y_Coma,
            Signo_mayor_que,
            Signo_menor_que,
            Reservada_Descripcion,
            Reservada_Imagen,
            Cadena,
            Numero,
            Desconocido,
            Reservada_No_Encontrada
        }

        /*
         * Atributos del token
         */

        private Tipo tipoToken;
        private String valor;
        private int linea;
        private int columna;

        /*
         * Constructor del Token, esperando el tipo de la lista anterior y el valor que va a tomar
         */

        public Token(Tipo tipoToken, String valor, int linea, int columna)
        {
            this.tipoToken = tipoToken;
            this.valor = valor;
            this.linea = linea;
            this.columna = columna;
        }

        /*
         * Accesores de los atributos del objeto Token
         */
        public String GetValor
        {
            get { return this.valor; }
        }

        public int GetLinea
        {
            get { return this.linea; }
        }

        public int GetColumna
        {
            get { return this.columna; }
        }

        /*
         * Dependiendo del contexto que se el tipo del token
         * devolvera el valor deseado
         */

        public String GetTipo
        {
            get {
                switch (tipoToken)
                {
                    case Tipo.Reservada_Planificador:
                        return "Reservada Planificador";
                    case Tipo.Reservada_Anio:
                        return "Reservada Anio";
                    case Tipo.Reservada_Mes:
                        return "Reservada Mes";
                    case Tipo.Reservada_Dia:
                        return "Reservada Dia";
                    case Tipo.Reservada_Descripcion:
                        return "Reservada Descripcion";
                    case Tipo.Reservada_Imagen:
                        return "Reservada Imagen";
                    case Tipo.Signo_Corchete_Dech:
                        return "Corchete Derecho";
                    case Tipo.Signo_Corchete_Izq:
                        return "Corchete Izquierdo";
                    case Tipo.Signo_Dos_Puntos:
                        return "Dos Puntos";
                    case Tipo.Signo_Punto_y_Coma:
                        return "Punto y Coma";
                    case Tipo.Signo_Llaves_Dech:
                        return "Llave Derecha";
                    case Tipo.Signo_Llaves_Izq:
                        return "Llave Izquierda";
                    case Tipo.Signo_Parentesis_Dech:
                        return "Parentesis Derecho";
                    case Tipo.Signo_Parentesis_Izq:
                        return "Parentesis Izquierda";
                    case Tipo.Signo_menor_que:
                        return "Menor que";
                    case Tipo.Signo_mayor_que:
                        return "Mayor que";
                    case Tipo.Cadena:
                        return "Cadena";
                    case Tipo.Numero:
                        return "Numero";
                    case Tipo.Reservada_No_Encontrada:
                        return "Identificador desconocido";
                    default:
                        return "Desconocido";
                }
            }
        }

        public String GetID
        {
            get
            {
                switch (tipoToken)
                {
                    case Tipo.Reservada_Planificador:
                        return "1";
                    case Tipo.Reservada_Anio:
                        return "2";
                    case Tipo.Reservada_Mes:
                        return "3";
                    case Tipo.Reservada_Dia:
                        return "4";
                    case Tipo.Reservada_Descripcion:
                        return "5";
                    case Tipo.Reservada_Imagen:
                        return "6";
                    case Tipo.Signo_Corchete_Dech:
                        return "7";
                    case Tipo.Signo_Corchete_Izq:
                        return "8";
                    case Tipo.Signo_Dos_Puntos:
                        return "9";
                    case Tipo.Signo_Punto_y_Coma:
                        return "10";
                    case Tipo.Signo_Llaves_Dech:
                        return "11";
                    case Tipo.Signo_Llaves_Izq:
                        return "12";
                    case Tipo.Signo_Parentesis_Dech:
                        return "13";
                    case Tipo.Signo_Parentesis_Izq:
                        return "14";
                    case Tipo.Signo_menor_que:
                        return "15";
                    case Tipo.Signo_mayor_que:
                        return "16";
                    case Tipo.Cadena:
                        return "17";
                    case Tipo.Numero:
                        return "18";
                    default:
                        return "Desconocido";
                }
            }
        }
    }
}
