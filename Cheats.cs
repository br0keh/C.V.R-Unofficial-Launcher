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
    public partial class Cheats : Form
    {
        public Cheats()
        {
            InitializeComponent();
        }
        public void SetAllPeople(List<string> input)
        {
            foreach (string s in input)
            {
                if(listBox1.Items.Contains(s) == false)
                {
                    listBox1.Items.Add(s);
                }
               
            }
        }
        private void Cheats_Load(object sender, EventArgs e)
        {

          
        }
    }
}
