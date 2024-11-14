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
    public partial class FrmAnaSayfa : Form
    {
        public FrmAnaSayfa()
        {
            InitializeComponent();
        }

        private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            e.Appearance.BackColor = Color.PaleTurquoise;
            e.Appearance.BackColor2 = Color.SteelBlue;
        }

        private void gridView2_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            e.Appearance.BackColor = Color.Honeydew;
            e.Appearance.BackColor2 = Color.DarkSeaGreen;
        }

        private void gridView3_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            e.Appearance.BackColor = Color.Azure;
            e.Appearance.BackColor2 = Color.RoyalBlue;
        }

        private void gridView4_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            e.Appearance.BackColor = Color.OldLace;
            e.Appearance.BackColor2 = Color.SandyBrown;
        }
    }
}
