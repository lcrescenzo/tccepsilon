using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SGR.BP.Objeto;

namespace TesteUnitario
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CADRI a = new CADRI(10);
            //Residuo a = new Residuo(1);
     

            propertyGrid1.SelectedObject = a;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}