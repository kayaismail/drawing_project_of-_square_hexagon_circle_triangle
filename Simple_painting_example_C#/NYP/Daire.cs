using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NYP
{
    class Daire : Sekil
    {
        override
        public void SekliCiz(Graphics Cizim)
        {
            Cizim.FillEllipse(new SolidBrush(Color.FromArgb(255, Renk.R, Renk.G, Renk.B)), Mx, My, 2*Sx, 2*Sx);
            CerceveCiz(Cizim);
        }
    }
}
