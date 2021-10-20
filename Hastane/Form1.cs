using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;

namespace Hastane
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-026NNRH\\SQLEXPRESS;Initial Catalog=Hastane;Integrated Security=True");

        private void verilerigöster()
        {
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from HastaKayit",baglanti);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["sırano"].ToString();
                ekle.SubItems.Add(oku["ad"].ToString());
                ekle.SubItems.Add(oku["soyad"].ToString());
                ekle.SubItems.Add(oku["tc"].ToString());
                ekle.SubItems.Add(oku["tel"].ToString());
                ekle.SubItems.Add(oku["dtarih"].ToString());
                ekle.SubItems.Add(oku["ktarih"].ToString());
                ekle.SubItems.Add(oku["sikayet"].ToString());
                ekle.SubItems.Add(oku["alan"].ToString());

                listView1.Items.Add(ekle);

            }
            baglanti.Close();
        }
            private void button1_Click(object sender, EventArgs e)
        {
            verilerigöster();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into HastaKayit (ad,soyad,tc,tel,dtarih,ktarih,sikayet,alan) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + maskedTextBox1.Text + "','" + maskedTextBox2.Text + "','" + maskedTextBox3.Text + "','" + textBox4.Text + "','" + comboBox1.Text + "')", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            maskedTextBox1.Clear();
            maskedTextBox2.Clear();
        }

        int id = 0;
        private void button3_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("delete from HastaKayit where sırano =(" + id + ")", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            verilerigöster();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("update HastaKayit set ad='" + textBox1.Text + "',soyad='" + textBox2.Text + "',tc='" + textBox3.Text + "',tel='" + maskedTextBox1.Text + "',dtarih='" + maskedTextBox2.Text + "',sikayet='" + textBox4.Text + "',alan='" + comboBox1.Text + "'  where sırano=" + id + "", baglanti);
            komut.ExecuteNonQuery();
            baglanti.Close();
            baglanti.Close();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            maskedTextBox1.Clear();
            maskedTextBox2.Clear();
            maskedTextBox3.Clear();
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            id = int.Parse(listView1.SelectedItems[0].SubItems[0].Text);

            textBox1.Text = listView1.SelectedItems[0].SubItems[1].Text; 
            textBox2.Text = listView1.SelectedItems[0].SubItems[2].Text;
            textBox3.Text = listView1.SelectedItems[0].SubItems[3].Text;
            maskedTextBox1.Text = listView1.SelectedItems[0].SubItems[4].Text;
            maskedTextBox2.Text = listView1.SelectedItems[0].SubItems[5].Text;
            maskedTextBox3.Text = listView1.SelectedItems[0].SubItems[6].Text;
            textBox4.Text = listView1.SelectedItems[0].SubItems[7].Text;
            comboBox1.Text = listView1.SelectedItems[0].SubItems[8].Text;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox1.Text=="Sarı Alan")
            {
                comboBox1.BackColor = Color.Yellow;
            }
            if (comboBox1.Text == "Yeşil Alan")
            {
                comboBox1.BackColor = Color.Green;
            }
            if (comboBox1.Text == "Kırmızı Alan")
            { 
                comboBox1.BackColor = Color.Red;
            }
            if (comboBox1.Text == "")
            {
                comboBox1.BackColor = Color.PeachPuff;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select * from HastaKayit where ad like'%"+textBox5.Text+"%'", baglanti);
            SqlDataReader oku = komut.ExecuteReader();

            while (oku.Read())
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["sırano"].ToString();
                ekle.SubItems.Add(oku["ad"].ToString());
                ekle.SubItems.Add(oku["soyad"].ToString());
                ekle.SubItems.Add(oku["tc"].ToString());
                ekle.SubItems.Add(oku["tel"].ToString());
                ekle.SubItems.Add(oku["dtarih"].ToString());
                ekle.SubItems.Add(oku["ktarih"].ToString());
                ekle.SubItems.Add(oku["sikayet"].ToString());
                ekle.SubItems.Add(oku["alan"].ToString());

                listView1.Items.Add(ekle);

            }
            baglanti.Close();
        } 
    }
}
