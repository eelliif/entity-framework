using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EntityFrameworkPrj1
{
    public partial class UrunForm : Form
    {
        ProjelerVTEntities entities = new ProjelerVTEntities();
        public UrunForm()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            tumKayitlariGöster();
        }
        private void tumKayitlariGöster()
        {
            var urunler = entities.Urun.ToList();
            dataGridView1.DataSource = urunler;
            dataGridView1.ClearSelection();
            temizle();
            label5.Text = entities.Urun.Count().ToString();
        }
        private void temizle()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Urun urun = new Urun();
            urun.Adi = textBox2.Text;
            urun.Fiyati = Convert.ToInt32(textBox3.Text);
            try
            {
                entities.Urun.Add(urun);
                entities.SaveChanges();
                MessageBox.Show("Ürün ekleme işlemi başarılı!");
                tumKayitlariGöster();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri Tabanı işlemleri sırasında hata oluştu! Hata Kodu: H003\n" + ex.Message);
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
        }
        private void UrunForm_Load(object sender, EventArgs e)
        {
            tumKayitlariGöster();
            textBox1.Text = "0";
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int urunId = Convert.ToInt32(textBox1.Text);
                var urun = entities.Musteri.Find(urunId);
                entities.Musteri.Remove(urun);
                entities.SaveChanges();
                MessageBox.Show("Silme işlemi başarılı!");
                tumKayitlariGöster();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri Tabanı işlemleri sırasında hata oluştu! Hata Kodu: H004\n" + ex.Message);
            }
            finally
            {

            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int urunId = Convert.ToInt32(textBox1.Text);
                var urun = entities.Urun.Find(urunId);
                if (urun != null)
                {
                    urun.Adi = textBox2.Text;
                    urun.Fiyati = Convert.ToInt32(textBox3.Text);
                    entities.SaveChanges();
                    MessageBox.Show("Güncelleme tamamlandı!");
                    tumKayitlariGöster();
                }
                else
                {
                    MessageBox.Show("Güncellenecek ürün veritabanında bulunamadı!");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Veri Tabanı işlemleri sırasında hata oluştu! Hata Kodu: H005\n" + ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }
    }
}
