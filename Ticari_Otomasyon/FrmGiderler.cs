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
    public partial class FrmGiderler : Form
    {
        public FrmGiderler()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl=new sqlbaglantisi();
        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from TBL_GIDERLER",bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
            textTemizle();
        }

        void textTemizle()
        {
            Txtid.Text = "";
            CmbAy.Text = "";
            CmbYıl.Text = "";
            TxtElektrik.Text = "";
            TxtSu.Text = "";
            TxtDogalgaz.Text = "";
            Txtinternet.Text = "";
            TxtMaaslar.Text = "";
            TxtEkstra.Text = "";
            RchTxtNotlar.Text = "";
        }


        private void FrmGiderler_Load(object sender, EventArgs e)
        {
            listele();

        }

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            e.Appearance.BackColor = Color.LavenderBlush;
            e.Appearance.BackColor2 = Color.MediumOrchid;
            
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("INSERT INTO TBL_GIDERLER (AY, YIL, ELEKTRIK, SU, DOGALGAZ, INTERNET, MAASLAR, EKSTRA, NOTLAR) VALUES (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", CmbAy.Text);
            komut.Parameters.AddWithValue("@p2", CmbYıl.Text);
            komut.Parameters.AddWithValue("@p3", decimal.Parse(TxtElektrik.Text));
            komut.Parameters.AddWithValue("@p4", decimal.Parse(TxtSu.Text));
            komut.Parameters.AddWithValue("@p5", decimal.Parse(TxtDogalgaz.Text));
            komut.Parameters.AddWithValue("@p6", decimal.Parse(Txtinternet.Text));
            komut.Parameters.AddWithValue("@p7", decimal.Parse(TxtMaaslar.Text));
            komut.Parameters.AddWithValue("@p8", decimal.Parse(TxtEkstra.Text));
            komut.Parameters.AddWithValue("@p9", RchTxtNotlar.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Gider Bilgileri Başarıyla Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                Txtid.Text = dr["ID"].ToString();
                CmbAy.Text = dr["AY"].ToString();
                CmbYıl.Text = dr["YIL"].ToString();
                TxtElektrik.Text = dr["ELEKTRIK"].ToString();
                TxtSu.Text = dr["SU"].ToString();
                TxtDogalgaz.Text = dr["DOGALGAZ"].ToString();
                Txtinternet.Text = dr["INTERNET"].ToString();
                TxtMaaslar.Text = dr["MAASLAR"].ToString();
                TxtEkstra.Text = dr["EKSTRA"].ToString();
                RchTxtNotlar.Text = dr["NOTLAR"].ToString();
                
            }
        }

        private void BtnTextTemizle_Click(object sender, EventArgs e)
        {
            textTemizle();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            DialogResult cvp;
           cvp= MessageBox.Show(CmbAy.Text+" Ayına Ait Gideri Silmek İstiyor Musunuz ?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (cvp == DialogResult.Yes)
            {
                SqlCommand komut = new SqlCommand("delete from TBL_GIDERLER where ID=@p1", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", Txtid.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Gider Bilgileri Başarıyla Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update TBL_GIDERLER set AY=@p1, YIL=@p2, ELEKTRIK=@p3, SU=@p4, DOGALGAZ=@p5, INTERNET=@p6, MAASLAR=@p7, EKSTRA=@p8, NOTLAR=@p9 where ID=@p10", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", CmbAy.Text);
            komut.Parameters.AddWithValue("@p2", CmbYıl.Text);
            komut.Parameters.AddWithValue("@p3", decimal.Parse(TxtElektrik.Text));
            komut.Parameters.AddWithValue("@p4", decimal.Parse(TxtSu.Text));
            komut.Parameters.AddWithValue("@p5", decimal.Parse(TxtDogalgaz.Text));
            komut.Parameters.AddWithValue("@p6", decimal.Parse(Txtinternet.Text));
            komut.Parameters.AddWithValue("@p7", decimal.Parse(TxtMaaslar.Text));
            komut.Parameters.AddWithValue("@p8", decimal.Parse(TxtEkstra.Text));
            komut.Parameters.AddWithValue("@p9", RchTxtNotlar.Text);
            komut.Parameters.AddWithValue("@p10", Txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Gider Bilgileri Başarıyla Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }
    }
}
