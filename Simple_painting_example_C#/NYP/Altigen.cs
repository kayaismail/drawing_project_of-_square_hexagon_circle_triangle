using System;
using System.Drawing;

namespace NYP
{
    internal class Altigen : Sekil
    {
        override
        public void SekliCiz(Graphics Cizim)
        {
            int t = 2*Sx / 3;
            Point[] noktalar = new Point[] {new Point(Mx+2*t+t/3,My),new Point(Mx+t-t/3,My),new Point(Mx,My+t+t/2),new Point(Mx+t-t/3,My+3*t),
                                            new Point(Mx+2*t+t/3,My+3*t),new Point(Mx+3*t,My+t+t/2)};
            Cizim.FillPolygon(new SolidBrush(Color.FromArgb(255, Renk.R, Renk.G, Renk.B)), noktalar);
            CerceveCiz(Cizim);
        }
    }
}