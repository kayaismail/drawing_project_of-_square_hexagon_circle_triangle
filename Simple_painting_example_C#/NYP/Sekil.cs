using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NYP
{
    abstract class Sekil
    {
        public int Fx { get; set; }
        public int Fy { get; set; }
        public int Sx { get; set; }
        public int Sy { get; set; }
        public int Mx { get; set; }
        public int My { get; set; }
        public static int Index=0;
        public Color Renk { get; set; }
        public int ArkaPlanGorunurluk=0;
        public abstract void SekliCiz(Graphics Cizim);
        public virtual void BaslangicNoktasiKaydir(int GelenX)
        {
            Mx = Fx;
            My = Fy;
            Mx -= GelenX;
            My -= GelenX;
        }
        public virtual void CerceveCiz(Graphics Cizim)
        {
            Cizim.FillRectangle(new SolidBrush(Color.FromArgb(ArkaPlanGorunurluk, 0, 0, 255)), Mx-5, My-5, 2*Sx+10, 2*Sx+10);
        }
        public virtual int IlkKoseNoktaX()
        {
            return Mx - 5;
        }
        public virtual int IlkKoseNoktaY()
        {
            return My - 5;
        }
        public virtual int SonKoseNoktaX()
        {
            return IlkKoseNoktaX()+(2 * Sx + 5);
        }
        public virtual int SonKoseNoktaY()
        {
            return IlkKoseNoktaY()+(2 * Sx + 5);
        }
    }
}
