using ProgramTervezesiMintak.Abstractions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgramTervezesiMintak.Entities
{
    class Present : Toy
    {
        public SolidBrush RibbonBrush { get; private set; }
        public SolidBrush BoxBrush { get; private set; }

        public Present(Color ribbonkivantszin)
        {
            RibbonBrush = new SolidBrush(ribbonkivantszin);
        }

        public Present(Color boxkivantszin)
        {
            BoxBrush = new SolidBrush(boxkivantszin);
        }

        protected override void DrawImage(Graphics g)
        {
            g.FillEllipse(BallBrush, 0, 0, Width, Height);
        }


        protected override void DrawImage(Graphics g)
        {
           // g.FillEllipse(, 0, 0, Width, Height);
        }
    }
}
