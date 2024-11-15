using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Charts;
using DevExpress.XtraCharts;

namespace Ticari_Otomasyon
{
    public partial class FrmKasa : Form
    {
        public FrmKasa()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        void MusteriHareket()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("exec MusteriHareketler", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }

        void FirmaHareket()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("exec FirmaHareketler", bgl.baglanti());
            da.Fill(dt);
            gridControl3.DataSource = dt;
        }

        void Giderler()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_GIDERLER", bgl.baglanti());
            da.Fill(dt);
            gridControl2.DataSource = dt;
        }

        public string ad;
        private void FrmKasa_Load(object sender, EventArgs e)
        {
            LblAktifKullanici.Text = ad;
            MusteriHareket();
            FirmaHareket();
            Giderler();

            //Toplam Tutarı Hesaplama
            SqlCommand komut1 = new SqlCommand("select SUM(TUTAR)  from TBL_FATURADETAY",bgl.baglanti());
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                LblKasaToplam.Text = Convert.ToInt32(dr1[0]).ToString("N0") + " ₺";
            }
            bgl.baglanti().Close();

            //Son Ayın Faturaları
            SqlCommand komut2 = new SqlCommand("Select top 1 (ELEKTRIK+SU+DOGALGAZ+INTERNET+MAASLAR+EKSTRA) from TBL_GIDERLER order by ID desc", bgl.baglanti());
            SqlDataReader dr2= komut2.ExecuteReader();
            while(dr2.Read())
            {
                LblYapilanOdemeler.Text = Convert.ToInt32(dr2[0]).ToString("N0") + " ₺";
            }
            bgl.baglanti().Close();

            //Son Ayın Personel Maaşları
            SqlCommand komut3 = new SqlCommand("Select top 1 (MAASLAR) from TBL_GIDERLER order by ID desc ", bgl.baglanti());
            SqlDataReader dr3 = komut3.ExecuteReader();
            while(dr3.Read())
            {
                LblPersonelMaaslari.Text= Convert.ToInt32(dr3[0]).ToString("N0") + " ₺";
            }
            bgl.baglanti().Close();

            //Toplam Müşteri Sayısı
            SqlCommand komut4 = new SqlCommand("select COUNT(*) from TBL_MUSTERILER ", bgl.baglanti());
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                LblMusteriSayisi.Text = dr4[0].ToString();
            }
            bgl.baglanti().Close();

            //Toplam Firma Sayısı
            SqlCommand komut5 = new SqlCommand("select COUNT(*) from TBL_FIRMALAR ", bgl.baglanti());
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                LblFirmaSayisi.Text = dr5[0].ToString();
            }
            bgl.baglanti().Close();

            //Toplam Firma Şehir Sayısı
            SqlCommand komut6 = new SqlCommand("select COUNT(distinct(IL)) from TBL_FIRMALAR ", bgl.baglanti());
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                LblFirmaSehirSayisi.Text = dr6[0].ToString();
            }
            bgl.baglanti().Close();

            //Toplam Müşteri Şehir Sayısı
            SqlCommand komut7 = new SqlCommand("select COUNT(distinct(IL)) from TBL_MUSTERILER ", bgl.baglanti());
            SqlDataReader dr7 = komut7.ExecuteReader();
            while (dr7.Read())
            {
                LblMusteriSehirSayisi.Text = dr7[0].ToString();
            }
            bgl.baglanti().Close();


            //Toplam Personel Sayısı
            SqlCommand komut8 = new SqlCommand("select COUNT(*) from TBL_PERSONELLER ", bgl.baglanti());
            SqlDataReader dr8 = komut8.ExecuteReader();
            while (dr8.Read())
            {
                LblPersonelSayisi.Text = dr8[0].ToString();
            }
            bgl.baglanti().Close();

            //Toplam Ürüm Sayısı
            SqlCommand komut9 = new SqlCommand("select SUM(ADET) from TBL_URUNLER ", bgl.baglanti());
            SqlDataReader dr9 = komut9.ExecuteReader();
            while (dr9.Read())
            {
                LblStokSayisi.Text = Convert.ToInt32(dr9[0]).ToString("N0") + " Adet";

            }
            bgl.baglanti().Close();

            
        }

        int sayac = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac++;

            //Elektrik Faturası Listeleme
            if (sayac>0 && sayac<=5)
            {
                chartControl1.Series["Aylar"].Points.Clear();
                groupControl2.Text = "Elektrik Faturası";
                

                SqlCommand komut10 = new SqlCommand("select top 4 Ay,ELEKTRIK from TBL_GIDERLER  order by ıd desc", bgl.baglanti());
                SqlDataReader dr10 = komut10.ExecuteReader();
                while (dr10.Read())
                {
                    chartControl1.Series["Aylar"].Points.AddPoint(Convert.ToString(dr10[0]), Convert.ToInt32(dr10[1]));
                }
                bgl.baglanti().Close();
            }

            //Su Faturası Listeleme
            if (sayac>5 && sayac<=10)
            {
                groupControl2.Text = "Su Faturası";
                chartControl1.Series["Aylar"].Points.Clear();
               

                SqlCommand komut11 = new SqlCommand("select top 4 Ay,Su from TBL_GIDERLER  order by ıd desc", bgl.baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    chartControl1.Series["Aylar"].Points.AddPoint(Convert.ToString(dr11[0]), Convert.ToInt32(dr11[1]));
                }
                bgl.baglanti().Close();
               
            }

            //Doğalgaz Faturası Listeleme
            if (sayac > 10 && sayac <= 15)
            {
                groupControl2.Text = "Doğalgaz Faturası";
                chartControl1.Series["Aylar"].Points.Clear();


                SqlCommand komut11 = new SqlCommand("select top 4 Ay,DOGALGAZ from TBL_GIDERLER  order by ıd desc", bgl.baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    chartControl1.Series["Aylar"].Points.AddPoint(Convert.ToString(dr11[0]), Convert.ToInt32(dr11[1]));
                }
                bgl.baglanti().Close();

            }

            //İnternet Faturası Listeleme
            if (sayac > 15 && sayac <= 20)
            {
                groupControl2.Text = "İnternet Faturası";
                chartControl1.Series["Aylar"].Points.Clear();


                SqlCommand komut11 = new SqlCommand("select top 4 Ay,INTERNET from TBL_GIDERLER  order by ıd desc", bgl.baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    chartControl1.Series["Aylar"].Points.AddPoint(Convert.ToString(dr11[0]), Convert.ToInt32(dr11[1]));
                }
                bgl.baglanti().Close();

            }

            //Maaslar  Listeleme
            if (sayac > 20 && sayac <= 25)
            {
                groupControl2.Text = "Maaşlar";
                chartControl1.Series["Aylar"].Points.Clear();


                SqlCommand komut11 = new SqlCommand("select top 4 Ay,MAASLAR from TBL_GIDERLER  order by ıd desc", bgl.baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    chartControl1.Series["Aylar"].Points.AddPoint(Convert.ToString(dr11[0]), Convert.ToInt32(dr11[1]));
                }
                bgl.baglanti().Close();

            }

            //Ekstra  Listeleme
            if (sayac > 25 && sayac <= 30)
            {
                groupControl2.Text = "Ekstralar";
                chartControl1.Series["Aylar"].Points.Clear();


                SqlCommand komut11 = new SqlCommand("select top 4 Ay,EKSTRA from TBL_GIDERLER  order by ıd desc", bgl.baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    chartControl1.Series["Aylar"].Points.AddPoint(Convert.ToString(dr11[0]), Convert.ToInt32(dr11[1]));
                }
                bgl.baglanti().Close();

            }



            if (sayac>30)
            {
                sayac = 0;
            }

        }


        int sayac2 = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {
            sayac2++;
            
            chartControl2.Series["Aylar"].LegendTextPattern = "{V}-{A}";

            //Elektrik Faturası Listeleme
            if (sayac2 > 0 && sayac2 <= 5)
            {
                chartControl2.Series["Aylar"].Points.Clear();
                groupControl3.Text = "Elektrik Faturası";


                SqlCommand komut10 = new SqlCommand("select top 4 Ay,ELEKTRIK from TBL_GIDERLER  order by ıd desc", bgl.baglanti());
                SqlDataReader dr10 = komut10.ExecuteReader();
                while (dr10.Read())
                {
                    chartControl2.Series["Aylar"].Points.AddPoint(Convert.ToString(dr10[0]), Convert.ToInt32(dr10[1]));
                }
                bgl.baglanti().Close();
            }

            //Su Faturası Listeleme
            if (sayac2 > 5 && sayac2 <= 10)
            {
                groupControl3.Text = "Su Faturası";
                chartControl2.Series["Aylar"].Points.Clear();


                SqlCommand komut11 = new SqlCommand("select top 4 Ay,Su from TBL_GIDERLER  order by ıd desc", bgl.baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    chartControl2.Series["Aylar"].Points.AddPoint(Convert.ToString(dr11[0]), Convert.ToInt32(dr11[1]));
                }
                bgl.baglanti().Close();

            }

            //Doğalgaz Faturası Listeleme
            if (sayac2 > 10 && sayac2 <= 15)
            {
                groupControl3.Text = "Doğalgaz Faturası";
                chartControl2.Series["Aylar"].Points.Clear();


                SqlCommand komut11 = new SqlCommand("select top 4 Ay,DOGALGAZ from TBL_GIDERLER  order by ıd desc", bgl.baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    chartControl2.Series["Aylar"].Points.AddPoint(Convert.ToString(dr11[0]), Convert.ToInt32(dr11[1]));
                }
                bgl.baglanti().Close();

            }

            //İnternet Faturası Listeleme
            if (sayac2 > 15 && sayac2 <= 20)
            {
                groupControl3.Text = "İnternet Faturası";
                chartControl2.Series["Aylar"].Points.Clear();


                SqlCommand komut11 = new SqlCommand("select top 4 Ay,INTERNET from TBL_GIDERLER  order by ıd desc", bgl.baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    chartControl2.Series["Aylar"].Points.AddPoint(Convert.ToString(dr11[0]), Convert.ToInt32(dr11[1]));
                }
                bgl.baglanti().Close();

            }

            //Maaslar  Listeleme
            if (sayac2 > 20 && sayac2 <= 25)
            {
                groupControl3.Text = "Maaşlar";
                chartControl2.Series["Aylar"].Points.Clear();


                SqlCommand komut11 = new SqlCommand("select top 4 Ay,MAASLAR from TBL_GIDERLER  order by ıd desc", bgl.baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    chartControl2.Series["Aylar"].Points.AddPoint(Convert.ToString(dr11[0]), Convert.ToInt32(dr11[1]));
                }
                bgl.baglanti().Close();

            }

            //Ekstra  Listeleme
            if (sayac2 > 25 && sayac2 <= 30)
            {
                groupControl3.Text = "Ekstralar";
                chartControl2.Series["Aylar"].Points.Clear();


                SqlCommand komut11 = new SqlCommand("select top 4 Ay,EKSTRA from TBL_GIDERLER  order by ıd desc", bgl.baglanti());
                SqlDataReader dr11 = komut11.ExecuteReader();
                while (dr11.Read())
                {
                    chartControl2.Series["Aylar"].Points.AddPoint(Convert.ToString(dr11[0]), Convert.ToInt32(dr11[1]));
                }
                bgl.baglanti().Close();

            }



            if (sayac2 > 30)
            {
                sayac2 = 0;
            }
        }

        private void gridView1_RowStyle_1(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            e.Appearance.BackColor = Color.LightCyan;
            e.Appearance.BackColor2 = Color.CadetBlue;
        }

        private void gridView2_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            e.Appearance.BackColor = Color.PaleTurquoise;
            e.Appearance.BackColor2 = Color.SteelBlue;
        }

        private void gridView3_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            e.Appearance.BackColor = Color.MintCream;
            e.Appearance.BackColor2 = Color.Teal;
        }

    }
}
