using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Ticari_Otomasyon
{
    public partial class FrmUrunler : Form
    {
        public FrmUrunler()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();

        void textTemizle()
        {
            Txtid.Text = "";
            TxtAd.Text = "";
            TxtMarka.Text = "";
            TxtModel.Text = "";
            MskTxtYil.Text = "";
            NudAdet.Value = 0;
            TxtAlisFiyat.Text = "";
            TxtSatisFiyat.Text = "";
            RchTxtDetay.Text = "";
        }

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From Tbl_Urunler", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        private void FrmUrunler_Load(object sender, EventArgs e)
        {

            listele();
            textTemizle();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into Tbl_Urunler (URUNAD,MARKA,MODEL,YIL,ADET,ALISFIYAT,SATISFIYAT,DETAY) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", TxtAd.Text);
            komut.Parameters.AddWithValue("@p2", TxtMarka.Text);
            komut.Parameters.AddWithValue("@p3", TxtModel.Text);
            komut.Parameters.AddWithValue("@p4", MskTxtYil.Text);
            komut.Parameters.AddWithValue("@p5", int.Parse(NudAdet.Value.ToString()));
            komut.Parameters.AddWithValue("@p6", decimal.Parse(TxtAlisFiyat.Text));
            komut.Parameters.AddWithValue("@p7", decimal.Parse(TxtSatisFiyat.Text));
            komut.Parameters.AddWithValue("@p8", RchTxtDetay.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Ürün Bilgileri Başarıyla Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
            textTemizle();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            DialogResult cevap;
            cevap = MessageBox.Show(TxtAd.Text + " Adlı Ürünü Silmek İstiyor Musunuz ?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //id değerine göre silme
            if (cevap == DialogResult.Yes)
            {
                SqlCommand komut = new SqlCommand("Delete From Tbl_Urunler Where ID=@p1", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", Txtid.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Ürün Bilgileri Başarıyla Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
                textTemizle();
            }

        }
        //imlecin satır odağı değiştiği zaman
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //data row=veri satırı 
            //GetDataRow=get almak, data veri ,row satır = satırın verisini al


            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            Txtid.Text = dr["ID"].ToString();
            TxtAd.Text = dr["URUNAD"].ToString();
            TxtMarka.Text = dr["MARKA"].ToString();
            TxtModel.Text = dr["MODEL"].ToString();
            MskTxtYil.Text = dr["YIL"].ToString();
            NudAdet.Maximum = int.Parse(dr["ADET"].ToString());
            NudAdet.Value = int.Parse(dr["ADET"].ToString());
            TxtAlisFiyat.Text = dr["ALISFIYAT"].ToString();
            TxtSatisFiyat.Text = dr["SATISFIYAT"].ToString();
            RchTxtDetay.Text = dr["DETAY"].ToString();




        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            DialogResult cevap;
            cevap = MessageBox.Show(TxtAd.Text + " Adlı Ürünün Bilgilerini Güncellemek İstiyor Musunuz ?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //id değerine göre güncelleme
            if (cevap == DialogResult.Yes)
            {
                SqlCommand komut = new SqlCommand("update Tbl_Urunler set URUNAD=@P1,MARKA=@P2,MODEL=@P3,YIL=@P4,ADET=@P5,ALISFIYAT=@P6,SATISFIYAT=@P7,DETAY=@P8 WHERE ID=@P9", bgl.baglanti());
                komut.Parameters.AddWithValue("@P1", TxtAd.Text);
                komut.Parameters.AddWithValue("@P2", TxtMarka.Text);
                komut.Parameters.AddWithValue("@P3", TxtModel.Text);
                komut.Parameters.AddWithValue("@P4", MskTxtYil.Text);
                komut.Parameters.AddWithValue("@P5", int.Parse(NudAdet.Value.ToString()));
                komut.Parameters.AddWithValue("@P6", decimal.Parse(TxtAlisFiyat.Text));
                komut.Parameters.AddWithValue("@P7", decimal.Parse(TxtSatisFiyat.Text));
                komut.Parameters.AddWithValue("@P8", RchTxtDetay.Text);
                komut.Parameters.AddWithValue("@P9", Txtid.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Ürün Bilgileri Başarıyla Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
                textTemizle();

            }
        }

        private void BtnTextTemizle_Click(object sender, EventArgs e)
        {
            textTemizle();
        }

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            e.Appearance.BackColor = Color.MistyRose;
            e.Appearance.BackColor2 = Color.Salmon;
        }
    }
}
