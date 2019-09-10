using Practica1.Listas;
using Practica1.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


//Proyecto
namespace Practica1
{
    public partial class Interface1 : Form
    {

        /*
         * Patron Singleton
         */

        public static Interface1 instance = null;

        public static Interface1 Singleton
        {
            get
            {
                if (instance == null)
                {
                    instance = new Interface1();

                }
                return instance;
            }
        }

        /*
         * Termina el Singleton
         */

        /*
         * Los menues de la barra superior son los MenuStrip
         */

     

        public Interface1()
        {
            InitializeComponent();
            this.CenterToScreen();
            Image logo = Resources.Logo;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = logo;

        }


        private void Interface1_Load(object sender, EventArgs e)
        {

        }

        /*
         * Accion del boton Analizar
         */

        private void Button1_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            correrAnalisis();
            treeView1.ExpandAll();
            monthCalendar1.BoldedDates = fechas;
            
        }

        


        /*
         * Vector de pestañas
         */

        static Pestaña[] Arreglopestaña = new Pestaña[100];

        /*
         * Proceso de creacion de Nuevas pestañas
         */

        private void AhoritaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
             *Control de nombre de cada pestaña creada 
             */
            String title = "Pestaña " + (tabControl1.TabCount + 1).ToString();
            TabPage myTabPage = new TabPage(title);

            /*
             * Control del textBox a insertar en cada nuevo panel con la pestaña
             */
            RichTextBox newText = new RichTextBox();
            newText.Multiline = true;
            //newText.ScrollBars = ScrollBars.Vertical;
            newText.Size = new Size(tabControl1.Size.Width, tabControl1.Size.Height);
            newText.Font = new Font("Microsoft Sans Serif", 10.2f);
            myTabPage.Controls.Add(newText);

            /*
             * Control de objeto pestaña
             */
            NuevaPestaña(myTabPage, newText);
            tabControl1.TabPages.Add(myTabPage);
            tabControl1.SelectedTab = myTabPage;
        }

        


        private void MenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Menu1ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void HolaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        /*
         * Metodo que añade las pestañas a un vector, para tener acceso a los contenidos
         * de cada tabPage
         */

        public void NuevaPestaña(TabPage myTabPage, RichTextBox newText) {

            Pestaña nuevaPestaña = new Pestaña(myTabPage, newText);

            for (int i = 2; i < Arreglopestaña.Length; i++)
            {
                if (Arreglopestaña[i] == null)
                {
                    Arreglopestaña[i] = nuevaPestaña;
                    break;

                }
            }
        }

        /*
         * Metodo que muestra el contenido de la pestaña en la cual se encuentra el focus
         */
        public void correrAnalisis() {
            try
            {          
                if (tabControl1.SelectedTab.Text.Equals(pestañaPred))
                {
                    String entrada = boxName.Text;
                    if (entrada != "")
                    {
                        /*
                         * Proceso de análisis léxico
                         */
                        Analizador_Lexico.Singleton.analizador(entrada);

                        /*
                         * Luego del analisis léxico obtenemos como salida una lista de tokens,
                         * ahora procedemos a imprimirla para mostrar en consola su contenido.
                        */
                        Analizador_Lexico.Singleton.imprimirListaToken();
                        Analizador_Lexico.Singleton.imprimirListaErrores();
                        Analizador_Lexico.Singleton.crearNodo();
                    }
                }
            else { 
                 for (int i = 0; i < Arreglopestaña.Length; i++)
                     {
                        if (Arreglopestaña[i] != null)
                        {
                            if (tabControl1.SelectedTab.Text.Equals(Arreglopestaña[i].MyTabPage.Text))
                            {
                                String entrada = Arreglopestaña[i].NewText.Text;
                                if (entrada != "")
                                {
                                    /*
                                     * Proceso de análisis léxico
                                     */
                                    Analizador_Lexico.Singleton.analizador(entrada);

                                    /*
                                     * Luego del analisis léxico obtenemos como salida una 
                                     * lista de tokens en este caso es lTokens, ahora se
                                     * procede a imprimir la lista para mostrar en 
                                     * consola su contenido.
                                     */
                                    Analizador_Lexico.Singleton.imprimirListaToken();
                                    Analizador_Lexico.Singleton.imprimirListaErrores();
                                    Analizador_Lexico.Singleton.crearNodo();
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Hubo un error");
            }

        }

        /*
         * Metodo para cerrar la aplicacion
         */

        private void SalirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

         /*
          * Boton que deja la ventana en su estado inicial
          */
        private void Button2_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Text.Equals(pestañaPred))
            {
                boxName.Text = "";
            }
            else
            {

                for (int i = 0; i < Arreglopestaña.Length; i++)
                {
                    if (Arreglopestaña[i] != null)
                    {
                        if (tabControl1.SelectedTab.Text.Equals(Arreglopestaña[i].MyTabPage.Text))
                        {
                            Arreglopestaña[i].NewText.Text = "";
                        }

                    }
                }
            }

            Image logo = Resources.Logo;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = logo;
            lblDescripcion.Text = "Analizador Lexico" +
                "\nProgrammed by: Francisco Suarez";

        }


        /*
        * Creacion de nodos para el treeView
        */

        public void addNodosTreeView(int nodo, String plan, 
            String año, String mes, String dia, String descrip, 
            String imagen)
        {
            /*
             * nodo = 0 es un planificador
             * nodo = 1 es un año del planificador
             * nodo = 2 es un mes del año
             * nodo = 3 es un dia del mes
             * 
             */
            TreeNode nuevoNodo;


            switch (nodo)
            {
                case 0:
                    nuevoNodo = new TreeNode(plan);
                    treeView1.Nodes.Add(nuevoNodo);
                        
                    break;
                case 1:
                    for (int i = 0; i < treeView1.Nodes.Count; i++)
                    {
                        if (treeView1.Nodes[i].Text.Equals(plan))
                        {
                            nuevoNodo = new TreeNode(año);
                            treeView1.Nodes[i].Nodes.Add(nuevoNodo);
                                break;
                        }
                    }
                    break;
                case 2:
                    for (int i = 0; i < treeView1.Nodes.Count; i++)
                    {
                        if (treeView1.Nodes[i].Text.Equals(plan))
                        {
                            for (int j = 0; j < treeView1.Nodes[i].Nodes.Count; j++)
                            {
                                if (treeView1.Nodes[i].Nodes[j].Text.Equals(año))
                                {
                                    nuevoNodo = new TreeNode(mes);
                                    treeView1.Nodes[i].Nodes[j].Nodes.Add(nuevoNodo);
                                        break;
                                }
                            }

                        }
                    }
                    break;
                case 3:
                    for (int i = 0; i < treeView1.Nodes.Count; i++)
                    {
                        if (treeView1.Nodes[i].Text.Equals(plan))
                        {
                            for (int j = 0; j < treeView1.Nodes[i].Nodes.Count; j++)
                            {
                                if (treeView1.Nodes[i].Nodes[j].Text.Equals(año))
                                {
                                    for (int k = 0; k < treeView1.Nodes[i].Nodes[j].Nodes.Count; k++)
                                    {
                                        if (treeView1.Nodes[i].Nodes[j].Nodes[k].Text.Equals(mes))
                                        {
                                            Dia dias = new Dia(int.Parse(dia), descrip, imagen);
                                            nuevoNodo = new TreeNode(dia);
                                            nuevoNodo.Tag = dias;
                                            treeView1.Nodes[i].Nodes[j].Nodes[k].Nodes.Add(nuevoNodo);
                                            int añoBuscar = int.Parse(treeView1.Nodes[i].Nodes[j].Text);
                                            int mesBuscar = int.Parse(treeView1.Nodes[i].Nodes[j].Nodes[k].Text);
                                            addDateTime(añoBuscar, mesBuscar, int.Parse(dia));
                                            break;
                                        }
                                    }
                                }
                            }

                        }
                    }
                    break;
            }

        }

        /*
        * Metodo de agregar fechas al vector y vector de fechas para el calendario
        */

        DateTime[] fechas = new DateTime[500];
        

        public void addDateTime(int añoCalendario, int mesCalendario, int diaCalendario)
        {

            DateTime nuevaFecha = new DateTime(añoCalendario, mesCalendario, diaCalendario, 0, 0, 0, 0);

            for (int i = 0; i < fechas.Length; i++)
            {
                if (fechas[i].ToString().Contains("1/01/0001"))
                {
                    fechas[i] = nuevaFecha;
                    break;

                }
            }
            monthCalendar1.BoldedDates = fechas;
        }


        /*
         * Metodo de cargar archivo desde algun directorio en la PC
         */

        private void ComoTeVaToolStripMenuItem_Click(object sender, EventArgs e)
        {
         OpenFileDialog Archivo = new OpenFileDialog();
            Archivo.Filter = "Archivo de Entrada |*.ly";
            Archivo.InitialDirectory = @"C:\Users\Francisco Suarez\Desktop";

            if (Archivo.ShowDialog() == DialogResult.OK) {
                try
                {
                    //if (tabControl1.SelectedTab.Text.Equals("Pestaña 1"))
                    if (tabControl1.SelectedTab.Text.Equals(pestañaPred))
                    {
                        tabControl1.SelectedTab.Text = Archivo.SafeFileName + " P1";
                        pestañaPred = Archivo.SafeFileName + " P1";
                        boxName.Text = File.ReadAllText(Archivo.FileName);
                    }
                    else
                    {
                        for (int i = 0; i < Arreglopestaña.Length; i++)
                        {
                            if (Arreglopestaña[i] != null)
                            {
                                if (tabControl1.SelectedTab.Text.Equals(Arreglopestaña[i].MyTabPage.Text))
                                {
                                    Arreglopestaña[i].MyTabPage.Text = Archivo.SafeFileName + " P" + i;
                                    Arreglopestaña[i].NewText.Text = File.ReadAllText(Archivo.FileName); 

                                }
                            }
                        }
                    }
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("Hubo un error");
                }
            }
        }
        /*
         * Variable que almacena la primera pestaña
         */
        String pestañaPred = "Pestaña 1";

        private void GuardarArchivoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
            * Creacion del contenido archivo.ly
            */
            String Contenido_Archivo_ly = "";
            try
            {
                if (tabControl1.SelectedTab.Text.Equals("Pestaña 1"))
                {
                    /*
                     * Obtenemos el contenido del textBox de la pestaña
                     */
                    Contenido_Archivo_ly = boxName.Text;
                }
                else
                {
                    for (int i = 0; i < Arreglopestaña.Length; i++)
                    {
                        if (Arreglopestaña[i] != null)
                        {
                            if (tabControl1.SelectedTab.Text.Equals(Arreglopestaña[i].MyTabPage.Text))
                            {
                                /*
                                * Obtenemos el contenido del textBox de la pestaña
                                */
                                Contenido_Archivo_ly = Arreglopestaña[i].NewText.Text;

                                break;
                            }
                        }
                    }
                }
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Hubo un error");
            }
            

            /*
             * Proceso de guardado del archivo.ly
             */

            SaveFileDialog archivoLY = new SaveFileDialog();
            archivoLY.Filter = "Archivo de Entrada |*.ly";
            archivoLY.InitialDirectory = @"C:\Users\Francisco Suarez\Desktop";
            archivoLY.FileName = "ArchivoEntrada";
            if (archivoLY.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(archivoLY.FileName, Contenido_Archivo_ly);
            }


        }

        private void AcercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Interface2 datosPropios = new Interface2();
            datosPropios.Show();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
        }

        /*
         * Control despues de seleccionar un nodo del treeview
         * 
         */

        private void TreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                String planificador = treeView1.SelectedNode.Parent.Parent.Parent.Text;
                String año = treeView1.SelectedNode.Parent.Parent.Text;
                String mes = treeView1.SelectedNode.Parent.Text;
                String dia = treeView1.SelectedNode.Text;
                int añoCal = int.Parse(año);
                int mesCal = int.Parse(mes);
                int diaCal = int.Parse(dia);
                Lista_Planificadores.Singleton.MostrarDescripciones(planificador, año, mes, dia);
                monthCalendar1.SelectionStart = new System.DateTime(añoCal, mesCal, diaCal, 0, 0, 0, 0);
                monthCalendar1.SelectionEnd = new System.DateTime(añoCal, mesCal, diaCal, 0, 0, 0, 0);
                lblCalendario.Text = planificador;   
            }
            catch {

            } 
        }

        /*
         * Metodo que mostrara descripciones al seleccionar una fecha del calendario
         * siempre y cuando el titulo del calendario este correcto
         */

        private void MonthCalendar1_DateSelected(object sender, DateRangeEventArgs e)
        {
            //Console.WriteLine("La fecha seleccionada es: " + monthCalendar1.SelectionStart.Day.ToString());
            String planificador = lblCalendario.Text;
            String año = monthCalendar1.SelectionStart.Year.ToString();
            String mes = monthCalendar1.SelectionStart.Month.ToString();
            String dia = monthCalendar1.SelectionStart.Day.ToString();
            Lista_Planificadores.Singleton.MostrarDescripciones(planificador, año, mes, dia);
        }

        private void ManualDeAplicacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String manual = Application.StartupPath + "\\manual.pdf";
            if (File.Exists(manual))
            {
                System.Diagnostics.Process.Start(manual);
            }
            else
            {
                MessageBox.Show("El manual no se encuetra disponible");
            }
        }

        /*
         * Prueba de pintar palabras
         */

        private void BoxName_TextChanged_1(object sender, EventArgs e)
        {

            int estado = 0;
            String lexema = "";
            Char c;
            String entrada = boxName.Text + " ";

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

                            estado = 0;
                            i--;
                            this.CheckKeyword(lexema.ToLower(), Color.Red, 0);
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
                            this.CheckKeyword(lexema, Color.Green, 0);
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
                if (this.boxName.Text.ToLower().Contains(word))
                {
                    int index = -1;
                    int selectStart = this.boxName.SelectionStart;

                    while ((index = this.boxName.Text.ToLower().IndexOf(word, (index + 1))) != -1)
                    {
                        this.boxName.Select((index + startIndex), word.Length);
                        this.boxName.SelectionColor = color;
                        this.boxName.Select(selectStart, 0);
                        this.boxName.SelectionColor = Color.Black;
                    }
                }
            }


    }
}
