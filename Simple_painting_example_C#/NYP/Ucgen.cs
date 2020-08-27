using System;
using System.Drawing;

namespace NYP
{
    class Ucgen : Sekil
    {
        override
        public void SekliCiz(Graphics Cizim)
        {
            Point[] noktalar = new Point[] {new Point((Mx+(Mx+2*Sx))/2,My),new Point(Mx,My+2*Sx),new Point(Mx+2*Sx,My+2*Sx) };
            Cizim.FillPolygon(new SolidBrush(Color.FromArgb(255, Renk.R, Renk.G, Renk.B)), noktalar);
            CerceveCiz(Cizim);
        }
    }
}