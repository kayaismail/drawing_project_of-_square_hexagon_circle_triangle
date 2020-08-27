using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace NYP
{
    class Kare : Sekil
    {
        override
        public void SekliCiz(Graphics Cizim)
        {
            Mx = Fx;
            My = Fy;
            Cizim.FillRectangle(new SolidBrush(Color.FromArgb(255,Renk.R,Renk.G,Renk.B)), Fx, Fy, Sx, Sy);
            CerceveCiz(Cizim);
        }
        override
        public void CerceveCiz(Graphics Cizim)
        {
            Cizim.FillRectangle(new SolidBrush(Color.FromArgb(ArkaPlanGorunurluk, 0, 0, 255)), Mx - 5, My - 5, Sx + 10, Sy + 10);
        }
        override
        public int SonKoseNoktaX()
        {
            return IlkKoseNoktaX() + Sx + 5; 
        }
        override
        public int SonKoseNoktaY()
        {
            return IlkKoseNoktaY() + Sy + 5;
        }
    }
}
