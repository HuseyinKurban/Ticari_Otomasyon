using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ticari_Otomasyon
{
    public partial class FrmAnaModul : Form
    {
        public FrmAnaModul()
        {
            InitializeComponent();
        }

        FrmUrunler frurun;
        private void BtnUrunler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
          
            if (frurun == null)//fr nesnesi tanımlanmamıssa yeniden açsın  yani ard arda açmasın
            {
                frurun = new FrmUrunler();
                //bu urunler formunu ana formdaki parentte ekleyip aç
                frurun.MdiParent = this;
                frurun.Show();
                
            }
            frurun.Focus();
        }

        FrmMusteriler frmusteri;
        private void BtnMusteriler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
            if (frmusteri == null)
            {
                frmusteri = new FrmMusteriler();
                frmusteri.MdiParent = this;
                frmusteri.Show();
            }
            frmusteri.Focus();
        }

        FrmFirmalar frfirma;
        private void BtnFirmalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(frfirma==null)
            {
                frfirma=new FrmFirmalar();
                frfirma.MdiParent = this;
                frfirma.Show();
            }
            frfirma.Focus();

        }

        FrmPersoneller frpersonel;
        private void BtnPersoneller_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(frpersonel==null)
            {
                frpersonel=new FrmPersoneller();
                frpersonel.MdiParent = this;
                frpersonel.Show();
            }
            frpersonel.Focus();
        }

        FrmRehber frrehber;
        private void BtnRehber_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frrehber==null)
            {
                frrehber=new FrmRehber();
                frrehber.MdiParent = this;
                frrehber.Show();
            }
            frrehber.Focus();
        }

        FrmGiderler frgider;
        private void BtnGiderler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(frgider==null)
            {
                frgider=new FrmGiderler();
                frgider.MdiParent = this;
                frgider.Show();
            }
            frgider.Focus();
        }
    }
}
