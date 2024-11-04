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
           
            if (frmusteri == null)//fr nesnesi tanımlanmamıssa yeniden açsın  yani ard arda açmasın
            {
                frmusteri = new FrmMusteriler();
                frmusteri.MdiParent = this;
                frmusteri.Show();
            }
            frmusteri.Focus();
        }
    }
}
