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
    public partial class Havale : Form
    {
        public Havale()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("server=DESKTOP-BVGAO0O; initial catalog=Mobilbankacılık; integrated security=sspi;");
        private void button1_Click(object sender, EventArgs e)
        {
            float sayi = float.Parse(txtMiktar.Text);
            if (sayi > Form1.mBakiye)
            {
                MessageBox.Show("Yetersiz Bakiye", "Havale İşlemi");
            }
            else
            {
                SqlCommand komut = new SqlCommand("update musteriler set bakiye = bakiye - @p1 where ID = @p2 ", con);
                komut.Parameters.AddWithValue("@p1", sayi);
                komut.Parameters.AddWithValue("@p2", Form1.mID);

                SqlCommand komut2 = new SqlCommand("update musteriler set bakiye = bakiye + @p3 where ID = @p4 ", con);
                komut2.Parameters.AddWithValue("@p3", txtMiktar.Text);
                komut2.Parameters.AddWithValue("@p4", txtNo.Text);

                if (sayi < 10)
                {
                    MessageBox.Show("10 TL üzerinde miktar giriniz !", "Havale / EFT işlemi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    con.Open();
                    int sonuc1 = komut2.ExecuteNonQuery();
                    con.Close();
                    if (sonuc1 == 1)
                    {
                        con.Open();
                        komut.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Havale İşlemi Gerçekleştirildi ", "Havale / EFT işlemi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Form1.mBakiye -= sayi;
                    }
                    else
                    {
                        MessageBox.Show("Alıcı Hesap NO Hatalı !", "Havale / EFT işlemi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }


            }

            txtMiktar.Text = "";
            txtNo.Text = "";
        }
    }
}
