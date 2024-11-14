using DevExpress.Data.Linq.Helpers;
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
    public partial class FrmAyarlar : Form
    {
        public FrmAyarlar()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_ADMIN", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;

            TxtAd.Text = "";
            TxtSifre.Text = "";
        }
        private void FrmAyarlar_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            e.Appearance.BackColor = Color.Moccasin;
            e.Appearance.BackColor2 = Color.Peru;
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                TxtAd.Text = dr["KullaniciAdi"].ToString();
                TxtSifre.Text = dr["Sifre"].ToString();


            }
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            if (BtnKaydet.Text == "Kaydet")
            {


                SqlCommand komut = new SqlCommand("insert into TBL_ADMIN values (@p1,@p2)", bgl.baglanti());
                komut.Parameters.AddWithValue("@p1", TxtAd.Text);
                komut.Parameters.AddWithValue("@p2", TxtSifre.Text);
                komut.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Admin Bilgileri Başarıyla Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
            }


            if (BtnKaydet.Text == "Güncelle")
            {
                SqlCommand komut1 = new SqlCommand("update  TBL_ADMIN set Sifre=@p2 where KullaniciAdi=@p1", bgl.baglanti());
                komut1.Parameters.AddWithValue("@p1", TxtAd.Text);
                komut1.Parameters.AddWithValue("@p2", TxtSifre.Text);
                komut1.ExecuteNonQuery();
                bgl.baglanti().Close();
                MessageBox.Show("Admin Bilgileri Başarıyla Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                listele();
            }

        }



        private void TxtAd_TextChanged(object sender, EventArgs e)
        {
            if (TxtAd.Text != "")
            {
                BtnKaydet.Text = "Güncelle";
                BtnKaydet.Appearance.BackColor = Color.GreenYellow;
            }
            else
            {
                BtnKaydet.Text = "Kaydet";
                BtnKaydet.Appearance.BackColor = Color.OrangeRed;
            }
        }
    }
}
