using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjeSonHali
{
    class Daire : Sekil
    {
        public override void SekliCiz(Graphics Cizim)
        {
            Cizim.FillEllipse(new SolidBrush(Color.Blue), Mx, My, 2*Sx, 2*Sx);
            CerceveCiz(Cizim);
        }
    }
}
