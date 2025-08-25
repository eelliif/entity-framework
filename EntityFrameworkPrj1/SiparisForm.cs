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
    public partial class SiparisForm : Form
    {
        ProjelerVTEntities entities = new ProjelerVTEntities();
        public SiparisForm()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            tumKayitlariListele();
            textBox2.Text = "0";
        }
        private void tumKayitlariListele()
        {
            var siparisler = (from siparis in entities.Siparis
                              select new
                              {
                                  siparis.SiparisNo,
                                  siparis.Tarih,
                                  siparis.MusteriId,
                                  siparis.UrunId,
                                  siparis.Adet
                              }).ToList();
            dataGridView1.DataSource = siparisler;
            textBox1.Text = "0";
            dataGridView1.ClearSelection();
            label7.Text= entities.Urun.Count().ToString();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Siparis siparis = new Siparis();
                siparis.Tarih = dateTimePicker1.Value;
                siparis.MusteriId = Convert.ToInt32(comboBox1.SelectedValue.ToString());
                siparis.UrunId = Convert.ToInt32(comboBox2.SelectedValue.ToString());
                siparis.Adet = Convert.ToInt32(textBox2.Text);
                entities.Siparis.Add(siparis);
                entities.SaveChanges();
                tumKayitlariListele();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Veri Tabanı işlemleri sırasında hata oluştu, Hata Kodu:H021\n" + ex.Message);
            }
        }
        private void SiparisForm_Load(object sender, EventArgs e)
        {
            tumKayitlariListele();
            var musteriler = (from musteri in entities.Musteri
                              select new
                              {
                                  musteri.MusteriId,
                                  musteri.Ad,
                                  musteri.Soyad
                              }).ToList();
            comboBox1.ValueMember = "MusteriId"; //Bu satır, ComboBox'taki her bir öğenin arka planda saklanacak olan gerçek değerini belirler.
            comboBox1.DisplayMember = "Ad" + "Soyad"; //Bu satır, ComboBox'ta kullanıcıya gösterilecek metni belirler.
            comboBox1.DataSource = musteriler;
            var urunler = (from urun in entities.Urun
                           select new
                           {
                               urun.UrunId,
                               urun.Adi,
                               urun.Fiyati
                           }).ToList();
            comboBox2.ValueMember = "UrunId";
            comboBox2.DisplayMember = "Adi" + "Fiyati";
            comboBox2.DataSource = urunler;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilenSatir = dataGridView1.SelectedCells[0].RowIndex;
            textBox1.Text = dataGridView1.Rows[secilenSatir].Cells[0].Value.ToString();
            dateTimePicker1.Text = dataGridView1.Rows[secilenSatir].Cells[1].Value.ToString();
            int musteriId = Convert.ToInt32(dataGridView1.Rows[secilenSatir].Cells[2].Value.ToString());
            comboBox1.SelectedValue = musteriId;
            int urunId = Convert.ToInt32(dataGridView1.Rows[secilenSatir].Cells[3].Value.ToString());
            comboBox2.SelectedValue = urunId;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int siparisNo = Convert.ToInt32(textBox1.Text);
                var siparis = entities.Siparis.Find(siparisNo);
                siparis.Tarih = dateTimePicker1.Value;
                siparis.MusteriId = Convert.ToInt32(comboBox1.SelectedValue.ToString());
                siparis.UrunId = Convert.ToInt32(comboBox2.SelectedValue.ToString());
                siparis.Adet = Convert.ToInt32(textBox2.Text);
                entities.SaveChanges();
                tumKayitlariListele();
            }
             catch(Exception ex)
            {
                MessageBox.Show("Veri Tabanı işlemleri sırasında hata oluştu, Hata Kodu:H022\n" + ex.Message);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int siparisNo = Convert.ToInt32(textBox1.Text);
                var siparis = entities.Siparis.Find(siparisNo);
                entities.Siparis.Remove(siparis);
                entities.SaveChanges();
                tumKayitlariListele();
            }
            catch(Exception ex)
            {
                MessageBox.Show("Veri Tabanı işlemleri sırasında hata oluştu, Hata Kodu:H020\n" + ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int musteriId = Convert.ToInt32(comboBox1.SelectedValue.ToString());
            var siparisler = (from siparis in entities.Siparis
                              where siparis.MusteriId == musteriId
                              select siparis).ToList();
            dataGridView1.DataSource = siparisler;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int urunId = Convert.ToInt32(comboBox2.SelectedValue.ToString());
            var siparisler = (from siparis in entities.Siparis
                              where siparis.UrunId == urunId
                              select siparis).ToList();
            dataGridView1.DataSource = siparisler;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DateTime date = dateTimePicker1.Value.Date;
            var siparisler=(from siparis in entities.Siparis
                            where siparis.Tarih==date
                            select siparis).ToList();
            dataGridView1.DataSource = siparisler;
        }
    }
}
