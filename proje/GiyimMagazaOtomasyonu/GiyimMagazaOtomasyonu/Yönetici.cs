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
    public partial class Yönetici : Form
    {
        Personel formPersonel = new Personel();
        Fonksiyonlar fonk = new Fonksiyonlar();

        DataTable tablo = new DataTable();

        int sonuc;


        public Yönetici()
        {
            InitializeComponent();
            string bos = "";

            //mağaza ekledeki departmanları comboBoxda listeler
            tablo = fonk.DepartmanListele(bos);

            comboBox6.DataSource = tablo;
            comboBox6.ValueMember = "DepartmanId";
            comboBox6.DisplayMember = "DepartmanAdi";

            //personel ekle kısmı
            comboBox2.DataSource = tablo;
            comboBox2.ValueMember = "DepartmanId";
            comboBox2.DisplayMember = "DepartmanAdi";



            //mağaza ıd listele
            tablo = fonk.MagazaListele("");
            comboBox3.DataSource = tablo;
            comboBox3.ValueMember = "MagazaId";
            comboBox3.DisplayMember = "SubeAdi";

            comboBox19.DataSource = tablo;
            comboBox19.ValueMember = "MagazaId";
            comboBox19.DisplayMember = "SubeAdi";

            comboBox18.DataSource = tablo;
            comboBox18.ValueMember = "MagazaId";
            comboBox18.DisplayMember = "SubeAdi";

            //meslek id listele
            tablo = fonk.MeslekListele("");
            comboBox1.DataSource = tablo;
            comboBox1.ValueMember = "MeslekId";
            comboBox1.DisplayMember = "MeslekAdi";
            //mağaza ekle comboBox


            //kullanici ekleme comboBox verileri çekme
            tablo = fonk.PersonelIdListele();
            comboBox5.DataSource = tablo;
            comboBox5.ValueMember = "PersonelId";
            comboBox5.DisplayMember = "PersonelAdi";

            comboBox17.DataSource = tablo;
            comboBox17.ValueMember = "PersonelId";
            comboBox17.DisplayMember = "PersonelAdi";
            //kullanıcı ekleme comboBox

            //kategori combobox listeleme

            tablo = fonk.KategoriAdiListele();
            comboBox16.DataSource = tablo;
            comboBox16.ValueMember = "KategoriAdId";
            comboBox16.DisplayMember = "KategoriAdı";

            comboBox10.DataSource = tablo;
            comboBox10.ValueMember = "KategoriAdId";
            comboBox10.DisplayMember = "KategoriAdı";

            tablo = fonk.DesenAdiListele();
            comboBox11.DataSource = tablo;
            comboBox11.ValueMember = "DesenId";
            comboBox11.DisplayMember = "DesenAdi";

            comboBox8.DataSource = tablo;
            comboBox8.ValueMember = "DesenId";
            comboBox8.DisplayMember = "DesenAdi";

            tablo = fonk.RenkKoduListele();
            comboBox15.DataSource = tablo;
            comboBox15.ValueMember = "RenkId";
            comboBox15.DisplayMember = "RenkKodu";

            comboBox9.DataSource = tablo;
            comboBox9.ValueMember = "RenkId";
            comboBox9.DisplayMember = "RenkKodu";

            tablo = fonk.MarkaAdiListele();
            comboBox13.DataSource = tablo;
            comboBox13.ValueMember = "MarkaId";
            comboBox13.DisplayMember = "MarkaAdi";

            comboBox7.DataSource = tablo;
            comboBox7.ValueMember = "MarkaId";
            comboBox7.DisplayMember = "MarkaAdi";

            tablo = fonk.BedenAdiListele();
            comboBox14.DataSource = tablo;
            comboBox14.ValueMember = "BedenId";
            comboBox14.DisplayMember = "BedenAdi";

            comboBox4.DataSource = tablo;
            comboBox4.ValueMember = "BedenId";
            comboBox4.DisplayMember = "BedenAdi";

            tablo = fonk.TipAdiListele();
            comboBox12.DataSource = tablo;
            comboBox12.ValueMember = "TipId";
            comboBox12.DisplayMember = "TipAdi";

            comboBox20.DataSource = tablo;
            comboBox20.ValueMember = "TipId";
            comboBox20.DisplayMember = "TipAdi";
            //kategori combobox listeleme

        }

        private void button14_Click(object sender, EventArgs e)
        {
            formPersonel.Hide();
            formPersonel.ShowDialog();
        }
        //Departman Ekleme
        private void button9_Click(object sender, EventArgs e)
        {
            tablo = null;
            if(dept.Text!="")
                tablo = fonk.DepartmanEkle(dept.Text);
            if (tablo != null)
            {
                MessageBox.Show("Başarıyla Eklendi");
                dataGridView4.DataSource = tablo;
            }
            else
                MessageBox.Show("Başarısız");
        }
        //Meslek Ekleme
        private void button10_Click(object sender, EventArgs e)
        {
            tablo = null;
            if(mesk.Text!="")
                tablo = fonk.MeslekEkle(mesk.Text);
            if (tablo != null)
            {
                MessageBox.Show("Başarıyla Eklendi");
                dataGridView4.DataSource = tablo;
            }
            else
                MessageBox.Show("Başarısız");
        }
        //Departman Listeleme
        private void button11_Click(object sender, EventArgs e)
        {
            tablo= fonk.DepartmanListele(textBox15.Text);
            if(tablo!= null)
            {
                MessageBox.Show("Listelendi");
                dataGridView4.DataSource = tablo;
            }
            else
            {
                MessageBox.Show("Hata");
            }
        }
        //Meslek Listeleme
        private void button12_Click(object sender, EventArgs e)
        {
            tablo = fonk.MeslekListele(textBox16.Text);
            if (tablo != null)
            {
                MessageBox.Show("Listelendi");
                dataGridView4.DataSource = tablo;
            }
            else
            {
                MessageBox.Show("Hata");
            }
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }
        //Mağaza Ekleme
        private void button6_Click(object sender, EventArgs e)
        {
            sonuc = 0;
            if(textBox10.Text!="" ||textBox11.Text!="" || textBox13.Text!="" || richTextBox2.Text!="")
                sonuc=fonk.MagazaEkle(textBox10.Text, comboBox6.SelectedValue.ToString(), textBox11.Text,textBox13.Text, richTextBox2.Text);
            if (sonuc == 1)
                MessageBox.Show("Mağaza Başarılı Bir Şekilde Eklendi");
            else
                MessageBox.Show("Hata");
        }
        //Mağaza Listeleme
        private void button7_Click(object sender, EventArgs e)
        {
            tablo=fonk.MagazaListele(textBox12.Text);
            if (tablo != null)
            {
                MessageBox.Show("Listelendi");
                dataGridView3.DataSource = tablo;
            }
            else
            {
                MessageBox.Show("Hata");
            }
        }
        //Mağaza Silme
        private void button8_Click(object sender, EventArgs e)
        {
            int magazaId= Convert.ToInt32(dataGridView3.CurrentRow.Cells["MagazaId"].Value);
            tablo = null;
            tablo =fonk.MagazaSil(magazaId);
            if (tablo != null)
            {
                MessageBox.Show("Mağaza Başarılı Bir Şekilde Silindi");
                dataGridView3.DataSource = tablo;
            }
            else
                MessageBox.Show("hata");
        }
        //Kullanıcı Ekleme
        private void button4_Click(object sender, EventArgs e)
        {
            sonuc = 0;
            if(textBox7.Text!="" || textBox8.Text!="" || textBox14.Text != "")
                sonuc = fonk.KullaniciEkle(textBox7.Text,textBox8.Text,textBox14.Text,comboBox5.SelectedValue.ToString());
            if (sonuc == 1)
                MessageBox.Show("Kullanıcı Eklendi");
            else
            {
                MessageBox.Show("hata");
            }
        }
        //Kullanıcı Listeleme
        private void button5_Click(object sender, EventArgs e)
        {
            tablo = null;
            if(textBox9.Text != "")
                tablo=fonk.KullaniciListele(textBox9.Text);
            if(tablo!=null)
            {
                MessageBox.Show("Kullanıclar Listelendi");
                dataGridView2.DataSource = tablo;
            }
            else
            {
                MessageBox.Show("hata");
            }
            
        }

        //kullanıcı silme
        private void button17_Click(object sender, EventArgs e)
        {
            int kullaniciId = Convert.ToInt32(dataGridView2.CurrentRow.Cells["KullaniciId"].Value);
            tablo = null;
            tablo = fonk.KullaniciSilme(kullaniciId);
            if (tablo != null)
            {
                MessageBox.Show("Kullanıcı Başarılı Bir Şekilde Silindi");
                dataGridView2.DataSource = tablo;
            }
            else
                MessageBox.Show("hata");
        }

        //departman Silme veya Meslek Silme
        private void button13_Click(object sender, EventArgs e)
        {
            string kolonAdi = dataGridView4.Columns[0].HeaderText;
            if (kolonAdi == "DepartmanId")
            {
                tablo = null;
                int departmanId = Convert.ToInt32(dataGridView4.CurrentRow.Cells["DepartmanId"].Value);
                tablo = fonk.DepartmanSil(departmanId);
                if (tablo != null)
                {
                    MessageBox.Show("Departman Silindi");
                    dataGridView4.DataSource = tablo;
                }
                else
                    MessageBox.Show("Hata");
            }
            else
            {
                tablo = null;
                int meslekId = Convert.ToInt32(dataGridView4.CurrentRow.Cells["MeslekId"].Value);
                tablo = fonk.MeslekSil(meslekId);
                if (tablo != null)
                {
                    MessageBox.Show("Meslek Silindi");
                    dataGridView4.DataSource = tablo;
                }
                else
                    MessageBox.Show("Hata");
            }
        }

        //Personel Ekleme
        private void button1_Click(object sender, EventArgs e)
        {
            sonuc = 0;
            if (textBox1.Text != "" || textBox2.Text != "" || textBox3.Text != "" || textBox4.Text != "" || richTextBox1.Text != "")
                sonuc = fonk.PersonelEkleme(textBox1.Text, textBox2.Text,dateTimePicker1.Value, comboBox1.SelectedValue.ToString(), comboBox2.SelectedValue.ToString(), comboBox3.SelectedValue.ToString(), textBox3.Text, textBox4.Text, richTextBox1.Text);
            if (sonuc == 1)
                MessageBox.Show("Personel Başarılı Bir Şekilde Eklendi");
            else
                MessageBox.Show("Hata");
        }


        //personel listele fonksiyonu
        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            tablo = null;
            if (textBox5.Text != "" || textBox6.Text != "")
                tablo = fonk.PersonelListele(textBox5.Text, textBox6.Text);
            else
                MessageBox.Show("Personel Adi veya Soyadi Birini Giriniz");
            if (tablo != null)
            {
                MessageBox.Show("Personel Listelendi");
                dataGridView1.DataSource = tablo;
            }
            else
            {
                MessageBox.Show("hata");
            }
        }

        //Personel Silme Fonksiyonu
        private void button3_Click(object sender, EventArgs e)
        {
            int PersonelId = Convert.ToInt32(dataGridView1.CurrentRow.Cells["PersonelId"].Value);
            tablo = null;
            tablo = fonk.PersonelSilme(PersonelId);
            if (tablo != null)
            {
                MessageBox.Show("Personel Başarılı Bir Şekilde Silindi");
                dataGridView1.DataSource = tablo;
            }
            else
                MessageBox.Show("hata");
        }

        //Kategori Adı ekle
        private void button32_Click(object sender, EventArgs e)
        {
            sonuc = 0;
            if (textBox29.Text != "")
                sonuc = fonk.KategoriAdiEkle(textBox29.Text);
            if (sonuc == 1)
                MessageBox.Show("Kategori Adı Başarılı Bir Şekilde Eklendi");
            else
                MessageBox.Show("Hata");
        }

        //Desen ekle
        private void button30_Click(object sender, EventArgs e)
        {
            sonuc = 0;
            if (textBox28.Text != "")
                sonuc = fonk.DesenEkle(textBox28.Text);
            if (sonuc == 1)
                MessageBox.Show("Desen Başarılı Bir Şekilde Eklendi");
            else
                MessageBox.Show("Hata");
        }

        //Renk ekle
        private void button28_Click(object sender, EventArgs e)
        {
            sonuc = 0;
            if (textBox27.Text != "")
                sonuc = fonk.RenkEkle(textBox27.Text);
            if (sonuc == 1)
                MessageBox.Show("Renk Başarılı Bir Şekilde Eklendi");
            else
                MessageBox.Show("Hata");
        }

        //Marka ekle
        private void button26_Click(object sender, EventArgs e)
        {
            sonuc = 0;
            if (textBox26.Text != "")
                sonuc = fonk.MarkaEkle(textBox26.Text);
            if (sonuc == 1)
                MessageBox.Show("Marka Başarılı Bir Şekilde Eklendi");
            else
                MessageBox.Show("Hata");
        }

        //Beden  ekle
        private void button24_Click(object sender, EventArgs e)
        {
            sonuc = 0;
            if (textBox25.Text != "")
                sonuc = fonk.BedenEkle(textBox25.Text);
            if (sonuc == 1)
                MessageBox.Show("Beden Başarılı Bir Şekilde Eklendi");
            else
                MessageBox.Show("Hata");
        }

        //Tip ekle
        private void button22_Click(object sender, EventArgs e)
        {
            sonuc = 0;
            if (textBox24.Text != "")
                sonuc = fonk.TipEkle(textBox24.Text);
            if (sonuc == 1)
                MessageBox.Show("Tip Başarılı Bir Şekilde Eklendi");
            else
                MessageBox.Show("Hata");
        }

        //Kategori Listeleme Fonksiyonu
        private void button20_Click(object sender, EventArgs e)
        {
            tablo = null;
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
            tablo = fonk.KategorileriListele();

            if (tablo != null)
            {
                MessageBox.Show("Listelendi");
                dataGridView8.DataSource=tablo;
                
            }
            else
            {
                MessageBox.Show("hata");
            }
        }

        //kategori adı sil
        private void button31_Click(object sender, EventArgs e)
        {
            tablo = null;
            tablo = fonk.KategoriAdiSilme(comboBox16.SelectedValue.ToString());
            if (tablo != null)
            {
                MessageBox.Show("Kategori Adı Başarılı Bir Şekilde Silindi");
                tablo = fonk.KategoriAdiListele();
                comboBox16.DataSource = tablo;
                comboBox16.ValueMember = "KategoriAdId";
                comboBox16.DisplayMember = "KategoriAdı";
                dataGridView8.DataSource = tablo;
            }
            else
                MessageBox.Show("hata");
        }
        //desen sil
        private void button29_Click(object sender, EventArgs e)
        {
            tablo = null;
            tablo = fonk.DesenAdiSilme(comboBox11.SelectedValue.ToString());
            if (tablo != null)
            {
                MessageBox.Show("desen Adı Başarılı Bir Şekilde Silindi");
                tablo = fonk.DesenAdiListele();
                comboBox11.DataSource = tablo;
                comboBox11.ValueMember = "DesenId";
                comboBox11.DisplayMember = "DesenAdi";
                dataGridView8.DataSource = tablo;
            }
            else
                MessageBox.Show("hata");
        }
        //renk sil
        private void button27_Click(object sender, EventArgs e)
        {
            tablo = null;
            tablo = fonk.RenkKoduSilme(comboBox15.SelectedValue.ToString());
            if (tablo != null)
            {
                MessageBox.Show("Renk Adı Başarılı Bir Şekilde Silindi");
                tablo = fonk.RenkKoduListele();
                comboBox15.DataSource = tablo;
                comboBox15.ValueMember = "RenkId";
                comboBox15.DisplayMember = "RenkKodu";
                dataGridView8.DataSource = tablo;
            }
            else
                MessageBox.Show("hata");
        }
        //marka sil
        private void button25_Click(object sender, EventArgs e)
        {
            tablo = null;
            tablo = fonk.MarkaAdiSilme(comboBox13.SelectedValue.ToString());
            if (tablo != null)
            {
                MessageBox.Show("Marka Adı Başarılı Bir Şekilde Silindi");
                tablo = fonk.MarkaAdiListele();
                comboBox13.DataSource = tablo;
                comboBox13.ValueMember = "MarkaId";
                comboBox13.DisplayMember = "MarkaAdi";
                dataGridView8.DataSource = tablo;
            }
            else
                MessageBox.Show("hata");
        }
        //beden sil
        private void button23_Click(object sender, EventArgs e)
        {
            tablo = null;
            tablo = fonk.BedenAdiSilme(comboBox14.SelectedValue.ToString());
            if (tablo != null)
            {
                MessageBox.Show("Beden Adı Başarılı Bir Şekilde Silindi");
                tablo = fonk.BedenAdiListele();
                comboBox14.DataSource = tablo;
                comboBox14.ValueMember = "BedenId";
                comboBox14.DisplayMember = "BedenAdi";
                dataGridView8.DataSource = tablo;
            }
            else
                MessageBox.Show("hata");
        }
        //tip sil
        private void button21_Click(object sender, EventArgs e)
        {
            tablo = null;
            tablo = fonk.tipAdiSilme(comboBox12.SelectedValue.ToString());
            if (tablo != null)
            {
                MessageBox.Show("Tip Adı Başarılı Bir Şekilde Silindi");
                tablo = fonk.TipAdiListele();
                comboBox12.DataSource = tablo;
                comboBox12.ValueMember = "TipId";
                comboBox12.DisplayMember = "TipAdi";
                dataGridView8.DataSource = tablo;
            }
            else
                MessageBox.Show("hata");
        }
        //Ürün ekleme kısmı
        private void button19_Click(object sender, EventArgs e)
        {
            sonuc = 1;
            if (textBox23.Text != "" || textBox21.Text != "" || textBox20.Text != "" || textBox19.Text != "")
               // sonuc = fonk.UrunEkle(textBox23.Text,textBox21.Text,textBox20.Text,textBox19.Text,comboBox10.SelectedValue.ToString(),comboBox10.SelectedValue.ToString(), comboBox9.SelectedValue.ToString(), comboBox8.SelectedValue.ToString(), comboBox7.SelectedValue.ToString(), comboBox4.SelectedValue.ToString(), comboBox20.SelectedValue.ToString());
            if (sonuc == 1)
                MessageBox.Show("Ürün Başarılı Bir Şekilde Eklendi");
            else
                MessageBox.Show("Hata");
        }

        private void button18_Click(object sender, EventArgs e)
        {
            tablo = null;
            dataGridView7.DataSource = null;
            dataGridView7.Refresh();
            tablo = fonk.barkodNoUrun(textBox22.Text);

            if (tablo != null)
            {
                MessageBox.Show("Listelendi");
                dataGridView7.DataSource = tablo;
            }
            else
            {
                MessageBox.Show("hata");
            }
        }

        private void button34_Click(object sender, EventArgs e)
        {

            tablo = null;
            int UrunId = Convert.ToInt32(dataGridView7.CurrentRow.Cells["UrunId"].Value);
            tablo = fonk.UrunSil(UrunId);
            if (tablo != null)
            {
                MessageBox.Show("Ürün Silindi");
                dataGridView7.DataSource = tablo;
            }
            else
                MessageBox.Show("Hata");

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Yönetici_Load(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {

            dataGridView5.DataSource = null;
            dataGridView5.Refresh();
            tablo = null;
            tablo = fonk.satislistele(comboBox18.SelectedValue.ToString());
            
            if (tablo != null)
            {
                MessageBox.Show("Listelendi");
                dataGridView5.DataSource = tablo;
            }
            else
            {
                MessageBox.Show("hata");
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            dataGridView6.DataSource = null;
            dataGridView6.Refresh();
            tablo = null;
            tablo = fonk.satislisteleper(comboBox17.SelectedValue.ToString());

            if (tablo != null)
            {
                MessageBox.Show("Listelendi");
                dataGridView6.DataSource = tablo;
            }
            else
            {
                MessageBox.Show("hata");
            }
        }
    }
}
