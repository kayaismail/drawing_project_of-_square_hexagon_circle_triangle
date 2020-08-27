using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace NYP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            
            CizildiMi = false;
            SadeceTiklandi = false;
            Sekiller = new Sekil[100];
            KareMi = false;
            TiklananNesneIndex = 0;
            OncekiObje = null;
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            DoubleBuffered = true;
            panelCizim.MouseUp += PaneldenCekildi;
            panelCizim.MouseDown += PaneleBasildi;
        }

        object OncekiObje;
        bool CizildiMi;
        bool SadeceTiklandi;
        Sekil sekil;
        Color SecilenRenk;
        Sekil[] Sekiller;
        bool KareMi;
        int TiklananNesneIndex;

        private void PaneleBasildi(object sender, MouseEventArgs e)
        {
            if (!SadeceTiklandi)
            {
                if (sekil != null && SecilenRenk.A != 0)
                {
                    SekilOgeleriSecim(pnlSekiller, OncekiObje);
                    sekil.Renk = SecilenRenk;
                    NesneyiSekillereAta(e);
                    panelCizim.MouseMove += PaneldeGeziniyor;
                    //  MessageBox.Show("Test");
                }
                else
                {

                }
            }else
            {
                panelTiklama(sender, e);
            }
        }
        private void Sekil_Secimi_Click(object sender, EventArgs e)
        {
            if (SadeceTiklandi)
            {
                pnlCizimdeSecim_Click(sender, e);
            }
            SekilOgeleriSecim(pnlSekiller,sender);
        }
        private void SekilOgeleriSecim(Control parent,object sender)
        {
            OncekiObje = sender;
            //MessageBox.Show(parent.Controls.Count.ToString());
            foreach (Control child in parent.Controls)
            {
                if (child == sender)
                {
                //    MessageBox.Show("Test");
                    CizildiMi = true;
                    child.Refresh();
                    if (child.Name == "pnlUcgen")
                    {
                        sekil = new Ucgen();
                    }else if (child.Name=="pnlDaire")
                    {
                        sekil = new Daire();
                    }else if (child.Name=="pnlKare")
                    {
                        sekil = new Kare();
                    }else if (child.Name=="pnlAltigen")
                    {
                        sekil = new Altigen();
                    }
                    sekil.Renk = Color.FromArgb(0,0,0,0);
                    CizildiMi = false;
                }else
                {
                    child.Refresh();
                }
            }
        }
        private void pnlKare_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(Color.Red), 3, 3, 54, 54);
            SecilenSekil(sender,e);
       }
        private void SecilenSekil(object sender,PaintEventArgs e)
        {
            if (CizildiMi)
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(60, 223, 0, 200)), 0, 0, 60, 60);
            }
            else
            {
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(0, 223, 0, 200)), 0, 0, 60, 60);
            }
        }
        private void pnlDaire_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillEllipse(new SolidBrush(Color.Aqua), 3, 3, 54, 54);
            SecilenSekil(sender,e);
            // e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(Gorunurluk, 223, 0, 200)), 0, 0, 60, 60);
        }
        private void pnlUcgen_Paint(object sender, PaintEventArgs e)
        {
            Point[] noktalar = new Point[]
            {
                new Point(30,3),
                new Point(3,54),
                new Point(54,54)
            };
            e.Graphics.FillPolygon(new SolidBrush(Color.Red), noktalar);
            SecilenSekil(sender,e);
            //e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(Gorunurluk, 223, 0, 200)), 0, 0, 60, 60);
        }
        private void pnlAltigen_Paint(object sender, PaintEventArgs e)
        {
            int t = 60 / 3;
            Point[] noktalar = new Point[]
            {
               new Point(0+2*t+t/3,3),
               new Point(-2+0+t-t/3,3),
               new Point(0,0+t+t/2),
               new Point(0+t-t/3,0+3*t-5),
               new Point(0+2*t+t/3,0+3*t-5),
               new Point(0+3*t-2,0+t+t/2)
            };
            e.Graphics.FillPolygon(new SolidBrush(Color.Green), noktalar);
            SecilenSekil(sender,e);
            //e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(Gorunurluk, 223, 0, 200)), 0, 0, 60, 60);
        }
        private void Renk_Secimi_Click(object sender, EventArgs e)
        {
            Panel Gecici = (Panel)sender;
            Graphics cizim = pnlRenkler.CreateGraphics();
            cizim.Clear(Color.Aqua);
            pnlRenkler.BackColor = Color.Aqua;
            cizim.FillRectangle(new SolidBrush(Color.FromArgb(100, 223, 0, 200)), Gecici.Location.X-3, Gecici.Location.Y-3, 46, 46);
            SecilenRenk = Gecici.BackColor;
            if (SadeceTiklandi)
            {
                Sekiller[TiklananNesneIndex].Renk = SecilenRenk;
                panelCizim.Invalidate();
            }
        }
        private void panelTiklama(object sender, MouseEventArgs e)
        {
            if(Sekiller[TiklananNesneIndex]!=null)
                Sekiller[TiklananNesneIndex].ArkaPlanGorunurluk = 0;
            panelCizim.Invalidate();
            
             for (int i = 0; i <= Sekil.Index - 1; i++)
                {
                    if (e.X > Sekiller[i].IlkKoseNoktaX() && e.Y > Sekiller[i].IlkKoseNoktaY())
                    {

                        if (e.X < Sekiller[i].SonKoseNoktaX() && e.Y < Sekiller[i].SonKoseNoktaY())
                        {
                            Sekiller[i].ArkaPlanGorunurluk = 50;
                            TiklananNesneIndex = i;
                            panelCizim.Invalidate();
                            return;
                        }
                    }
                }
        }
        private void PaneldeGeziniyor(object sender, MouseEventArgs e)
        {
            if(e.X<510&&e.Y<500)
            if (!(e.X - sekil.Fx < 0 || e.Y - sekil.Fy < 0)) //Boyutun Sifirdan Kucuk Olup Olmama Kontrolu
            {
                if (sekil.Mx >= 0 && sekil.My >= 0 && sekil.Fx+sekil.Sx < 510 && sekil.Fy+sekil.Sx < 500) //Panel Koseleri Kontrolu
                {
                    sekil.Sx = e.X - sekil.Fx;
                    sekil.Sy = e.Y - sekil.Fy;
                        if (!KareMi)
                        {
                            sekil.BaslangicNoktasiKaydir(e.X - sekil.Fx);
                           // sekil.Sy = 0;
                        }
                    panelCizim.Invalidate();
                }
            }
        }
        private void PaneldenCekildi(object sender, MouseEventArgs e)
        {
            // MessageBox.Show("Test");
            panelCizim.MouseMove -= PaneldeGeziniyor;
            NesneKontrolu(e);
        }
        private void NesneKontrolu(MouseEventArgs e)
        {
            if(sekil!=null)
                if (sekil.Fx == e.X)
                {
                    Sekil.Index--;
                    Sekiller[Sekil.Index] = null;
                    

                }
        }
        private void NesneyiSekillereAta(MouseEventArgs e)
        {
            sekil.Fx = e.X;
            sekil.Fy = e.Y;
            Sekiller[Sekil.Index] = sekil;
            Sekil.Index++;
           

        }
        private void panelCizim_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < Sekil.Index; i++)
            {
                if(Sekiller[i]!=null)
                    Sekiller[i].SekliCiz(e.Graphics);
            }
        }

        private void pnlCizimdeSecim_Click(object sender, EventArgs ev)
        {

            Graphics e = pnlCizimdeSecim.CreateGraphics();
            SadeceTiklandi = !SadeceTiklandi;
            if (SadeceTiklandi)
            {
                e.FillRectangle(new SolidBrush(Color.FromArgb(60, 223, 0, 200)), 0, 0, 60, 60);
            }
            else
            {
                e.Clear(Color.White);

                pnlCizimdeSecim.BackgroundImage = Image.FromFile("../../Resources/fare.PNG");
            }
        }

        private void pnlCopKutusu_Click(object sender, EventArgs e)
        {
         
            if (TiklananNesneIndex >= 0)
            {
                if (Sekil.Index > 0)
                {
                    Sekiller[TiklananNesneIndex] = Sekiller[Sekil.Index - 1];
                    Sekiller[Sekil.Index - 1] = null;
                    Sekil.Index--;
                }
            }
            panelCizim.Invalidate();
        }

        private void pnlDosyayaKaydet_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Text Dosyasi |*.txt| Tum Dosyalar |*.*";
            sfd.AddExtension = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(sfd.FileName);
                string[] Gelen = null;
                for (int i = 0; i < Sekil.Index; i++)
                {
                    Gelen = Sekiller[i].ToString().Split('.');
                    sw.WriteLine(Gelen[1] + "|" + Sekiller[i].Renk.Name + "|" + Sekiller[i].Fx + "|" + Sekiller[i].Fy + "|" + Sekiller[i].Mx + "|" + Sekiller[i].My + "|" + Sekiller[i].Sx + "|"+Sekiller[i].Sy);
                }
                sw.Close();
            }
        }
        private void pnlDosyadanAc_Click(object sender, EventArgs e)
        {
            Sekil.Index = 0;
            string OkunanSatir;
            Sekiller = new Sekil[100];
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text Dosyasi |*.txt| Tum Dosyalar |*.*";
            ofd.FilterIndex = 1;
            ofd.Title = "Dosyayi Seciniz";
            if (ofd.ShowDialog() == DialogResult.OK)
            {

                StreamReader sr = new StreamReader(ofd.FileName);
                while ((OkunanSatir = sr.ReadLine()) != null)
                {
                    string[] GelenSatirDizisi = OkunanSatir.Split('|');
                    if (GelenSatirDizisi[0] == "Kare")
                    {
                        sekil = new Kare();
                        Sekiller[Sekil.Index] = sekil;
                    }
                    else if (GelenSatirDizisi[0] == "Ucgen")
                    {
                        Sekiller[Sekil.Index] = new Ucgen();
                    }
                    else if (GelenSatirDizisi[0] == "Altigen")
                    {
                        Sekiller[Sekil.Index] = new Altigen();
                    }
                    else if (GelenSatirDizisi[0] == "Daire")
                    {
                        Sekiller[Sekil.Index] = new Daire();
                    }
                    Sekiller[Sekil.Index].Renk = System.Drawing.Color.FromName(GelenSatirDizisi[1]);
                    Sekiller[Sekil.Index].Fx = Convert.ToInt32(GelenSatirDizisi[2]);
                    Sekiller[Sekil.Index].Fy = Convert.ToInt32(GelenSatirDizisi[3]);
                    Sekiller[Sekil.Index].Mx = Convert.ToInt32(GelenSatirDizisi[4]);
                    Sekiller[Sekil.Index].My = Convert.ToInt32(GelenSatirDizisi[5]);
                    Sekiller[Sekil.Index].Sx = Convert.ToInt32(GelenSatirDizisi[6]);
                    Sekiller[Sekil.Index].Sy = Convert.ToInt32(GelenSatirDizisi[7]);
                    Sekil.Index++;
                }
                panelCizim.Invalidate();
                sr.Close();
            }
        }
    }
}