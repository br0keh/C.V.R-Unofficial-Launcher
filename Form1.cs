using Hotkeys;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C.V.R_Unofficial_Launcher
{
    public partial class Form1 : Form
    {
        Form gtadirselect = new setGtaDir();
        Cheats form2 = new Cheats();
        public List<string> cheats = new List<string>();
        private Hotkeys.GlobalHotkey ghk;
        public Form1()
        {
            InitializeComponent();
            ghk = new Hotkeys.GlobalHotkey(Constants.ALT, Keys.End, this);
        }
        private void comboBox1_KeyDown(object sender, KeyEventArgs e)
        {
            // comboBox1 is readonly
            e.SuppressKeyPress = true;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            WebClient wC = new WebClient();
            string versioncheck = wC.DownloadString("https://pastebin.com/raw/MNy5msdm");
            if(versioncheck != Properties.Settings.Default.versao)
            {
                MessageBox.Show("Nova versão disponível: " + versioncheck);
            }
            if(Properties.Settings.Default.servidor != "0")
            {
                comboBox1.Text = Properties.Settings.Default.servidor;

            }
            if (Properties.Settings.Default.gta_dir.Contains("\\") || Properties.Settings.Default.gta_dir.Contains("/"))
            {
                
                this.Text = "C.V.R Unnoficial Launcher v" + Properties.Settings.Default.versao.ToString() + " ["+ Properties.Settings.Default.gta_dir + "]";
            }else
            {
                
                gtadirselect.Show();

                this.Text = "C.V.R Unnoficial Launcher v" + Properties.Settings.Default.versao.ToString();
            }
            ghk.Register();

        }
        private void HandleHotkey()
        {
            Clipboard.SetText(Properties.Settings.Default.codigodeativacao);
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == Hotkeys.Constants.WM_HOTKEY_MSG_ID) {
                HandleHotkey();


            }
               
            base.WndProc(ref m);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            using (pictureBox3.Image)
            {
                var rnd = new Random();
                int ticks = rnd.Next(1, 4);
                pictureBox3.Image = (System.Drawing.Image)Properties.Resources.ResourceManager.GetObject("SLIDE_" + ticks.ToString(), Properties.Resources.Culture);
            }

        }
      
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (cheats.Count > 0)
            {
                MessageBox.Show("Cheats foram encontrados em seu jogo.");
                form2.ShowDialog();
            }
            else
            {
                if (Properties.Settings.Default.gta_dir.Contains("\\") || Properties.Settings.Default.gta_dir.Contains("/"))
                {

                }
                else
                {
                    MessageBox.Show("Erro, especifique onde fica seu GTA!");

                    gtadirselect.Focus();


                }

                string ip = "";
                switch (comboBox1.Text)
                {
                    case "SERVIDOR 1 (3.5)":
                        ip = "158.69.39.196:7777";
                        break;

                    case "SERVIDOR 2 (3.5)":
                        ip = "158.69.39.197:7777";
                        break;

                    case "SERVIDOR 3 (3.5)":
                        ip = "158.69.39.198:7777";
                        break;

                    case "SERVIDOR 4 (3.6)":
                        ip = "167.114.34.216:7777";
                        break;

                    case "SERVIDOR 5(3) (3.6)":
                        ip = "144.217.51.253:7777";
                        break;
                }
                string gtaDir = Properties.Settings.Default.gta_dir;
                System.Diagnostics.Process.Start(Properties.Settings.Default.gta_dir + "\\samp.exe", ip);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.servidor = comboBox1.Text;
            Properties.Settings.Default.Save();
            Properties.Settings.Default.Reload();
        }
        private List<String> DirSearch(string sDir)
        {
            List<String> files = new List<String>();
            try
            {
                foreach (string f in Directory.GetFiles(sDir))
                {
                    files.Add(f);
                }
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    files.AddRange(DirSearch(d));
                }
            }
            catch (System.Exception excpt)
            {
                MessageBox.Show(excpt.Message);
            }

            return files;
        }
        private void detector_Tick(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.gta_dir.Contains("\\") || Properties.Settings.Default.gta_dir.Contains("/"))
            {
                List<string> files = DirSearch(Properties.Settings.Default.gta_dir);
                foreach (string file in files)
                {
                    if (file.IndexOf("aimbot", StringComparison.OrdinalIgnoreCase) >= 0)
                    {
                        if (cheats.Contains(file) == false)
                        {
                            cheats.Add(file);
                        }

                    }
                    else if (file.IndexOf("teleport", StringComparison.OrdinalIgnoreCase) >= 0)
                    {

                        if (cheats.Contains(file) == false)
                        {
                            cheats.Add(file);
                        }
                    }
                    else if (file.IndexOf("SAMPFUNCS", StringComparison.OrdinalIgnoreCase) >= 0)
                    {

                        if (cheats.Contains(file) == false)
                        {
                            cheats.Add(file);
                        }
                    }
                    else if (file.IndexOf("sobeit", StringComparison.OrdinalIgnoreCase) >= 0)
                    {

                        if (cheats.Contains(file) == false)
                        {
                            cheats.Add(file);
                        }
                    }
                    else if (file.IndexOf("Sobeit", StringComparison.OrdinalIgnoreCase) >= 0)
                    {

                        if (cheats.Contains(file) == false)
                        {
                            cheats.Add(file);
                        }
                    }
                    else if (file.IndexOf("God", StringComparison.OrdinalIgnoreCase) >= 0)
                    {

                        if (cheats.Contains(file) == false)
                        {
                            cheats.Add(file);
                        }
                    }
                    else if (file.IndexOf("dgun", StringComparison.OrdinalIgnoreCase) >= 0)
                    {

                        if (cheats.Contains(file) == false)
                        {
                            cheats.Add(file);
                        }
                    }
                    else if (file.IndexOf("Cheat", StringComparison.OrdinalIgnoreCase) >= 0)
                    {

                        if (cheats.Contains(file) == false)
                        {
                            cheats.Add(file);
                        }
                    }
                    else if (file.IndexOf("hack", StringComparison.OrdinalIgnoreCase) >= 0)
                    {

                        if (cheats.Contains(file) == false)
                        {
                            cheats.Add(file);
                        }
                    }
                    else if (file.IndexOf("xiter", StringComparison.OrdinalIgnoreCase) >= 0)
                    {

                        if (cheats.Contains(file) == false)
                        {
                            cheats.Add(file);
                        }
                    }
                    else if (file.IndexOf("rapidfire", StringComparison.OrdinalIgnoreCase) >= 0)
                    {

                        if (cheats.Contains(file) == false)
                        {
                            cheats.Add(file);
                        }
                    }
                    else if (file.IndexOf("rapid", StringComparison.OrdinalIgnoreCase) >= 0)
                    {

                        if (cheats.Contains(file) == false)
                        {
                            cheats.Add(file);
                        }
                    }
                    else if (file.IndexOf("samp-funcs", StringComparison.OrdinalIgnoreCase) >= 0)
                    {

                        if (cheats.Contains(file) == false)
                        {
                            cheats.Add(file);
                        }
                    }
                    else if (file.IndexOf(".sf", StringComparison.OrdinalIgnoreCase) >= 0)
                    {

                        if (cheats.Contains(file) == false)
                        {
                            cheats.Add(file);
                        }
                    }
                    else if (file.IndexOf("carfix", StringComparison.OrdinalIgnoreCase) >= 0)
                    {

                        if (cheats.Contains(file) == false)
                        {
                            cheats.Add(file);
                        }
                    }
                    else if (file.IndexOf("mira", StringComparison.OrdinalIgnoreCase) >= 0)
                    {

                        if (cheats.Contains(file) == false)
                        {
                            cheats.Add(file);
                        }
                    }

                }

                form2.SetAllPeople(cheats);
            }
            else
            {

            }
           
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            Funcoes funcoes = new Funcoes();
            funcoes.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ghk.Unregiser();
        }
    }
}
