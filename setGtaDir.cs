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
    public partial class setGtaDir : Form
    {
        public setGtaDir()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Length <= 0)
            {
                MessageBox.Show("Erro! Selecione um caminho válido, caso contrário haverá erros.");
            }else
            {
                Properties.Settings.Default.gta_dir = textBox1.Text;
                Properties.Settings.Default.Save();
                Properties.Settings.Default.Reload();
                this.Close();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    textBox1.Text = fbd.SelectedPath;
                }
            }
        }

        private void setGtaDir_Load(object sender, EventArgs e)
        {
            this.Focus();
        }
    }
}
