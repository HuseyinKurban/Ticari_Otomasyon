using DevExpress.XtraReports.UI;
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

namespace Ticari_Otomasyon
{
    public partial class FrmFaturalar : Form
    {
        public FrmFaturalar()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_FATURABILGI", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
            textTemizle();
        }

        void textTemizle()
        {
            Txtid.Text = "";
            TxtSeri.Text = "";
            TxtSiraNo.Text = "";
            MskTarih.Text = "";
            MskSaat.Text = "";
            TxtVergiDairesi.Text = "";
            TxtAlici.Text = "";
            TxtTeden.Text = "";
            TxtTalan.Text = "";

            TxtUrunid.Text="";
            TxtUrunAd.Text = "";
            TxtMiktar.Text = "";
            TxtFiyat.Text = "";
            TxtTutar.Text = "";
            TxtFaturaid.Text = "";
            TxtPersonel.Text = "";
            TxtFirma.Text = "";
            TxtFaturaid.Text = "";
            RchNotlar.Text = "";

        }
        private void FrmFaturalar_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {

            
            if (TxtFaturaid.Text == "" )
            {
                SqlCommand komut = new SqlCommand("insert into TBL_FATURABILGI (SERI,SIRANO,TARIH,SAAT,VERGIDAIRE,ALICI,TESLIMEDEN,TESLIMALAN) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", TxtSeri.Text);
                komut.Parameters.AddWithValue("@p2", TxtSiraNo.Text);
                komut.Parameters.AddWithValue("@p3", MskTarih.Text);
                komut.Parameters.AddWithValue("@p4", MskSaat.Text);
                komut.Parameters.AddWithValue("@p5", TxtVergiDairesi.Text);
                komut.Parameters.AddWithValue("@p6", TxtAlici.Text);
                komut.Parameters.AddWithValue("@p7", TxtTeden.Text);
                komut.Parameters.AddWithValue("@p8", TxtTalan.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Fatura Bilgileri Başarıyla Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
                textTemizle();

            }

            //Firma Carisi
            if (TxtFaturaid.Text!="" && comboBox1.Text == "Firma")
            {
                double miktar, tutar, fiyat;
                fiyat=Convert.ToDouble(TxtFiyat.Text);
                miktar=Convert.ToDouble(TxtMiktar.Text);
                tutar = miktar * fiyat;
                TxtTutar.Text=tutar.ToString();

                SqlCommand komut2=new SqlCommand("insert into TBL_FATURADETAY (URUNAD,MIKTAR,FIYAT,TUTAR,FATURAID) VALUES (@p1,@p2,@p3,@p4,@p5)",bgl.baglanti());
                komut2.Parameters.AddWithValue("@p1", TxtUrunAd.Text);
                komut2.Parameters.AddWithValue("@p2", TxtMiktar.Text);
                komut2.Parameters.AddWithValue("@p3",decimal.Parse( TxtFiyat.Text));
                komut2.Parameters.AddWithValue("@p4",decimal.Parse( TxtTutar.Text));
                komut2.Parameters.AddWithValue("@p5", TxtFaturaid.Text);
                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();


                //Hareket Tablosuna Veri Girişi
                SqlCommand komut3 = new SqlCommand("insert into TBL_FIRMAHAREKETLER (URUNID,ADET,PERSONEL,FIRMA,FIYAT,TOPLAM,FATURAID,TARIH,NOTLAR) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)", bgl.baglanti());
                komut3.Parameters.AddWithValue("@p1", TxtUrunid.Text);
                komut3.Parameters.AddWithValue("@p2", TxtMiktar.Text);
                komut3.Parameters.AddWithValue("@p3", TxtPersonel.Text);
                komut3.Parameters.AddWithValue("@p4", TxtFirma.Text);
                komut3.Parameters.AddWithValue("@p5", decimal.Parse( TxtFiyat.Text));
                komut3.Parameters.AddWithValue("@p6", decimal.Parse( TxtTutar.Text));
                komut3.Parameters.AddWithValue("@p7", TxtFaturaid.Text);
                komut3.Parameters.AddWithValue("@p8", MskTarih.Text);
                komut3.Parameters.AddWithValue("@p9", RchNotlar.Text);
                komut3.ExecuteNonQuery();
                bgl.baglanti().Close();

                //Stok sayısını azaltma
                SqlCommand komut4 = new SqlCommand("update TBL_URUNLER set adet=adet-@p1 where ID=@p2", bgl.baglanti());
                komut4.Parameters.AddWithValue("@p1", TxtMiktar.Text);
                komut4.Parameters.AddWithValue("@p2", TxtUrunid.Text);
                komut4.ExecuteNonQuery();
                bgl.baglanti().Close();

                textTemizle();
                MessageBox.Show("Faturaya Ait Ürün Bilgileri Başarıyla Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                

            }

            
         
            //Müşteri Carisi
            if (TxtFaturaid.Text != "" && comboBox1.Text == "Müşteri")
            {
                double miktar, tutar, fiyat;
                fiyat = Convert.ToDouble(TxtFiyat.Text);
                miktar = Convert.ToDouble(TxtMiktar.Text);
                tutar = miktar * fiyat;
                TxtTutar.Text = tutar.ToString();

                SqlCommand komut2 = new SqlCommand("insert into TBL_FATURADETAY (URUNAD,MIKTAR,FIYAT,TUTAR,FATURAID) VALUES (@p1,@p2,@p3,@p4,@p5)", bgl.baglanti());
                komut2.Parameters.AddWithValue("@p1", TxtUrunAd.Text);
                komut2.Parameters.AddWithValue("@p2", TxtMiktar.Text);
                komut2.Parameters.AddWithValue("@p3", decimal.Parse(TxtFiyat.Text));
                komut2.Parameters.AddWithValue("@p4", decimal.Parse(TxtTutar.Text));
                komut2.Parameters.AddWithValue("@p5", TxtFaturaid.Text);
                komut2.ExecuteNonQuery();
                bgl.baglanti().Close();


                //Hareket Tablosuna Veri Girişi
                SqlCommand komut3 = new SqlCommand("insert into TBL_MUSTERIHAREKETLER (URUNID,ADET,PERSONEL,MUSTERI,FIYAT,TOPLAM,FATURAID,TARIH,NOTLAR) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)", bgl.baglanti());
                komut3.Parameters.AddWithValue("@p1", TxtUrunid.Text);
                komut3.Parameters.AddWithValue("@p2", TxtMiktar.Text);
                komut3.Parameters.AddWithValue("@p3", TxtPersonel.Text);
                komut3.Parameters.AddWithValue("@p4", TxtFirma.Text);
                komut3.Parameters.AddWithValue("@p5", decimal.Parse(TxtFiyat.Text));
                komut3.Parameters.AddWithValue("@p6", decimal.Parse(TxtTutar.Text));
                komut3.Parameters.AddWithValue("@p7", TxtFaturaid.Text);
                komut3.Parameters.AddWithValue("@p8", MskTarih.Text);
                komut3.Parameters.AddWithValue("@p9", RchNotlar.Text);
                komut3.ExecuteNonQuery();
                bgl.baglanti().Close();

                //Stok sayısını azaltma
                SqlCommand komut4 = new SqlCommand("update TBL_URUNLER set adet=adet-@p1 where ID=@p2", bgl.baglanti());
                komut4.Parameters.AddWithValue("@p1", TxtMiktar.Text);
                komut4.Parameters.AddWithValue("@p2", TxtUrunid.Text);
                komut4.ExecuteNonQuery();
                bgl.baglanti().Close();

                textTemizle();
                MessageBox.Show("Faturaya Ait Ürün Bilgileri Başarıyla Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                Txtid.Text = dr["FATURABILGIID"].ToString();
                TxtSeri.Text = dr["SERI"].ToString();
                TxtSiraNo.Text = dr["SIRANO"].ToString();
                MskTarih.Text = dr["TARIH"].ToString();
                MskSaat.Text = dr["SAAT"].ToString();
                TxtVergiDairesi.Text = dr["VERGIDAIRE"].ToString();
                TxtAlici.Text = dr["ALICI"].ToString();
                TxtTeden.Text = dr["TESLIMEDEN"].ToString();
                TxtTalan.Text = dr["TESLIMALAN"].ToString();

            }
        }

      

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            e.Appearance.BackColor = Color.MistyRose;
            e.Appearance.BackColor2 = Color.Lavender;
        }

    

        private void BtnSil_Click_1(object sender, EventArgs e)
        {
            DialogResult cevap;
            cevap = MessageBox.Show("Fatura Bilgilerini Silmek İstiyor Musunuz ?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (cevap == DialogResult.Yes)
            {
                SqlCommand komut = new SqlCommand("delete from TBL_FATURABILGI where FATURABILGIID=@p1", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", Txtid.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Fatura Bilgileri Başarıyla Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();

            }
        }

        private void BtnTextTemizle_Click(object sender, EventArgs e)
        {
            textTemizle();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_FATURABILGI set SERI=@P1,SIRANO=@P2,TARIH=@P3,SAAT=@P4,VERGIDAIRE=@P5,ALICI=@P6,TESLIMEDEN=@P7,TESLIMALAN=@P8 WHERE FATURABILGIID=@P9", bgl.baglanti());
            komut.Parameters.AddWithValue("@P1", TxtSeri.Text);
            komut.Parameters.AddWithValue("@P2", TxtSiraNo.Text);
            komut.Parameters.AddWithValue("@P3", MskTarih.Text);
            komut.Parameters.AddWithValue("@P4", MskSaat.Text);
            komut.Parameters.AddWithValue("@P5", TxtVergiDairesi.Text);
            komut.Parameters.AddWithValue("@P6", TxtAlici.Text);
            komut.Parameters.AddWithValue("@P7", TxtTeden.Text);
            komut.Parameters.AddWithValue("@P8", TxtTalan.Text);
            komut.Parameters.AddWithValue("@P9", Txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Fatura Bilgileri Başarıyla Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            FrmFaturaUrunDetay fr=new FrmFaturaUrunDetay();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                fr.id = dr["FATURABILGIID"].ToString();
            }
            fr.Show();
        }

        private void BtnBul_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Select  URUNAD,SATISFIYAT FROM TBL_URUNLER WHERE ID=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtUrunid.Text);
            SqlDataReader dr= komut.ExecuteReader();
            while (dr.Read())
            {
                TxtUrunAd.Text = dr[0].ToString();
                TxtFiyat.Text = dr[1].ToString();
            }
            bgl.baglanti().Close() ;
        }

        private void BtnFaturaKaydet_Click(object sender, EventArgs e)
        {

        }

        private void BtnFaturaBilgi_Click(object sender, EventArgs e)
        {
            XtraReport1 report= new XtraReport1();
            ReportPrintTool printTool = new ReportPrintTool(report);
            printTool.ShowPreviewDialog();
        }
    }
}
