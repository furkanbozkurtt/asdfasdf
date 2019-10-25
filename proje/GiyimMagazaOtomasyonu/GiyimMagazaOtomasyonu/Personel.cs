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
    public partial class Personel : Form
    {
        Fonksiyonlar fonk = new Fonksiyonlar();

        DataTable tablo = new DataTable();

        int sonuc;
        int sonuc1;
        public Personel()
        {
            InitializeComponent();
        }

        //stok kontrol
        private void button18_Click(object sender, EventArgs e)
        {
            if (textBox16.Text != "")
                tablo = fonk.StokKontrol(textBox16.Text);

            if (tablo != null)
            {
                MessageBox.Show("Urun stok kontrolü için Listelendi");
                dataGridView4.DataSource = tablo;
            }
            else
            {
                MessageBox.Show("hata");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sonuc = 0;
            if (textBox1.Text != "" )
                sonuc = fonk.stokdus(textBox1.Text);
            if (sonuc == 1)
                MessageBox.Show("Ürün stokdan düştü");
            else
                MessageBox.Show("Hata");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sonuc = 0;
            if (textBox2.Text != "")
                sonuc = fonk.stokartir(textBox2.Text);
            if (sonuc == 1)
                MessageBox.Show("Ürün stoğa eklendi");
            else
                MessageBox.Show("Hata");
        }

        private void button19_Click(object sender, EventArgs e)
        {
            sonuc = 0;
            if (textBox17.Text != "" || textBox18.Text != "") { 
                sonuc = fonk.stokartir(textBox17.Text);
                sonuc1 = fonk.stokdus(textBox18.Text);
            }
            if (sonuc == 1 || sonuc1 == 1)
                MessageBox.Show("Stok ekleme çıkarma işlemleri yapıldı");
            else
                MessageBox.Show("Hata");
        }
    }
}
