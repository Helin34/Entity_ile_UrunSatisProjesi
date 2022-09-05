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
    public partial class istatistik : Form
    {
        public istatistik()
        {
            InitializeComponent();
        }
        dburunEntities db = new dburunEntities();


        private void istatistik_Load(object sender, EventArgs e)
        {
            DateTime bugun = DateTime.Today;
            lblmusterisayisi.Text = db.tblmusteri.Count().ToString();
            lblkategori.Text = db.tblkatogori.Count().ToString();
            lblurun.Text = db.tblurunler.Count().ToString();
            lblbeyaz.Text = db.tblurunler.Count(x=>x.Katogori==1).ToString();
            lbltoplam.Text = db.tblurunler.Sum(x => x.stok).ToString();
            adetti.Text = db.tblsatislar.Count(x => x.Tarih == bugun).ToString();
            tkasa.Text = db.tblsatislar.Sum(x => x.Toplam).ToString() + "$";
            kasa.Text = db.tblsatislar.Where(x => x.Tarih == bugun).Sum(y => y.Toplam).ToString() + "$";
            yuksek.Text = (from x in db.tblurunler
                           orderby x.satisFiyat descending
                           select x.urunAd).FirstOrDefault();
            tblendusuk.Text = (from x in db.tblurunler
                               orderby x.satisFiyat ascending
                               select x.urunAd).FirstOrDefault();
            lblenfazla.Text = (from x in db.tblurunler
                               orderby x.stok descending
                               select x.urunAd).FirstOrDefault();
            lblenaz.Text = (from x in db.tblurunler
                            orderby x.stok ascending
                            select x.urunAd).FirstOrDefault();


        }
    }
}
