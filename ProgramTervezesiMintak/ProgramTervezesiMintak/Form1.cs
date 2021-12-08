using ProgramTervezesiMintak.Abstractions;
using ProgramTervezesiMintak.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgramTervezesiMintak
{
    public partial class Form1 : Form
    {
        List<Toy> _toys = new List<Toy>();
        private BallFactory ballFactory;

        public BallFactory Factory
        {
            get { return ballFactory; }
            set { ballFactory = value; }
        }

        public Form1()
        {
            InitializeComponent();
            Factory = new BallFactory();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void createTimer_Tick(object sender, EventArgs e)
        {
            Ball b = Factory.CreateNew();
            _toys.Add(b);
            b.Left = -b.Width;
            mainPanel.Controls.Add(b);
        }

        private void conveyorTimer_Tick(object sender, EventArgs e)
        {
            if (_toys.Count == 0) return;
            Toy lastBall = _toys[0];

            foreach (Ball item in _toys)
            {
                item.MoveToy();
                if (item.Left > lastBall.Left) lastBall = item;
                
            }

            if (lastBall.Left > 1000)
            {
                _toys.Remove(lastBall);
                mainPanel.Controls.Remove(lastBall);
            }
        }
    }
}
