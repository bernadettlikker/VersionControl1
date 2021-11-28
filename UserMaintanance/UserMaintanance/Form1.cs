using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserMaintanance.Entities;

namespace UserMaintanance
{
    public partial class From1 : Form
    {
        BindingList<User> users = new BindingList<User>();
        

        public From1()
        {
            InitializeComponent();
            btnAdd.Text = Resource.Add;
            lblFullName.Text = Resource.FullName;
            btnFajlba.Text = Resource.Fajlbairas;
            btnDelete.Text = Resource.Delete;

            listUsers.DataSource = users;
            listUsers.ValueMember = "ID";
            listUsers.DisplayMember = "FullName";

            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            User u = new User();
            //u.LastName = txtLastName.Text;
            //u.FirstName = txtFirstName.Text;
            u.FullName = txtFullName.Text;
            users.Add(u);
        }

        private void btnFajlba_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(sfd.FileName))
                {
                    foreach (User item in users)
                    {
                        sw.WriteLine(item.ID + ";" + item.FullName);
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            User kivalasztott = (User)listUsers.SelectedItem;
            users.Remove(kivalasztott);
                        
        }
    }
}
