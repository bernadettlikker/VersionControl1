using ProgramTervezesiMintak.Abstractions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgramTervezesiMintak.Entities
{
    public class Ball: Toy
    {
        
        protected override void DrawImage(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Red), 0, 0, Width, Height);
        }

        
    }
}
