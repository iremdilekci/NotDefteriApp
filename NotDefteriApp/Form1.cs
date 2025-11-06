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

namespace NotDefteriApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void farklıKaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog(); // Yeni bir diyalog penceresi oluşturur.

            // Pencerede hangi dosya türlerinin gösterileceğini ayarlıyoruz.
            saveFileDialog.Filter = "Metin Dosyaları (*.txt)|*.txt|Tüm Dosyalar (*.*)|*.*";
            // "Metin Dosyaları" yazar, uzantı olarak *.txt'yi filtreler.

            saveFileDialog.Title = "Notu Farklı Kaydet"; // Pencerenin başlığını ayarlar.
            saveFileDialog.DefaultExt = "txt"; // Kullanıcı uzantı girmezse .txt olarak kaydeder.
            saveFileDialog.FileName = "Yeni Not"; // Varsayılan dosya adını ayarlar.


            if (saveFileDialog.ShowDialog() == DialogResult.OK) // Pencereyi göster ve kullanıcı OK (Kaydet) derse içeri gir.
            {

                try // Hata olasılığı olan kodlar bu bloğa alınır. (Örn: Disk doluysa hata verir)
                {
                    // saveFileDialog.FileName: Kullanıcının pencerede seçtiği tam dosya yolu.
                    // textBox1.Text: Formumuzdaki büyük metin kutusunun (notun) içeriği.

                    System.IO.File.WriteAllText(saveFileDialog.FileName, txtNotIcerigi.Text);

                    // Başarılı olursa kullanıcıya bilgi ver.
                    MessageBox.Show("Dosya başarıyla kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex) // Hata olursa bu blok çalışır.
                {
                    MessageBox.Show($"Dosya kaydedilirken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void açToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 1. OpenFileDialog (Açma Diyalog Kutusu) bileşenini oluştur
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // 2. Dosya filtrelerini ayarla
            openFileDialog.Filter = "Metin Dosyaları (*.txt)|*.txt|Tüm Dosyalar (*.*)|*.*";
            openFileDialog.Title = "Not Aç";

            // 3. Diyalog penceresini göster. Eğer kullanıcı Aç'a tıklarsa (OK):
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // 4. Seçilen dosyanın içeriğini oku (dosya yolu openFileDialog.FileName)
                    string dosyaIcerigi = System.IO.File.ReadAllText(openFileDialog.FileName);

                    // 5. Okunan içeriği not defteri alanına yükle.
                    txtNotIcerigi.Text = dosyaIcerigi;

                    MessageBox.Show("Dosya başarıyla açıldı.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    // 6. Bir hata oluşursa kullanıcıyı bilgilendir
                    MessageBox.Show($"Dosya açılırken bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void yeniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // txtNotIcerigi bileşenindeki tüm metni temizler.
            txtNotIcerigi.Text = "";
            // İstenirse, form başlığını "Yeni Not" olarak değiştirebilirsiniz:
            // this.Text = "Not Defteri - Yeni Not";
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Application.Exit() tüm uygulamayı kapatır.
            Application.Exit();
        }

        private void kesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // txtNotIcerigi bileşeninin hazır Cut() metodunu kullanırız.
            txtNotIcerigi.Cut();
        }

        private void kopyalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // txtNotIcerigi bileşeninin hazır Copy() metodunu kullanırız.
            txtNotIcerigi.Copy();
        }

        private void yapıştırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // txtNotIcerigi bileşeninin hazır Paste() metodunu kullanırız.
            txtNotIcerigi.Paste();
        }

        private void hakkındaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Oluşturduğumuz HakkindaFormu'nun yeni bir örneğini (instance) yaratırız.
            HakkindaFormu hakkinda = new HakkindaFormu();

            // Formu modal olarak gösteririz (kullanıcı bu formu kapatmadan ana forma geçemez).
            hakkinda.ShowDialog();
        }

        private void arkaPlanRengiDeğiştirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 1. ColorDialog nesnesini oluştur
            ColorDialog colorDialog = new ColorDialog();

            // 2. Diyaloğu göster ve kullanıcı OK'e basarsa
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                // 3. Seçilen rengi not alanının (txtNotIcerigi) arka planına uygula
                txtNotIcerigi.BackColor = colorDialog.Color;

                // İsteğe bağlı: Ana formun arka planını da değiştirebilirsiniz
                // this.BackColor = colorDialog.Color;
            }
        }

        private void metinRengiDeğiştirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // 1. ColorDialog nesnesini oluştur
            ColorDialog colorDialog = new ColorDialog();

            // 2. Diyaloğu göster ve kullanıcı OK'e basarsa
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                // 3. Seçilen rengi not alanındaki metnin ön plan (yazı) rengine uygula
                txtNotIcerigi.ForeColor = colorDialog.Color;
            }
        }
    }
}
