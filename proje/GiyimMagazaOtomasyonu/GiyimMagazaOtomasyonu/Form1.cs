using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiyimMagazaOtomasyonu
{
    public partial class Form1 : Form
    {
        Personel formPersonel = new Personel();
        Yönetici formYonetici = new Yönetici();
        Fonksiyonlar fonk = new Fonksiyonlar();

        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int yetki;
            yetki = fonk.Kullanici_giris(textBox1.Text, textBox2.Text);
            if(yetki==1)
            {
                
                formYonetici.ShowDialog();
                this.Close();
            }
            else if(yetki==2)
            {
                formPersonel.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Hata");
            }
        }
    }
}
