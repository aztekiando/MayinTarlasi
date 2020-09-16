using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MayinTarlasi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

          ArrayList mayinlar = new ArrayList();
          int sayi = 0;
        private void btnBaslat_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            btnBaslat.Enabled = false;
            numericUpDown1.Enabled = false;
            Random rast = new Random();

            for (int i = 0; i < Convert.ToInt32(numericUpDown1.Value); i++)  //Mayın üretimi
            {
               Uret:
                sayi = rast.Next(0,64);


                if (mayinlar.Contains(sayi))
                {
                    goto Uret;
                }
                else
                {
                    mayinlar.Add(sayi);
                }

            }

            for (int i = 0; i < 64; i++)  // Button Üretimi
            {

                Button btn = new Button();
                btn.Size = new Size(72, 50);
                btn.FlatStyle = FlatStyle.Flat;
                flowLayoutPanel1.Controls.Add(btn);

                btn.Click += Btn_Click;

                if (mayinlar.Contains(i))
                {
                    btn.Tag = -1;
                }
                else
                {
                    btn.Tag = rast.Next(1,23);
                }
            }
           
            
            
        }
        int bitis;
        int sonuc;
        int baska;

        private void Btn_Click(object sender, EventArgs e)
        {
            
            sonuc = 64 - Convert.ToInt32(numericUpDown1.Value);

            Button tiklanan = (Button)sender;
            tiklanan.Text = tiklanan.Tag.ToString();
            if (Convert.ToInt32(tiklanan.Tag) == -1)
            {
                tiklanan.BackColor = Color.Red;
                label1.Text = "0";
                

                for (int i = 0; i < flowLayoutPanel1.Controls.Count; i++)
                {
                    flowLayoutPanel1.Controls[i].Enabled = false;
                    if (Convert.ToInt32(flowLayoutPanel1.Controls[i].Tag) == -1)
                    {
                        flowLayoutPanel1.Controls[i].Text = "";
                        flowLayoutPanel1.Controls[i].BackColor = Color.Red;
                        
                        
                    }
                    else
                    {
                        flowLayoutPanel1.Controls[i].Text = flowLayoutPanel1.Controls[i].Tag.ToString();
                        
                    }

                }

                btnBaslat.Enabled = true;
                numericUpDown1.Enabled = true;
            }
            else
            {
                tiklanan.Enabled = false;
                tiklanan.BackColor = Color.Green;


                //tiklanan.Text = tiklanan.Tag.ToString();


                baska = baska + Convert.ToInt32(tiklanan.Text);
                string skor = Convert.ToString(baska);
                label1.Text = skor;

  
            }
            if (Convert.ToInt32(tiklanan.Tag) != -1 && tiklanan.BackColor == Color.Green)
            {
                bitis += 1;

                if (bitis==sonuc)
                {
                    MessageBox.Show("Oyun Bitmiştir.\n" +
                        "Tebrikler");
                    btnBaslat.Enabled = true;
                    numericUpDown1.Enabled = true;
                    baska = 0;
                    label1.Text = "0";
                }

            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            numericUpDown1.Maximum = 63;
            numericUpDown1.Minimum = 1;
        }
    }
}
