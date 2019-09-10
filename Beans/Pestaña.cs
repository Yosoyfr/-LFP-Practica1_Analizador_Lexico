using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica1
{
    class Pestaña
    {
        /*
         * Atributos de las pestañas
         */

        private TabPage myTabPage = new TabPage();
        private RichTextBox newText = new RichTextBox();

        /*
         * Atributos de la pestaña
         */

        public Pestaña(TabPage myTabPage, RichTextBox newText)
        {
            this.myTabPage = myTabPage;
            this.newText = newText;
            //newText.TextChanged += new EventHandler(NewText_TextChanged);
        }

        /*
         * Accesores y modificadores de la pestaña
         * Tanto para la pestaña como para el texto en el textBox de cada pestaña
         */

        public TabPage MyTabPage
        {
            set { this.myTabPage = value; }
            get { return this.myTabPage; }
        }

        public RichTextBox NewText
        {
            set { this.newText = value; }
            get {return this.newText; }
        }


    }
}
