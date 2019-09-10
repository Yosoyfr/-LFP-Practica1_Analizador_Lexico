using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica1
{
    class TextualTabControl : TabControl
    {
        protected override void OnControlAdded(ControlEventArgs e)
        {
            base.OnControlAdded(e);
            e.Control.Controls.Add(CreateBox());
        }

        private RichTextBox CreateBox()
        {
            RichTextBox newText = new RichTextBox();
            newText.Dock = DockStyle.Fill;
            newText.TextChanged += new EventHandler(NewText_TextChanged);
            return newText;
        }

        public void NewText_TextChanged(object sender, EventArgs e)
        {

            int estado = 0;
            String lexema = "";
            Char c;
            String entrada = SelectedRichTextBoxTex + " ";

            for (int i = 0; i < entrada.Length; i++)
            {
                c = entrada[i];
                switch (estado)
                {
                    case 0:
                        /*
                         * Revisara si puede ser una palabra reservada
                         */
                        if (Char.IsLetter(c))
                        {
                            estado = 1;
                            lexema += c;
                        }
                        /*
                         * Revisara si puede ser un numero
                         */
                        else if (Char.IsDigit(c))
                        {
                            estado = 2;
                            lexema += c;
                        }
                        /*
                         * Revisara si puede ser una cadena
                         */
                        else if (c == '"')
                        {
                            estado = 4;
                            i--;
                        }
                        /*
                         * Revisara si puede ser un espacio en blanco
                         */
                        else if (c == ' ')
                        {
                            estado = 0;
                        }
                        /*
                         * Revisara si puede ser un enter, para cambiar de linea
                         */
                        else if (c == '\n')
                        {
                            estado = 0;
                        }

                        /*
                         * Lista de Tokens ya establecidos que son todos los simbolos admitidos
                         */
                        else if (c.CompareTo('{') == 0)
                        {
                            lexema += c;
                            this.CheckKeyword(lexema, Color.Black, 0);
                            lexema = "";
                        }
                        else if (c.CompareTo('}') == 0)
                        {
                            lexema += c;
                            this.CheckKeyword(lexema, Color.Black, 0);
                            lexema = "";
                        }
                        else if (c.CompareTo('(') == 0)
                        {
                            lexema += c;
                            this.CheckKeyword(lexema, Color.Black, 0);
                            lexema = "";
                        }
                        else if (c.CompareTo(')') == 0)
                        {
                            lexema += c;
                            this.CheckKeyword(lexema, Color.Black, 0);
                            lexema = "";
                        }
                        else if (c.CompareTo('[') == 0)
                        {
                            lexema += c;
                            this.CheckKeyword(lexema, Color.Black, 0);
                            lexema = "";
                        }
                        else if (c.CompareTo(']') == 0)
                        {
                            lexema += c;
                            this.CheckKeyword(lexema, Color.Black, 0);
                            lexema = "";
                        }
                        else if (c.CompareTo('>') == 0)
                        {
                            lexema += c;
                            this.CheckKeyword(lexema, Color.Black, 0);
                            lexema = "";
                        }
                        else if (c.CompareTo('<') == 0)
                        {
                            lexema += c;
                            this.CheckKeyword(lexema, Color.Black, 0);
                            lexema = "";
                        }
                        else if (c.CompareTo(':') == 0)
                        {
                            lexema += c;
                            this.CheckKeyword(lexema, Color.Black, 0);
                            lexema = "";
                        }
                        else if (c.CompareTo(';') == 0)
                        {
                            lexema += c;
                            this.CheckKeyword(lexema, Color.Black, 0);
                            lexema = "";
                        }

                        /*
                         * Si no es ninguno de la lista de tokens, nos devuelve un error
                         */

                        else
                        {
                            estado = -1;
                            i--;
                        }
                        break;

                    case 1:
                        /*
                         * Buscara que palabra reservada es
                         */
                        if (lexema.ToLower().Equals("planificador"))
                        {
                            this.CheckKeyword(lexema.ToLower(), Color.Purple, 0);

                            lexema = "";
                            i--;
                            estado = 0;
                        }
                        else if (lexema.ToLower().Equals("anio"))
                        {
                            this.CheckKeyword(lexema.ToLower(), Color.Purple, 0);

                            lexema = "";
                            i--;
                            estado = 0;
                        }
                        else if (lexema.ToLower().Equals("mes"))
                        {
                            this.CheckKeyword(lexema.ToLower(), Color.Purple, 0);

                            lexema = "";
                            i--;
                            estado = 0;
                        }
                        else if (lexema.ToLower().Equals("dia"))
                        {
                            this.CheckKeyword(lexema.ToLower(), Color.Purple, 0);

                            lexema = "";
                            i--;
                            estado = 0;
                        }
                        else if (lexema.ToLower().Equals("descripcion"))
                        {
                            this.CheckKeyword(lexema.ToLower(), Color.Purple, 0);

                            lexema = "";
                            i--;
                            estado = 0;
                        }
                        else if (lexema.ToLower().Equals("imagen"))
                        {
                            this.CheckKeyword(lexema.ToLower(), Color.Purple, 0);

                            lexema = "";
                            i--;
                            estado = 0;
                        }
                        else if (Char.IsLetterOrDigit(c) || c == '_')
                        {
                            lexema += c;
                            estado = 1;
                        }

                        /*
                         * Si no encuentra resultados, esta palabra no existe en el lenguaje
                         */

                        else
                        {
                            this.CheckKeyword(lexema.ToLower(), Color.Red, 0);
                            estado = 0;
                            i--;
                            lexema = "";

                        }
                        break;
                    case 2:
                        /*
                         * Revisara el numero
                         */
                        if (Char.IsDigit(c))
                        {
                            lexema += c;
                            estado = 2;
                        }
                        else
                        {
                            this.CheckKeyword(lexema, Color.Aqua, 0);
                            lexema = "";
                            i--;
                            estado = 0;
                        }
                        break;
                    case 3:
                        if (Char.IsDigit(c))
                        {
                            lexema += c;
                            estado = 2;
                        }
                        else
                        {
                            estado = -1;
                            i = i - 2;
                            lexema = "";
                        }
                        break;
                    case 4:
                        /*
                         * Comprueba que es una cadena
                         */
                        if (c == '"')
                        {
                            lexema += c;
                            estado = 5;
                        }
                        break;
                    case 5:
                        /*
                         * Comprobara todos los datos que contendra la cadena,
                         * hasta encontrar otro (") para cerrar la cadena
                         */
                        if (c == '\n')
                        {
                            lexema += c;
                            estado = 5;
                        }
                        else if (c != '"')
                        {
                            lexema += c;
                            estado = 5;
                        }
                        else
                        {
                            estado = 6;
                            i--;
                        }
                        break;
                    case 6:
                        /*
                         * Aqui cierra la cadena al encontrar (")
                         */
                        if (c == '"')
                        {
                            lexema += c;
                            this.CheckKeyword(lexema.ToLower(), Color.DarkGreen, 0);
                            estado = 0;
                            lexema = "";
                        }

                        break;

                    /*
                     * Si no se cumple con ninguno de estos tipos 
                     * de tokens, devuelve un error exceptuado 
                     * saltos de linea, espacios o tabulaciones
                     */
                    case -1:
                        lexema += c;
                        if (c.CompareTo('\n') == 0 || c.CompareTo('\\') == 0 || c.CompareTo('\t') == 0 || c.CompareTo(' ') == 0 || c == 13)
                        {
                            estado = 0;
                            lexema = "";
                        }

                        else
                        {
                            Console.WriteLine("Error lexico con: " + c);
                            this.CheckKeyword(lexema, Color.Red, 0);
                            estado = 0;
                            lexema = "";
                        }

                        break;
                }
            }
        }

        public void CheckKeyword(string word, Color color, int startIndex)
        {
            RichTextBox bus = (RichTextBox)this.SelectedTab.Controls[0];
            if (this.SelectedTab.Controls[0].Text.ToLower().Contains(word))
            {
                int index = -1;
                int selectStart = bus.SelectionStart;

                while ((index = bus.Text.ToLower().IndexOf(word, (index + 1))) != -1)
                {
                    bus.Select((index + startIndex), word.Length);
                    bus.SelectionColor = color;
                    bus.Select(selectStart, 0);
                    bus.SelectionColor = Color.Black;
                }
            }
        }

        public String SelectedRichTextBoxTex
        {
            get { return this.SelectedTab.Controls[0].Text; }
        }
    }
}
