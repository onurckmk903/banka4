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
    public partial class Müsteriislem : Form
    {
        public Müsteriislem()
        {
            InitializeComponent();
        }

        private void btnCikis_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
            this.Close();
        }

        private void Müsteriislem_Load(object sender, EventArgs e)
        {
            lblAdSoyad.Text=Form1.adSoyad;
            lblHesapNo.Text=Form1.mID.ToString();
        }

        private void btnParaCek_Click(object sender, EventArgs e)
        {
            ParaCek pc = new ParaCek();
            pc.Show();
        }

        private void btnParaYatir_Click(object sender, EventArgs e)
        {
            ParaYatir py = new ParaYatir();
            py.Show();
        }

        private void btnBakiyeGoruntule_Click(object sender, EventArgs e)
        {
            Bakiye b=new Bakiye(); 
            b.Show();
        }

        private void btnHavale_Click(object sender, EventArgs e)
        {
            Havale h =new Havale();
            h.Show();
        }

        private void btnSifre_Click(object sender, EventArgs e)
        {
            SifreDegistirme sd = new SifreDegistirme();
            sd.Show();
        }

        private void btnHesapH_Click(object sender, EventArgs e)
        {
            HesapHareket hh = new HesapHareket();
            hh.Show();
        }
    }
}
