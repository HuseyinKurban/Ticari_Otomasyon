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
        public string kullanici;
        FrmUrunler frurun;

        private void BtnUrunler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
          
            if (frurun == null || frurun.IsDisposed)//fr nesnesi tanımlanmamıssa yeniden açsın  yani ard arda açmasın ve kapalıysa acsın
            {
                frurun = new FrmUrunler();
                //bu urunler formunu ana formdaki parentte ekleyip aç
                frurun.MdiParent = this;
                frurun.Show();
                
            }
            frurun.Focus();
        }

        private void FrmAnaModul_Load(object sender, EventArgs e)
        {
            if (franasayfa == null || franasayfa.IsDisposed)
            {
                franasayfa = new FrmAnaSayfa();
                franasayfa.MdiParent = this;
                franasayfa.Show();
            }
            franasayfa.Focus();
        }

        FrmMusteriler frmusteri;
        private void BtnMusteriler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           
            if (frmusteri == null || frmusteri.IsDisposed)
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
            if(frfirma==null || frfirma.IsDisposed)
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
            if(frpersonel==null || frpersonel.IsDisposed)
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
            if (frrehber==null || frrehber.IsDisposed)
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
            if(frgider==null || frgider.IsDisposed)
            {
                frgider=new FrmGiderler();
                frgider.MdiParent = this;
                frgider.Show();
            }
            frgider.Focus();
        }
        FrmBankalar frbanka;
        private void BtnBankalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(frbanka==null || frbanka.IsDisposed) 
            {
                frbanka=new FrmBankalar();
                frbanka.MdiParent = this;
                frbanka.Show();
            }
            frbanka.Focus();
        }
        FrmFaturalar frfatura;
        private void BtnFaturalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
          
            if (frfatura == null || frfatura.IsDisposed)
            {
                frfatura = new FrmFaturalar();
                frfatura.MdiParent = this;
                frfatura.Show();
            }
            frfatura.Focus();
        }

        FrmNotlar frnotlar;
        private void BtnNotlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(frnotlar==null || frnotlar.IsDisposed)
            {
                frnotlar=new FrmNotlar();
                frnotlar.MdiParent = this;
                frnotlar.Show();
            }
            frnotlar.Focus();
        }

        FrmHareketler frhareketler;
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frhareketler == null || frhareketler.IsDisposed)
            {
                frhareketler = new FrmHareketler();
                frhareketler.MdiParent = this;
                frhareketler.Show();
            }
            frhareketler.Focus();
        }

        FrmRaporlar fraporlar;
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fraporlar == null || fraporlar.IsDisposed)
            {
                fraporlar = new FrmRaporlar();
                fraporlar.MdiParent = this;
                fraporlar.Show();
            }
            fraporlar.Focus();
        }

        FrmStoklar frstoklar;
        private void BtnStoklar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frstoklar == null || frstoklar.IsDisposed)
            {
                frstoklar = new FrmStoklar();
                frstoklar.MdiParent = this;
                frstoklar.Show();
            }
            frstoklar.Focus();
        }

        FrmAyarlar frayarlar;
        private void BtnAyarlar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frayarlar == null || frayarlar.IsDisposed)
            {
                frayarlar = new FrmAyarlar();
                frayarlar.MdiParent = this;
                frayarlar.Show();
            }
            frayarlar.Focus();
        }

        FrmKasa frkasa;
        private void BtnKasa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frkasa == null || frkasa.IsDisposed)
            {
                frkasa = new FrmKasa();
                frkasa.ad = kullanici;
                frkasa.MdiParent = this;
                frkasa.Show();
            }
            frkasa.Focus();
        }

        FrmAnaSayfa franasayfa;
        private void BtnAnaSayfa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (franasayfa == null || franasayfa.IsDisposed)
            {
                franasayfa = new FrmAnaSayfa();
                franasayfa.MdiParent = this;
                franasayfa.Show();
            }
            franasayfa.Focus();
        }

    
    }
}
