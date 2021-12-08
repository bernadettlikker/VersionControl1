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
        Toy _nextToy;

        private iToyFactory toyFactory;

        public iToyFactory Factory
        {
            get { return toyFactory; }
            set 
            {
                toyFactory = value;
                DisplayNext();
            }
        }

        private void DisplayNext()
        {
            if (_nextToy != null)
                Controls.Remove(_nextToy);

            _nextToy = Factory.CreateNew();
            _nextToy.Top = label1.Top + label1.Height + 20;
            _nextToy.Left = label1.Left;
            Controls.Add(_nextToy);
        }

        public Form1()
        {
            InitializeComponent();
            Factory = new CarFactory();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void createTimer_Tick(object sender, EventArgs e)
        {
            Toy b = Factory.CreateNew();
            _toys.Add(b);
            b.Left = -b.Width;
            mainPanel.Controls.Add(b);
        }

        private void conveyorTimer_Tick(object sender, EventArgs e)
        {
            if (_toys.Count == 0) return;
            Toy lastBall = _toys[0];

            foreach (Toy item in _toys)
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

        private void btnCar_Click(object sender, EventArgs e)
        {
            Factory = new CarFactory();
        }

        private void btnBall_Click(object sender, EventArgs e)
        {
            Factory = new BallFactory();
        }
    }
}
