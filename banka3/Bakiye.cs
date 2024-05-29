using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace banka3
{
    public partial class Bakiye : Form
    {
        public Bakiye()
        {
            InitializeComponent();
        }

        private void Bakiye_Load(object sender, EventArgs e)
        {
            lblBakiye.Text=Form1.mBakiye.ToString() + "TL";
            Hareketkaydet.kaydet(Form1.mID,  " Bakiye Sorgulandı");
        }
    }
}
