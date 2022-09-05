using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace entityproject
{
    public partial class FormUrunler : Form
    {
        public FormUrunler()
        {
            InitializeComponent();
        }
        dburunEntities db = new dburunEntities();
        void urunlistesi()
        {
            var urunler = from x in db.tblurunler
                          select new
                          {
                              x.UrunId,
                              x.urunAd,
                              x.stok,
                              x.Alisfiyat,
                              x.satisFiyat,
                              x.tblkatogori.Ad,
                          };
            dataGridView1.DataSource = urunler.ToList();
        }
        void temizle()
        {
            txtalis.Text = " ";
            txtid.Text = " ";
            txtsatis.Text = " ";
            txtstok.Text = " ";
            txturun.Text = " ";




        }
        private void btnlistele_Click(object sender, EventArgs e)
        {


        }

        private void FormUrunler_Load(object sender, EventArgs e)
        {
            urunlistesi();
            comboBox1.DataSource = db.tblkatogori.ToList();
            comboBox1.ValueMember = "Id";
            comboBox1.DisplayMember = "Ad";


        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            tblurunler t = new tblurunler
            {
                urunAd = txturun.Text,
                stok = short.Parse(txtstok.Text),
                Alisfiyat = decimal.Parse(txtalis.Text),
                satisFiyat = decimal.Parse(txtsatis.Text),
                Katogori = int.Parse(comboBox1.SelectedValue.ToString())
            };

            db.tblurunler.Add(t);
            db.SaveChanges();
            MessageBox.Show("Ürün başarılı bir şekilde kaydedildi");
            urunlistesi();
            temizle();

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            txtid.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txturun.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtstok.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtalis.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtsatis.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            //  comboBox1.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtid.Text != "")
            {
                int id = int.Parse(txtid.Text);
                var x = db.tblurunler.Find(id);
                db.tblurunler.Remove(x);
                db.SaveChanges();
                MessageBox.Show("Ürün Başarılı Bir şekilde silindi", "silme işlemi",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
                urunlistesi();


            }
            else
            {
                MessageBox.Show("Lütfen verileri listeledikten sonra bir satıra tıklayıp silmek istediğiniz kaydı seçiniz", "uyarı",
                   MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtid.Text);
            var x = db.tblurunler.Find(id);
            x.urunAd = txturun.Text;
            x.stok = short.Parse(txtstok.Text);
            x.Alisfiyat = decimal.Parse(txtalis.Text);
            x.satisFiyat = decimal.Parse(txtsatis.Text);
            x.Katogori = int.Parse(comboBox1.SelectedValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Verileriniz Başarılı Bir şekilde güncellendi", "Güncelleme Bilgisi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            urunlistesi();



        }
    }
}
