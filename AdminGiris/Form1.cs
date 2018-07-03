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

namespace AdminGiris
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=desktop-ll44d11\\sqlexpress;Initial Catalog=guvenlik;Integrated Security=True");


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if(baglanti.State == ConnectionState.Closed)
                {
                    baglanti.Open();
                }
                string komut = "Select * from parola where Ad=@adi And Sifre=@sifresi";
                SqlParameter prm1 = new SqlParameter("adi", textBox1.Text.Trim());
                SqlParameter prm2 = new SqlParameter("sifresi", textBox2.Text.Trim());
                SqlCommand cmd = new SqlCommand(komut, baglanti);
                cmd.Parameters.Add(prm1);
                cmd.Parameters.Add(prm2);
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                if(dt.Rows.Count > 0)
                {
                    Form2 fr = new Form2();
                    fr.Show();
                }
                else
                {
                    MessageBox.Show("Hatali Giris","Uyarı!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }catch(SqlException ex)
            {
                MessageBox.Show("Hatali Giris");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            frm.Show();
        }
    }
}
