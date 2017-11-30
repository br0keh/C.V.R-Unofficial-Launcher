using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C.V.R_Unofficial_Launcher
{
    public partial class Funcoes : Form
    {

        public Funcoes()
        {
            InitializeComponent();
        }
        private void Funcoes_Load(object sender, EventArgs e)
        {
            textBox1.Text = Properties.Settings.Default.codigodeativacao;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.codigodeativacao = textBox1.Text;
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();
        }
    }
}
