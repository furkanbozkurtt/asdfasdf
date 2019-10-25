using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data;           //mysql connector kütüphaneleri
using MySql.Data.MySqlClient;


namespace GiyimMagazaOtomasyonu
{
    class Fonksiyonlar
    {
        MySqlConnection baglan;
        MySqlDataAdapter data;
        MySqlDataReader oku;  //mysql veri çekme ekleme için gerekli tanımlamalar
        MySqlCommand cmd;
        DataTable tablo;
        DataSet datase1;
        public bool mysql_baglan()
        {
            try
            {//mysql bağlantı kısmı
                baglan = new MySqlConnection("Server=localhost;Database=magazaotomasyonu;Uid=root;Pwd=");
                baglan.Open();
                return true;
            }catch(Exception)
            {
                return false;
            }
        }
        public void mysql_bitir()
        {//mysql bağlantı kapatma
            baglan.Close();
        }


        // Veritabanı sorguları sql injectionu önlemek için parametre olarak yollanmaktadır.


        //Kullanıcı giriş sorgulama
        public int Kullanici_giris(string kAdi, string kSifre){
            if (this.mysql_baglan() == true)
            {
                //parametreli sorgu kısmı
                cmd = new MySqlCommand("select * from kullanici where KullaniciAdi=@p_kAdi and Sifre=@p_kSifre", baglan);
                cmd.Parameters.AddWithValue("@p_kAdi", kAdi);//parametreleri tanımlama
                cmd.Parameters.AddWithValue("@p_kSifre", kSifre);
                oku = cmd.ExecuteReader();
                //sorgusu yapılan tablo mysqldatareader değişkenine atıldı
                while (oku.Read())
                {//tablo okunurken denk gelen kısma göre fonksiyon geri döner 
                    //ve tanımlı arayüz açılır
                    if(oku["KullaniciAdi"].ToString()==kAdi && oku["Sifre"].ToString()==kSifre && oku["Yetki"].ToString() == "1")
                    {
                        mysql_bitir();
                        return 1;
                    }
                    else if(oku["KullaniciAdi"].ToString() == kAdi && oku["Sifre"].ToString() == kSifre && oku["Yetki"].ToString() == "2")
                    {
                        mysql_bitir();
                        return 2;
                    }
                    else
                    {
                        mysql_bitir();
                        return 0;
                    }
                }
                mysql_bitir();
                return 0;
            }
            else
            {
                mysql_bitir();
                return 0;
            }
        }

        //departman ekleme fonksiyonu
        public DataTable DepartmanEkle(string deptAdi)
        {
            if (this.mysql_baglan() == true)
            {
                cmd = new MySqlCommand("insert into departman (DepartmanAdi) VALUES (@p_dept)", baglan);
                cmd.Parameters.AddWithValue("@p_dept", deptAdi);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    string sorgu = "select * from departman where DepartmanAdi =?p_dept";
                    data = new MySqlDataAdapter(sorgu, baglan);
                    data.SelectCommand.Parameters.AddWithValue("?p_dept", deptAdi);
                    tablo = new DataTable();
                    data.Fill(tablo);
                    this.mysql_bitir();
                    return tablo;
                }
                else
                {
                    this.mysql_bitir();
                    tablo = null;
                    return tablo;
                }
            }
            else
            {
                this.mysql_bitir();
                tablo = null;
                return tablo;
            }
        }

        //meslek ekleme fonksiyonu
        public DataTable MeslekEkle(string meslekAdi)
        {
            if (this.mysql_baglan() == true)
            {
                cmd = new MySqlCommand("insert into meslek (MeslekAdi) VALUES (@p_meslek)", baglan);
                cmd.Parameters.AddWithValue("@p_meslek", meslekAdi);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    //cmd = new MySqlCommand("select * from meslek where MeslekAdi=@p_meslek");
                    //cmd.Parameters.AddWithValue("@p_meslek", meslekAdi);
                    string sorgu = "select * from meslek where MeslekAdi=?p_meslek";
                    data = new MySqlDataAdapter(sorgu, baglan);
                    data.SelectCommand.Parameters.AddWithValue("?p_meslek", meslekAdi);
                    tablo = new DataTable();
                    data.Fill(tablo);
                    this.mysql_bitir();
                    return tablo;
                }
                else
                {
                    this.mysql_bitir();
                    tablo = null;
                    return tablo;
                }
            }
            else
            {
                this.mysql_bitir();
                tablo = null;
                return tablo;
            }
        }

        //departman listele fonksiyonu 
        public DataTable DepartmanListele(string deptAdi)
        {
            if (this.mysql_baglan() == true)
            {
                string sorgu = "select * from departman where DepartmanAdi =?p_dept";
                if (deptAdi == "")
                {
                    sorgu = "select * from departman LIMIT 100";
                }
                data = new MySqlDataAdapter(sorgu, baglan);
                data.SelectCommand.Parameters.AddWithValue("?p_dept", deptAdi);
                tablo = new DataTable();
                data.Fill(tablo);
                this.mysql_bitir();
                return tablo;
            }
            else
            {
                this.mysql_bitir();
                tablo = null;
                return tablo;
            }
        }


        //meslek listele fonksiyonu
        public DataTable MeslekListele(string meslekAdi)
        {
            if (this.mysql_baglan() == true)
            {
                string sorgu = "select * from meslek where MeslekAdi=?p_mesk";
                if (meslekAdi == "")
                {
                    sorgu = "select * from meslek LIMIT 100";
                }
                data = new MySqlDataAdapter(sorgu, baglan);
                data.SelectCommand.Parameters.AddWithValue("?p_mesk", meslekAdi);
                tablo = new DataTable();
                data.Fill(tablo);
                this.mysql_bitir();
                return tablo;
            }
            else
            {
                this.mysql_bitir();
                tablo = null;
                return tablo;
            }
        }

        //Mağaza Ekleme Fonksiyonu
        public int MagazaEkle(string subeAdi,string deptId,string M_sehir,string M_tel, string M_adres)
        {
            if (this.mysql_baglan() == true)
            {
                cmd = new MySqlCommand("insert into magaza (SubeAdi,MagazaTel,MagazaAdresi,Sehir,DepartmanID) VALUES (@p_Msube,@p_Mtel,@p_Madres,@p_Msehir,@p_Mdepartman)", baglan);
                cmd.Parameters.AddWithValue("@p_Msube", subeAdi);
                cmd.Parameters.AddWithValue("@p_Mtel", Int32.Parse(M_tel));
                cmd.Parameters.AddWithValue("@p_Msehir", M_sehir);
                cmd.Parameters.AddWithValue("@p_Madres", M_adres);
                cmd.Parameters.AddWithValue("@p_Mdepartman", Int32.Parse(deptId));
                if (cmd.ExecuteNonQuery() == 1)
                {
                    this.mysql_bitir();
                    return 1;
                }
                else
                {
                    this.mysql_bitir();
                    return 0;
                }
            }
            else
            {
                this.mysql_bitir();
                return 0;
            }
        }

        //MağazaListele Fonksiyonu
        public DataTable MagazaListele(string subeAdi)
        {
            if (this.mysql_baglan() == true)
            {
                string sorgu = "select * from magaza where SubeAdi=?p_subeAdi";
                if (subeAdi == "")
                {
                    sorgu = "select * from magaza LIMIT 100";
                }
                data = new MySqlDataAdapter(sorgu, baglan);
                data.SelectCommand.Parameters.AddWithValue("?p_subeAdi", subeAdi);
                tablo = new DataTable();
                data.Fill(tablo);
                this.mysql_bitir();
                return tablo;
            }
            else
            {
                this.mysql_bitir();
                tablo = null;
                return tablo;
            }
        }
        //Mağaza Silme
        public DataTable MagazaSil(int MagazaId)
        {
            if (this.mysql_baglan() == true)
            {
                cmd = new MySqlCommand("delete from magaza where MagazaId=@p_MagazaId", baglan);
                cmd.Parameters.AddWithValue("@p_MagazaId", MagazaId);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    string sorgu = "select * from magaza";
                    data = new MySqlDataAdapter(sorgu, baglan);
                    tablo = new DataTable();
                    data.Fill(tablo);
                    this.mysql_bitir();
                    return tablo;
                }
                else
                {
                    this.mysql_bitir();
                    tablo = null;
                    return tablo;
                }
            }
            else
            {
                this.mysql_bitir();
                tablo = null;
                return tablo;
            }
        }

        //Kullanıcı Ekleme Fonksiyonu

        public int KullaniciEkle(string Kadi,string Ksifre,string Kyetki,string personelID)
        {
            if (this.mysql_baglan() == true)
            {
                cmd = new MySqlCommand("insert into kullanici(KullaniciAdi,Sifre,Yetki,PersonelId) VALUES (@p_kAdi,@p_kSifre,@p_kYetki,@p_kPersonel)",baglan);
                cmd.Parameters.AddWithValue("@p_kAdi", Kadi);
                cmd.Parameters.AddWithValue("@p_kSifre", Int32.Parse(Ksifre));
                cmd.Parameters.AddWithValue("@p_kYetki", Int32.Parse(Kyetki));
                cmd.Parameters.AddWithValue("@p_kPersonel", Int32.Parse(personelID));

                if (cmd.ExecuteNonQuery() == 1)
                {
                    this.mysql_bitir();
                    return 1;
                }
                else
                {
                    this.mysql_bitir();
                    return 0;
                }
            }
            else
            {
                this.mysql_bitir();
                return 0;
            }

        }

        //personel ıd listeleme 
        public DataTable PersonelIdListele()
        {
            tablo = null;

            if (this.mysql_baglan() == true)
            {
                try
                {
                    string sorgu = "select * from personel";
                    data = new MySqlDataAdapter(sorgu, baglan);
                    tablo = new DataTable();
                    data.Fill(tablo);
                    this.mysql_bitir();
                    return tablo;
                }
                catch
                {
                    this.mysql_bitir();
                    return tablo;
                }
            }
            else
            {
                this.mysql_bitir();
                return tablo;
            }
        }
        //Kullanıcı Listeleme
        public DataTable KullaniciListele(string Kadi)
        {
            if (this.mysql_baglan() == true)
            {
                string sorgu = "select * from kullanici where KullaniciAdi=?p_kullanici";
                if (Kadi == "")
                {
                    sorgu = "select * from kullanici LIMIT 100";
                }
                data = new MySqlDataAdapter(sorgu, baglan);
                data.SelectCommand.Parameters.AddWithValue("?p_kullanici", Kadi);
                tablo = new DataTable();
                data.Fill(tablo);
                this.mysql_bitir();
                return tablo;
            }
            else
            {
                this.mysql_bitir();
                tablo = null;
                return tablo;
            }
        }
        //Kullnıcı Silme
        public DataTable KullaniciSilme(int kullaniciId)
        {
            if (this.mysql_baglan() == true)
            {
                cmd = new MySqlCommand("delete from kullanici where KullaniciId=@p_kullaniciId", baglan);
                cmd.Parameters.AddWithValue("@p_kullaniciId", kullaniciId);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    string sorgu = "select * from kullanici";
                    data = new MySqlDataAdapter(sorgu, baglan);
                    tablo = new DataTable();
                    data.Fill(tablo);
                    this.mysql_bitir();
                    return tablo;
                }
                else
                {
                    this.mysql_bitir();
                    tablo = null;
                    return tablo;
                }
            }
            else
            {
                this.mysql_bitir();
                tablo = null;
                return tablo;
            }
        }

        //Departman Silme
        public DataTable DepartmanSil(int departmanId)
        {
            if (this.mysql_baglan() == true)
            {
                cmd = new MySqlCommand("delete from departman where DepartmanId=@p_departmanId", baglan);
                cmd.Parameters.AddWithValue("@p_departmanId", departmanId);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    string sorgu = "select * from departman";
                    data = new MySqlDataAdapter(sorgu, baglan);
                    tablo = new DataTable();
                    data.Fill(tablo);
                    this.mysql_bitir();
                    return tablo;
                }
                else
                {
                    this.mysql_bitir();
                    tablo = null;
                    return tablo;
                }
            }
            else
            {
                this.mysql_bitir();
                tablo = null;
                return tablo;
            }
        }

        //Meslek Silme
        public DataTable MeslekSil(int MeslekId)
        {
            if (this.mysql_baglan() == true)
            {
                cmd = new MySqlCommand("delete from meslek where MeslekId=@p_meslekId", baglan);
                cmd.Parameters.AddWithValue("@p_meslekId", MeslekId);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    string sorgu = "select * from meslek";
                    data = new MySqlDataAdapter(sorgu, baglan);
                    tablo = new DataTable();
                    data.Fill(tablo);
                    this.mysql_bitir();
                    return tablo;
                }
                else
                {
                    this.mysql_bitir();
                    tablo = null;
                    return tablo;
                }
            }
            else
            {
                this.mysql_bitir();
                tablo = null;
                return tablo;
            }
        }

        //Persoen Ekleme Fonksiyonu
        public int PersonelEkleme(string pAdi,string pSoyadi,DateTime pGirisTarihi, string pMeslek, string pDepartman, string pMagaza, string pTel,string pMaas,string pAdres)
        {
            if (this.mysql_baglan() == true)
            {                                                                                                                                       
                cmd = new MySqlCommand("insert into personel(PersonelAdi,PersonelSoyadi,PersonelTel,PersonelAdres,GirisTarihi,Maas,DepartmanId,MeslekId,MagazaId) VALUES (@p_pAdi,@p_pSoyad,@p_pTel,@p_pAdres,@p_pGirisTarihi,@p_pMaas,@p_pDepartmanId,@p_pMeslekId,@p_pMagazaId)", baglan);
                cmd.Parameters.AddWithValue("@p_pAdi", pAdi);
                cmd.Parameters.AddWithValue("@p_pSoyad", pSoyadi);
                cmd.Parameters.AddWithValue("@p_pTel", Int32.Parse(pTel));
                cmd.Parameters.AddWithValue("@p_pAdres", pAdres);
                cmd.Parameters.AddWithValue("@p_pGirisTarihi", pGirisTarihi);
                cmd.Parameters.AddWithValue("@p_pMaas", Int32.Parse(pMaas));
                cmd.Parameters.AddWithValue("@p_pDepartmanId", Int32.Parse(pDepartman));
                cmd.Parameters.AddWithValue("@p_pMeslekId", Int32.Parse(pMeslek));
                cmd.Parameters.AddWithValue("@p_pMagazaId", Int32.Parse(pMagaza));

               if (cmd.ExecuteNonQuery() == 1)
                {
                    this.mysql_bitir();
                    return 1;
                }
                else
                {
                    this.mysql_bitir();
                    return 0;
                }
            }
            else
            {
                this.mysql_bitir();
                return 0;
            }
        }
        public int stokdus(string barkod)
        {
            if (this.mysql_baglan() == true)
            {
                cmd = new MySqlCommand("update stok set StokAdedi=StokAdedi-1 where UrunId=(select UrunId from urun where Barkod=@p_barkod)", baglan);
                cmd.Parameters.AddWithValue("@p_barkod", barkod);

                if (cmd.ExecuteNonQuery() == 1)
                {
                    this.mysql_bitir();
                    return 1;
                }
                else
                {
                    this.mysql_bitir();
                    return 0;
                }
            }
            else
            {
                this.mysql_bitir();
                return 0;
            }
        }

        public int stokartir(string barkod)
        {
            if (this.mysql_baglan() == true)
            {
                cmd = new MySqlCommand("update stok set StokAdedi=StokAdedi+1 where UrunId=(select UrunId from urun where Barkod=@p_barkod)", baglan);
                cmd.Parameters.AddWithValue("@p_barkod", barkod);

                if (cmd.ExecuteNonQuery() == 1)
                {
                    this.mysql_bitir();
                    return 1;
                }
                else
                {
                    this.mysql_bitir();
                    return 0;
                }
            }
            else
            {
                this.mysql_bitir();
                return 0;
            }
        }

        //personel Listeleme Fonksiyonu
        public DataTable PersonelListele(string pAdi,string pSoyadi)
        {
            if (this.mysql_baglan() == true)
            {
                string sorgu = "select * from personel where PersonelAdi=?p_pAdi or PersonelSoyadi=?p_pSoyadi";
                /*if (pAdi == "" || pSoyadi=="")
                {
                    sorgu = "select * from personel LIMIT 100";
                }*/
                data = new MySqlDataAdapter(sorgu, baglan);
                data.SelectCommand.Parameters.AddWithValue("?p_pAdi", pAdi);
                data.SelectCommand.Parameters.AddWithValue("?p_pSoyadi", pSoyadi);
                tablo = new DataTable();
                data.Fill(tablo);
                this.mysql_bitir();
                return tablo;
            }
            else
            {
                this.mysql_bitir();
                tablo = null;
                return tablo;
            }
        }

        public DataTable satislistele(string mag)
        {
            if (this.mysql_baglan() == true)
            {
                string sorgu = "select * from satis where MagazaId=?p_pAdi";
                /*if (pAdi == "" || pSoyadi=="")
                {
                    sorgu = "select * from personel LIMIT 100";
                }*/
                data = new MySqlDataAdapter(sorgu, baglan);
                data.SelectCommand.Parameters.AddWithValue("?p_pAdi", mag);
                tablo = new DataTable();
                data.Fill(tablo);
                this.mysql_bitir();
                return tablo;
            }
            else
            {
                this.mysql_bitir();
                tablo = null;
                return tablo;
            }
        }

        public DataTable satislisteleper(string per)
        {
            if (this.mysql_baglan() == true)
            {
                string sorgu = "select * from satis where PersonelId=?p_pAdi";
                /*if (pAdi == "" || pSoyadi=="")
                {
                    sorgu = "select * from personel LIMIT 100";
                }*/
                data = new MySqlDataAdapter(sorgu, baglan);
                data.SelectCommand.Parameters.AddWithValue("?p_pAdi", per);
                tablo = new DataTable();
                data.Fill(tablo);
                this.mysql_bitir();
                return tablo;
            }
            else
            {
                this.mysql_bitir();
                tablo = null;
                return tablo;
            }
        }

        //Personel Silme Fonksiyonu
        public DataTable PersonelSilme(int personelId)
        {
            if (this.mysql_baglan() == true)
            {
                cmd = new MySqlCommand("delete from personel where PersonelId=@p_pId", baglan);
                cmd.Parameters.AddWithValue("@p_pId", personelId);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    string sorgu = "select * from personel";
                    data = new MySqlDataAdapter(sorgu, baglan);
                    tablo = new DataTable();
                    data.Fill(tablo);
                    this.mysql_bitir();
                    return tablo;
                }
                else
                {
                    this.mysql_bitir();
                    tablo = null;
                    return tablo;
                }
            }
            else
            {
                this.mysql_bitir();
                tablo = null;
                return tablo;
            }
        }

        //kategori Adı Ekleme Fonksiyonu
        public int KategoriAdiEkle(string kategoriAdi)
        {
            if (this.mysql_baglan() == true)
            {
                cmd = new MySqlCommand("insert into kategoriad(KategoriAdi) VALUES (@p_kategori)", baglan);
                cmd.Parameters.AddWithValue("@p_kategori", kategoriAdi);
               

                if (cmd.ExecuteNonQuery() == 1)
                {
                    this.mysql_bitir();
                    return 1;
                }
                else
                {
                    this.mysql_bitir();
                    return 0;
                }
            }
            else
            {
                this.mysql_bitir();
                return 0;
            }
        }

        //desen ekleme fonksiyonu
        public int DesenEkle(string desenAdi)
        {
            if (this.mysql_baglan() == true)
            {
                cmd = new MySqlCommand("insert into desen(DesenAdi) VALUES (@p_desenAd)", baglan);
                cmd.Parameters.AddWithValue("@p_desenAd", desenAdi);


                if (cmd.ExecuteNonQuery() == 1)
                {
                    this.mysql_bitir();
                    return 1;
                }
                else
                {
                    this.mysql_bitir();
                    return 0;
                }
            }
            else
            {
                this.mysql_bitir();
                return 0;
            }
        }
        //renk ekleme fonksiyonu
        public int RenkEkle(string renkKodu)
        {
            if (this.mysql_baglan() == true)
            {
                cmd = new MySqlCommand("insert into renk(RenkKodu) VALUES (@p_renk)", baglan);
                cmd.Parameters.AddWithValue("@p_renk", Int32.Parse(renkKodu));


                if (cmd.ExecuteNonQuery() == 1)
                {
                    this.mysql_bitir();
                    return 1;
                }
                else
                {
                    this.mysql_bitir();
                    return 0;
                }
            }
            else
            {
                this.mysql_bitir();
                return 0;
            }
        }
        //marka ekleme fonksiyonu
        public int MarkaEkle(string markaAdi)
        {
            if (this.mysql_baglan() == true)
            {
                cmd = new MySqlCommand("insert into marka(MarkaAdi) VALUES (@p_markaAdi)", baglan);
                cmd.Parameters.AddWithValue("@p_markaAdi", markaAdi);


                if (cmd.ExecuteNonQuery() == 1)
                {
                    this.mysql_bitir();
                    return 1;
                }
                else
                {
                    this.mysql_bitir();
                    return 0;
                }
            }
            else
            {
                this.mysql_bitir();
                return 0;
            }
        }
        //beden ekleme fonksiyonu
        public int BedenEkle(string bedenAdi)
        {
            if (this.mysql_baglan() == true)
            {
                cmd = new MySqlCommand("insert into beden(BedenAdi) VALUES (@p_beden)", baglan);
                cmd.Parameters.AddWithValue("@p_beden", bedenAdi);


                if (cmd.ExecuteNonQuery() == 1)
                {
                    this.mysql_bitir();
                    return 1;
                }
                else
                {
                    this.mysql_bitir();
                    return 0;
                }
            }
            else
            {
                this.mysql_bitir();
                return 0;
            }
        }
        //tip ekleme fonksiyonu
        public int TipEkle(string tipAdi)
        {
            if (this.mysql_baglan() == true)
            {
                cmd = new MySqlCommand("insert into tip(TipAdi) VALUES (@p_TipAdi)", baglan);
                cmd.Parameters.AddWithValue("@p_TipAdi", tipAdi);


                if (cmd.ExecuteNonQuery() == 1)
                {
                    this.mysql_bitir();
                    return 1;
                }
                else
                {
                    this.mysql_bitir();
                    return 0;
                }
            }
            else
            {
                this.mysql_bitir();
                return 0;
            }
        }

        //kategorileri listele
        public DataTable KategorileriListele()
        {
            DataTable[] tablodizi = new DataTable[6];
            DataTable tablo1 = new DataTable();


            if (this.mysql_baglan() == true)
            {
                string sorgu = "select * from kategoriad";
                data = new MySqlDataAdapter(sorgu, baglan);
                data.Fill(tablo1);

                sorgu = "select * from desen";
                data = new MySqlDataAdapter(sorgu, baglan);
                data.Fill(tablo1);

                sorgu = "select * from renk";
                data = new MySqlDataAdapter(sorgu, baglan);
                data.Fill(tablo1);

                sorgu = "select * from marka";
                data = new MySqlDataAdapter(sorgu, baglan);
                data.Fill(tablo1);

                sorgu = "select * from beden";
                data = new MySqlDataAdapter(sorgu, baglan);
                data.Fill(tablo1);

                sorgu = "select * from tip";
                data = new MySqlDataAdapter(sorgu, baglan);
                data.Fill(tablo1);

                this.mysql_bitir();
                return tablo1;
            }
            else
            {
                this.mysql_bitir();
                tablo1 = null;
                return tablo1;
            }
        }

        //kategoriAdI listeleme
        public DataTable KategoriAdiListele()
        {
            if (this.mysql_baglan() == true)
            {

                string sorgu = "select * from kategoriad";
                data = new MySqlDataAdapter(sorgu, baglan);
                tablo = new DataTable();
                data.Fill(tablo);
                this.mysql_bitir();
                return tablo;
            }
            else
            {
                this.mysql_bitir();
                tablo = null;
                return tablo;
            }
        }
        //desen listele
        public DataTable DesenAdiListele()
        {
            if (this.mysql_baglan() == true)
            {

                string sorgu = "select * from desen";
                data = new MySqlDataAdapter(sorgu, baglan);
                tablo = new DataTable();
                data.Fill(tablo);
                this.mysql_bitir();
                return tablo;
            }
            else
            {
                this.mysql_bitir();
                tablo = null;
                return tablo;
            }
        }
        //renk listele
        public DataTable RenkKoduListele()
        {
            if (this.mysql_baglan() == true)
            {

                string sorgu = "select * from renk";
                data = new MySqlDataAdapter(sorgu, baglan);
                tablo = new DataTable();
                data.Fill(tablo);
                this.mysql_bitir();
                return tablo;
            }
            else
            {
                this.mysql_bitir();
                tablo = null;
                return tablo;
            }
        }
        //marka listele
        public DataTable MarkaAdiListele()
        {
            if (this.mysql_baglan() == true)
            {

                string sorgu = "select * from marka";
                data = new MySqlDataAdapter(sorgu, baglan);
                tablo = new DataTable();
                data.Fill(tablo);
                this.mysql_bitir();
                return tablo;
            }
            else
            {
                this.mysql_bitir();
                tablo = null;
                return tablo;
            }
        }
        //beden listele
        public DataTable BedenAdiListele()
        {
            if (this.mysql_baglan() == true)
            {

                string sorgu = "select * from beden";
                data = new MySqlDataAdapter(sorgu, baglan);
                tablo = new DataTable();
                data.Fill(tablo);
                this.mysql_bitir();
                return tablo;
            }
            else
            {
                this.mysql_bitir();
                tablo = null;
                return tablo;
            }
        }
        //tip listele
        public DataTable TipAdiListele()
        {
            if (this.mysql_baglan() == true)
            {

                string sorgu = "select * from tip";
                data = new MySqlDataAdapter(sorgu, baglan);
                tablo = new DataTable();
                data.Fill(tablo);
                this.mysql_bitir();
                return tablo;
            }
            else
            {
                this.mysql_bitir();
                tablo = null;
                return tablo;
            }
        }

        //kategoriAdı Silme
        public DataTable KategoriAdiSilme(string kategoriAdId)
        {
            if (this.mysql_baglan() == true)
            {
                cmd = new MySqlCommand("delete from kategoriad where KategoriAdId=@p_kId", baglan);
                cmd.Parameters.AddWithValue("@p_kId", Int32.Parse(kategoriAdId));
                if (cmd.ExecuteNonQuery() == 1)
                {
                    string sorgu = "select * from kategoriad";
                    data = new MySqlDataAdapter(sorgu, baglan);
                    tablo = new DataTable();
                    data.Fill(tablo);
                    this.mysql_bitir();
                    return tablo;
                }
                else
                {
                    this.mysql_bitir();
                    tablo = null;
                    return tablo;
                }
            }
            else
            {
                this.mysql_bitir();
                tablo = null;
                return tablo;
            }
        }
        //desen silme
        public DataTable DesenAdiSilme(string desenAdId)
        {
            if (this.mysql_baglan() == true)
            {
                cmd = new MySqlCommand("delete from desen where DesenId=@p_dId", baglan);
                cmd.Parameters.AddWithValue("@p_dId", Int32.Parse(desenAdId));
                if (cmd.ExecuteNonQuery() == 1)
                {
                    string sorgu = "select * from desen";
                    data = new MySqlDataAdapter(sorgu, baglan);
                    tablo = new DataTable();
                    data.Fill(tablo);
                    this.mysql_bitir();
                    return tablo;
                }
                else
                {
                    this.mysql_bitir();
                    tablo = null;
                    return tablo;
                }
            }
            else
            {
                this.mysql_bitir();
                tablo = null;
                return tablo;
            }
        }
        //renk silme
        public DataTable RenkKoduSilme(string renkId)
        {
            if (this.mysql_baglan() == true)
            {
                cmd = new MySqlCommand("delete from renk where RenkId=@p_rId", baglan);
                cmd.Parameters.AddWithValue("@p_rId", Int32.Parse(renkId));
                if (cmd.ExecuteNonQuery() == 1)
                {
                    string sorgu = "select * from renk";
                    data = new MySqlDataAdapter(sorgu, baglan);
                    tablo = new DataTable();
                    data.Fill(tablo);
                    this.mysql_bitir();
                    return tablo;
                }
                else
                {
                    this.mysql_bitir();
                    tablo = null;
                    return tablo;
                }
            }
            else
            {
                this.mysql_bitir();
                tablo = null;
                return tablo;
            }
        }
        //marka silme
        public DataTable MarkaAdiSilme(string markaId)
        {
            if (this.mysql_baglan() == true)
            {
                cmd = new MySqlCommand("delete from marka where MarkaId=@p_mId", baglan);
                cmd.Parameters.AddWithValue("@p_mId", Int32.Parse(markaId));
                if (cmd.ExecuteNonQuery() == 1)
                {
                    string sorgu = "select * from marka";
                    data = new MySqlDataAdapter(sorgu, baglan);
                    tablo = new DataTable();
                    data.Fill(tablo);
                    this.mysql_bitir();
                    return tablo;
                }
                else
                {
                    this.mysql_bitir();
                    tablo = null;
                    return tablo;
                }
            }
            else
            {
                this.mysql_bitir();
                tablo = null;
                return tablo;
            }
        }
        //beden silme
        public DataTable BedenAdiSilme(string bedenId)
        {
            if (this.mysql_baglan() == true)
            {
                cmd = new MySqlCommand("delete from beden where BedenId=@p_bId", baglan);
                cmd.Parameters.AddWithValue("@p_bId", Int32.Parse(bedenId));
                if (cmd.ExecuteNonQuery() == 1)
                {
                    string sorgu = "select * from beden";
                    data = new MySqlDataAdapter(sorgu, baglan);
                    tablo = new DataTable();
                    data.Fill(tablo);
                    this.mysql_bitir();
                    return tablo;
                }
                else
                {
                    this.mysql_bitir();
                    tablo = null;
                    return tablo;
                }
            }
            else
            {
                this.mysql_bitir();
                tablo = null;
                return tablo;
            }
        }
        //tip silme
        public DataTable tipAdiSilme(string tipId)
        {
            if (this.mysql_baglan() == true)
            {
                cmd = new MySqlCommand("delete from tip where TipId=@p_tId", baglan);
                cmd.Parameters.AddWithValue("@p_tId", Int32.Parse(tipId));
                if (cmd.ExecuteNonQuery() == 1)
                {
                    string sorgu = "select * from tip";
                    data = new MySqlDataAdapter(sorgu, baglan);
                    tablo = new DataTable();
                    data.Fill(tablo);
                    this.mysql_bitir();
                    return tablo;
                }
                else
                {
                    this.mysql_bitir();
                    tablo = null;
                    return tablo;
                }
            }
            else
            {
                this.mysql_bitir();
                tablo = null;
                return tablo;
            }
        }

       /* public int UrunEkle(string Barkod,string uAdi,string uFiyati,string uAdedi,string magazaId, string kategoriId,string renkId,string desenId,string markaId,string BedenId,string tipId)
        {
            int kategoriIdNo=0, urunId =0;
            if (this.mysql_baglan() == true)
            {
                cmd = new MySqlCommand("insert into kategori(KategoriAdId,BedenId,MarkaId,DesenId,RenkId,TipId) VALUES (@p_kategoriadId,@p_bedenId,@p_markaId,@p_desenId,@p_renkId,@p_tipId)", baglan);
                cmd.Parameters.AddWithValue("@p_kategoriadId", kategoriId);
                cmd.Parameters.AddWithValue("@p_bedenId", Int32.Parse(BedenId));
                cmd.Parameters.AddWithValue("@p_markaId", Int32.Parse(markaId));
                cmd.Parameters.AddWithValue("@p_desenId", Int32.Parse(desenId));
                cmd.Parameters.AddWithValue("@p_renkId", Int32.Parse(renkId));
                cmd.Parameters.AddWithValue("@p_tipId", Int32.Parse(tipId));
                

                if (cmd.ExecuteNonQuery() == 1 )
                {

                    string sorgu = "select KategoriId from kategori order by KategoriId desc limit 1, 1";
                    data = new MySqlDataAdapter(sorgu, baglan);
                    tablo = new DataTable();
                    data.Fill(tablo);

                    if(1==1)
                    {
                        oku = cmd.ExecuteReader();
                        foreach (DataRow row in tablo.Rows)
                        {
                            string kategorii = row["KategoriId"].ToString();
                            kategoriIdNo = Int32.Parse(kategorii);
                        }
                        this.mysql_bitir();
                        this.mysql_baglan();
                        cmd = new MySqlCommand("insert into urun(UrunAdi,UrunFiyati,KateoriId,Barkod) VALUES (@p_urunAdi,@p_UrunFiyati,@p_KategoriId,@p_Barkod)", baglan);
                        cmd.Parameters.AddWithValue("@p_urunAdi", uAdi);
                        cmd.Parameters.AddWithValue("@p_UrunFiyati", Int32.Parse(uFiyati));
                        cmd.Parameters.AddWithValue("@p_KategoriId", kategoriIdNo);
                        cmd.Parameters.AddWithValue("@p_Barkod", Int32.Parse(Barkod));
                        if (cmd.ExecuteNonQuery() == 1)
                        {
                            this.mysql_bitir();
                            this.mysql_baglan();
                            tablo = null;

                            sorgu = "select UrunId from urun order by UrunId desc limit 0, 1";
                            data = new MySqlDataAdapter(sorgu, baglan);
                            tablo = new DataTable();
                            data.Fill(tablo);
                            foreach (DataRow row in tablo.Rows)
                            {
                                string urunler = row["UrunId"].ToString();
                                urunId = Int32.Parse(urunler);
                            }
                            this.mysql_bitir();
                            this.mysql_baglan();
                            cmd = new MySqlCommand("insert into stok(StokAdedi,UrunId,MagazaId) VALUES (@p_stokAdedi,@p_UrunId,@p_magazaId)", baglan);
                            cmd.Parameters.AddWithValue("@p_stokAdedi", Int32.Parse(uAdedi));
                            cmd.Parameters.AddWithValue("@p_UrunId", urunId);
                            cmd.Parameters.AddWithValue("@p_magazaId", Int32.Parse(magazaId));
                            if (cmd.ExecuteNonQuery() == 1)
                            {
                                this.mysql_bitir();
                                return 1;
                            }
                            else
                            {
                                this.mysql_bitir();
                                return 0;
                            }
                        }
                        this.mysql_bitir();
                        return 1;
                    }
                    else
                    {
                        this.mysql_bitir();
                        return 0;
                    }
                }
                else
                {
                    this.mysql_bitir();
                    return 0;
                }
            }
            else
            {
                this.mysql_bitir();
                return 0;
            }
        }*/
        public DataTable barkodNoUrun(string barkod)
        {
            if (this.mysql_baglan() == true)
            {
                string sorgu = "select * from urun INNER JOIN kategori ON kategori.KategoriId=urun.KateoriId and urun.Barkod=?p_barkod INNER JOIN tip ON tip.TipId = kategori.TipId and urun.Barkod=?p_barkod INNER JOIN renk ON renk.RenkId = kategori.RenkId and urun.Barkod=?p_barkod INNER JOIN desen ON desen.DesenId = kategori.DesenId and urun.Barkod=?p_barkod INNER JOIN marka ON marka.MarkaId = kategori.MarkaId and urun.Barkod=?p_barkod INNER JOIN beden ON beden.BedenId = kategori.BedenId and urun.Barkod=?p_barkod";
                if (barkod == "")
                {
                    sorgu = "select * from urun LIMIT 100";
                }
                data = new MySqlDataAdapter(sorgu, baglan);
                data.SelectCommand.Parameters.AddWithValue("?p_barkod", barkod);
                tablo = new DataTable();
                data.Fill(tablo);
                this.mysql_bitir();
                return tablo;
            }
            else
            {
                this.mysql_bitir();
                tablo = null;
                return tablo;
            }
        }

        public DataTable UrunSil(int UrunId)
        {
            if (this.mysql_baglan() == true)
            {
                cmd = new MySqlCommand("delete from urun where UrunId=@p_UrunId", baglan);
                cmd.Parameters.AddWithValue("@p_UrunId", UrunId);
                if (cmd.ExecuteNonQuery() == 1)
                {
                    string sorgu = "select * from urun";
                    data = new MySqlDataAdapter(sorgu, baglan);
                    tablo = new DataTable();
                    data.Fill(tablo);
                    this.mysql_bitir();
                    return tablo;
                }
                else
                {
                    this.mysql_bitir();
                    tablo = null;
                    return tablo;
                }
            }
            else
            {
                this.mysql_bitir();
                tablo = null;
                return tablo;
            }
        }

        public DataTable StokKontrol(string barkod)
        {
            int urunId=0;
            if (this.mysql_baglan() == true)
            {
                string sorgu = "select * from urun where barkod=?p_barkod";

                data = new MySqlDataAdapter(sorgu, baglan);
                data.SelectCommand.Parameters.AddWithValue("?p_barkod", Int32.Parse(barkod));
                tablo = new DataTable();
                data.Fill(tablo);
                foreach (DataRow row in tablo.Rows)
                {
                    string urunler = row["UrunId"].ToString();
                    urunId = Int32.Parse(urunler);
                }
                tablo = null;
                sorgu = "select * from urun INNER JOIN stok ON urun.UrunId="+urunId+" and stok.UrunId="+urunId+"";
                data = new MySqlDataAdapter(sorgu, baglan);
                data.SelectCommand.Parameters.AddWithValue("?p_barkod", barkod);
                tablo = new DataTable();
                data.Fill(tablo);
                return tablo;
            }
            else
            {
                this.mysql_bitir();
                tablo = null;
                return tablo;
            }
        }
    }
}
