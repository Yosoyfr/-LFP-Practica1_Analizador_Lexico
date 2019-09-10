using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica1
{
    public partial class Interface2 : Form
    {
        //Patron Singleton
        public static Interface2 instance = null;

        public static Interface2 Singleton
        {
            get {
                if (instance == null) {
                    instance = new Interface2();
                  
                }
                return instance;
            }
        }
        //Termina el Singleton

        //Constructor Principal
        public Interface2()
        {
            Interface1.Singleton.Visible = true;
            Visible = false;
            InitializeComponent();
            inicio();
        }

        public void inicio()
        {
            //Thread.Sleep(6000);
            Console.WriteLine("Holaaasa");
            //Interface1.Singleton.Visible = true;
            //Visible = false;
        }

        private void BotonSalir_Click(object sender, EventArgs e)
        {
            Interface1.Singleton.Visible = true;
            Visible = false;

        }
    }
}
