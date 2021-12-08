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
        List<Ball> _balls = new List<Ball>();
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
            _balls.Add(b);
            b.Left = -b.Width;
            mainPanel.Controls.Add(b);
        }

        private void conveyorTimer_Tick(object sender, EventArgs e)
        {
            if (_balls.Count == 0) return;
            Ball lastBall = _balls[0];

            foreach (Ball item in _balls)
            {
                item.MoveBall();
                if (item.Left > lastBall.Left) lastBall = item;
                
            }

            if (lastBall.Left > 1000)
            {
                _balls.Remove(lastBall);
                mainPanel.Controls.Remove(lastBall);
            }
        }
    }
}
