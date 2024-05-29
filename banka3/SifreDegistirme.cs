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

namespace banka3
{
    public partial class SifreDegistirme : Form
    {
        public SifreDegistirme()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("server=DESKTOP-BVGAO0O; initial catalog=Mobilbankacılık; integrated security=sspi;");
        private void button1_Click(object sender, EventArgs e)
        {
           
            if (txtEski.Text=="" || txtYeni.Text=="")
            {
                MessageBox.Show("Boş alanları giriniz", "Şifre Değiştirme İşlemi");

            }
            else if (txtYeni.Text.Length<5)
            {
                MessageBox.Show("Şifreniz en az 5 karakterli olmalıdır.", "Şifre Değiştirme İşlemi");
            }
            else
            {
                SqlCommand komut = new SqlCommand("update musteriler set sifre =  @p1   where sifre= @p2", con);
                komut.Parameters.AddWithValue("@p1", txtYeni.Text);
                komut.Parameters.AddWithValue("@p2", txtEski.Text);


                con.Open();
                int sonuc = komut.ExecuteNonQuery();
                if (sonuc == 1)
                {
                    MessageBox.Show("Şifre Değiştirme başarılı", "Şifre Değiştirme İşlemi", MessageBoxButtons.OK);
                    
                }

                else
                {
                    MessageBox.Show("Şifre Değiştirme başarısız !","Şifre Değiştirme  İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Warning);



                }
                con.Close();
                txtEski.Text = "";
                txtYeni.Text = "";
            }
        }
    }
}
