using DevExpress.XtraBars;
using DevExpress.XtraGrid;
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
    public partial class FrmFaturaUrunDuzenleme : Form
    {
        public FrmFaturaUrunDuzenleme()
        {
            InitializeComponent();
        }
        public string urunid;
        sqlbaglantisi bgl=new sqlbaglantisi();
        void listele()
        {
          
            SqlCommand komut= new SqlCommand("Select URUNAD,MIKTAR,FIYAT,TUTAR From TBL_FATURADETAY where FATURAURUNID='" + urunid+"'",bgl.baglanti());
            SqlDataReader dr=komut.ExecuteReader();
            while (dr.Read())
            {
                TxtUrunAd.Text=dr[0].ToString();
                TxtMiktar.Text=dr[1].ToString();
                TxtFiyat.Text=dr[2].ToString();
                TxtTutar.Text=dr[3].ToString();
            }
            bgl.baglanti().Close();
        }

        private void FrmFaturaUrunDuzenleme_Load(object sender, EventArgs e)
        {
            TxtUrunid.Text = urunid;
            listele();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            double miktar, tutar, fiyat;
            fiyat = Convert.ToDouble(TxtFiyat.Text);
            miktar = Convert.ToDouble(TxtMiktar.Text);
            tutar = miktar * fiyat;
            TxtTutar.Text = tutar.ToString();

            SqlCommand komut= new SqlCommand("update TBL_FATURADETAY set URUNAD=@p1,MIKTAR=@p2,FIYAT=@p3,TUTAR=@p4 where FATURAURUNID=@p5 ",bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtUrunAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtMiktar.Text);
            komut.Parameters.AddWithValue("@p3",decimal.Parse( TxtFiyat.Text));
            komut.Parameters.AddWithValue("@p4", decimal.Parse(TxtTutar.Text));
            komut.Parameters.AddWithValue("@p5", urunid);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Fatura Ürün Bilgileri Başarıyla Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            DialogResult cevap;
            cevap = MessageBox.Show("Faturaya Ait Ürün Bilgilerini Silmek İstiyor Musunuz ?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (cevap == DialogResult.Yes)
            {

                SqlCommand komut = new SqlCommand("Delete from TBL_FATURADETAY where  FATURAURUNID=@p1", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", urunid);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Faturaya Ait Ürün Bilgileri Başarıyla Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
            }
        }
    }
}
