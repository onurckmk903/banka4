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

namespace banka3
{
    public partial class SifreUret : Form
    {
        public SifreUret()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("server=DESKTOP-BVGAO0O; initial catalog=Mobilbankacılık; integrated security=sspi;");
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtTC.Text == "" || txtTel.Text == "" || txtYeni.Text == "")
            {
                MessageBox.Show("Boş alanları giriniz", "Şifremi Unuttum");

            }
            else if (txtYeni.Text.Length < 5)
            {
                MessageBox.Show("Şifreniz en az 5 karakterli olmalıdır.", "Şifremi Unuttum");
            }
            else
            {
                SqlCommand komut = new SqlCommand("update musteriler set sifre =  @p1   where tcNo = @p2 and telefon=@p3", con);
                komut.Parameters.AddWithValue("@p1", txtYeni.Text);
                komut.Parameters.AddWithValue("@p2", txtTC.Text);
                komut.Parameters.AddWithValue("@p3", txtTel.Text);


                con.Open();
                int sonuc = komut.ExecuteNonQuery();
                if (sonuc == 1)
                {
                    MessageBox.Show("Şifre Değiştirme başarılı", "Şifremi Unuttum", MessageBoxButtons.OK);

                }

                else
                {
                    MessageBox.Show("Şifre Değiştirme başarısız !", "Şifremi Unuttum", MessageBoxButtons.OK, MessageBoxIcon.Warning);



                }
                con.Close();
                txtYeni.Text = "";
                txtTC.Text = "";
                txtTel.Text = "";
            }
        }
    }
}
