using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace EntityFrameworkPrj1
{
    public partial class MusteriForm : Form
    {
        ProjelerVTEntities entities=new ProjelerVTEntities();
        public MusteriForm()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            tumKayitlariListele();
        }
        private void tumKayitlariListele()
        {
            var musteriler = (from musteri in entities.Musteri
                              select new
                              {
                                  musteri.MusteriId,
                                  musteri.Ad,
                                  musteri.Soyad,
                                  musteri.Sehir
                              }).ToList();
            dataGridView1.DataSource = musteriler;
            dataGridView1.ClearSelection();
            temizle();
            label6.Text = entities.Musteri.Count().ToString();
        }
        private void temizle()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }
        private void MusteriForm_Load(object sender, EventArgs e)
        {
            tumKayitlariListele();
            textBox1.Text = "0";
            label6.Text=entities.Musteri.Count().ToString();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Musteri musteri=new Musteri();
            musteri.Ad = textBox2.Text;
            musteri.Soyad = textBox3.Text;
            musteri.Sehir = textBox4.Text;
            try
            {
                entities.Musteri.Add(musteri);
                entities.SaveChanges();
                MessageBox.Show("Müşteri ekleme işlemi başarılı!");
                tumKayitlariListele();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Veri Tabanı işlemleri sırasında hata oluştu! Hata Kodu: H001\n" + ex.Message);
            }
            finally
            {

            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilenSatir = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[secilenSatir].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[secilenSatir].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[secilenSatir].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[secilenSatir].Cells[3].Value.ToString();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int musteriId=Convert.ToInt32(textBox1.Text);
                var musteri=entities.Musteri.Find(musteriId);
                entities.Musteri.Remove(musteri);
                entities.SaveChanges();
                MessageBox.Show("Silme işlemi başarılı!");
                tumKayitlariListele();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri Tabanı işlemleri sırasında hata oluştu! Hata Kodu: H002\n" + ex.Message);
            }
            finally
            {

            }
        }
        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {

        }
    }
}
