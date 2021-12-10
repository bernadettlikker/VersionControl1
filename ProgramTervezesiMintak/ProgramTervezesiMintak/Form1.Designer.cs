
namespace ProgramTervezesiMintak
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.createTimer = new System.Windows.Forms.Timer(this.components);
            this.conveyorTimer = new System.Windows.Forms.Timer(this.components);
            this.btnCar = new System.Windows.Forms.Button();
            this.btnBall = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnBallColor = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.Location = new System.Drawing.Point(2, 252);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(802, 202);
            this.mainPanel.TabIndex = 0;
            // 
            // createTimer
            // 
            this.createTimer.Enabled = true;
            this.createTimer.Interval = 3000;
            this.createTimer.Tick += new System.EventHandler(this.createTimer_Tick);
            // 
            // conveyorTimer
            // 
            this.conveyorTimer.Enabled = true;
            this.conveyorTimer.Interval = 10;
            this.conveyorTimer.Tick += new System.EventHandler(this.conveyorTimer_Tick);
            // 
            // btnCar
            // 
            this.btnCar.Location = new System.Drawing.Point(20, 20);
            this.btnCar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCar.Name = "btnCar";
            this.btnCar.Size = new System.Drawing.Size(112, 35);
            this.btnCar.TabIndex = 1;
            this.btnCar.Text = "Car";
            this.btnCar.UseVisualStyleBackColor = true;
            this.btnCar.Click += new System.EventHandler(this.btnCar_Click);
            // 
            // btnBall
            // 
            this.btnBall.Location = new System.Drawing.Point(166, 20);
            this.btnBall.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBall.Name = "btnBall";
            this.btnBall.Size = new System.Drawing.Size(112, 35);
            this.btnBall.TabIndex = 2;
            this.btnBall.Text = "Ball";
            this.btnBall.UseVisualStyleBackColor = true;
            this.btnBall.Click += new System.EventHandler(this.btnBall_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 144);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Coming next";
            // 
            // btnBallColor
            // 
            this.btnBallColor.BackColor = System.Drawing.Color.Red;
            this.btnBallColor.Location = new System.Drawing.Point(166, 79);
            this.btnBallColor.Name = "btnBallColor";
            this.btnBallColor.Size = new System.Drawing.Size(112, 33);
            this.btnBallColor.TabIndex = 4;
            this.btnBallColor.UseVisualStyleBackColor = false;
            this.btnBallColor.Click += new System.EventHandler(this.butnBallColor_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 449);
            this.Controls.Add(this.btnBallColor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBall);
            this.Controls.Add(this.btnCar);
            this.Controls.Add(this.mainPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Timer createTimer;
        private System.Windows.Forms.Timer conveyorTimer;
        private System.Windows.Forms.Button btnCar;
        private System.Windows.Forms.Button btnBall;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBallColor;
    }
}

