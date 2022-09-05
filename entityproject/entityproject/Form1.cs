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
    public partial class btnsil : Form
    {
        public btnsil()
        {
            InitializeComponent();
        }
        dburunEntities db = new dburunEntities();
        
        private void btnlistele_Click(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = db.tblmusteri.ToList();
            var degerler = from x in db.tblmusteri
                           select new
                           {
                               x.MusteriID,
                               x.Ad,
                               x.Soyad,
                               x.Sehir,
                               x.Bakiye,

                           };
            dataGridView1.DataSource = degerler.ToList();
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            tblmusteri t = new tblmusteri();
            t.Ad = txtad.Text;
            t.Bakiye =decimal.Parse( txtbakiye.Text);
            t.Sehir = txtsehir.Text;
            t.Soyad = txtsoyad.Text;
            db.tblmusteri.Add(t);
            db.SaveChanges();
            MessageBox.Show("Yeni Müşteri Kaydı Yapıldı");

            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtid.Text);
            var x = db.tblmusteri.Find(id);
            db.tblmusteri.Remove(x);
            db.SaveChanges();
            MessageBox.Show("Müşteri sistemden silindi");

        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtid.Text);

            var x = db.tblmusteri.Find(id);
            x.Ad = txtad.Text;
            x.Soyad = txtsoyad.Text;
            x.Sehir = txtsehir.Text;
            x.Bakiye = decimal.Parse(txtbakiye.Text);
            db.SaveChanges();
            MessageBox.Show("Müşteri Bilgisi Güncellendi");

        }

        private void btnsil_Load(object sender, EventArgs e)
        {

        }
    }
}
