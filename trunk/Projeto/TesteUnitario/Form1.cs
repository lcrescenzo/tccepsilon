using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using SGR.BP.Objetos;

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
            Residuo a = new Residuo();
            propertyGrid1.SelectedObject = a;
        }
    }
}