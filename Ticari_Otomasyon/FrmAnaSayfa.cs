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
using System.Xml;


namespace Ticari_Otomasyon
{
    public partial class FrmAnaSayfa : Form
    {
        public FrmAnaSayfa()
        {
            InitializeComponent();
        }

        sqlbaglantisi bgl = new sqlbaglantisi();

        void AzalanStok()
        {
           
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select URUNAD, Sum(Adet) as 'Adet' from TBL_URUNLER group by URUNAD having sum(adet)<=3000 order by SUM(Adet)", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;

        }

        void Ajanda()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select  top 15 TARIH,SAAT,BASLIK from TBL_NOTLAR order by ID desc  ", bgl.baglanti());
            da.Fill(dt);
            gridControl2.DataSource = dt;
        }

        void FirmaHareketleri()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Exec FirmaHareketSon10", bgl.baglanti());
            da.Fill(dt);
            gridControl3.DataSource = dt;
        }

        void FirmaFihrist()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select AD,TELEFON1 from TBL_FIRMALAR ", bgl.baglanti());
            da.Fill(dt);
            gridControl4.DataSource = dt;
        }

        void Haberler()
        {
            XmlTextReader xmloku = new XmlTextReader("https://www.hurriyet.com.tr/rss/anasayfa");
            while (xmloku.Read())
            {
                if (xmloku.Name == "title")
                {
                    listBox1.Items.Add(xmloku.ReadString());
                }
            }
        }

        private void FrmAnaSayfa_Load(object sender, EventArgs e)
        {
            AzalanStok();
            Ajanda();
            FirmaHareketleri();
            FirmaFihrist();
            Haberler();

            webBrowser1.Navigate("http://www.tcmb.gov.tr/kurlar/today.xml");
    

        }

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            e.Appearance.BackColor = Color.SteelBlue;
            e.Appearance.BackColor2 = Color.PaleTurquoise;

        }

        private void gridView2_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            e.Appearance.BackColor = Color.Plum;
            e.Appearance.BackColor2 = Color.MediumPurple;
        }

        private void gridView3_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            e.Appearance.BackColor = Color.LemonChiffon;
            e.Appearance.BackColor2 = Color.Khaki;

        }

        private void gridView4_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            e.Appearance.BackColor = Color.AliceBlue;
            e.Appearance.BackColor2 = Color.LightSkyBlue;
        }
    }
}
