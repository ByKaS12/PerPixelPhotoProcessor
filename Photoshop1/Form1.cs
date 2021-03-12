using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;


namespace Photoshop1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Pictures = new List<ObjectAPI>();
        }
        public List<ObjectAPI> Pictures;
        public int ControlIndex = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            ImageControl ic = new ImageControl();
            flowLayoutPanel1.Controls.Add(ic);
            flowLayoutPanel1.Controls.SetChildIndex(ic, flowLayoutPanel1.Controls.Count - 2);
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "c:\\";
                // openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                // openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Get the path of specified file

                    Pictures.Add(new ObjectAPI(openFileDialog.FileName));
                    ic.Pictures = Pictures;
                    ic.ControlIndex = ControlIndex;
                    ic.pictureBox1.Image = new Bitmap(openFileDialog.FileName);
                    ControlIndex++;

                }
            }

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap b = new Bitmap(mainPic.Width, mainPic.Height);
            var _tmp = mainPic.Image;
            mainPic.Image = b;
            _tmp?.Dispose();

            var g = Graphics.FromImage(b);
            
            foreach (var c in flowLayoutPanel1.Controls)
            {
                if (c.ToString() == "Photoshop1.ImageControl")
                {
                    var ic = c as ImageControl;

                    if (ic.pictureBox1.Image != null)
                    {
                        g.DrawImageUnscaled(ic.pictureBox1.Image, 0, 0);
                    }
                    
                   
                }
            }
            g.Dispose();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }

        
    }
