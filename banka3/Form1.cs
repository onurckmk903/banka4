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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("server=DESKTOP-BVGAO0O; initial catalog=Mobilbankacılık; integrated security=sspi;");
        public static string adSoyad = "";
        public static int mID=0;
        public static float mBakiye = 0.0f;
        private void Form1_Load(object sender, EventArgs e)
        {
            radioButton2.Checked = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string kAdi=textBox1.Text;
            string parola=textBox2.Text;
            bool sonuc = false;
            if (radioButton1.Checked)
            {
                if (kAdi =="admin"&& parola == "123")
                {
                    Yetkiliislem yi=new Yetkiliislem();
                    yi.Show();
                    this.Hide();
                }
            }
            else
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select * from musteriler where tcNo = @p1 and sifre = @p2 and durum = 1", con);
                cmd.Parameters.AddWithValue("p1",kAdi);
                cmd.Parameters.AddWithValue("p2", parola);
                
                SqlDataReader dr=cmd.ExecuteReader();
                while (dr.Read())
                {
                    adSoyad = dr["adSoyad"].ToString();
                    mID =int.Parse( dr["ID"].ToString());
                    mBakiye = float.Parse(dr["bakiye"].ToString());
                    sonuc= true;
                } 
              con.Close();
                if (sonuc)
                {
                    sonuc = false;
                    Müsteriislem mi = new Müsteriislem();
                    mi.Show();
                }
                else
                {
                    MessageBox.Show("Hatalı kullanıcı adı/tc , parola veya hesabınız bloke edilmiştir !","hatalı giriş denemesi");
                }


            }
            textBox1.Text = "";
            textBox2.Text = "";
              
            
            
         
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SifreUret su = new SifreUret();
            su.Show();
        }
    }
}
