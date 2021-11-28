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
            int valasztott = Convert.ToInt32(listUsers.SelectedValue);
            User kivalasztott = (from i in context.Users
                                 where i.ID == valasztott
                                 select i).FirstOrDeafult();
            context.Users.Remove(kivalasztott);
            


            int lID = Convert.ToInt32(listUsers.SelectedValue);
            var od = from x in context.users
                     where x.ID == lID
                     select x;
            users.Remove(od.FirstOrDefault());
            


            listUsers.Items.Remove(listUsers.SelectedItem);
            ListBox.selectedItems = new ListBox.listUsers();
            selectedItems = listUsers.SelectedItems;

            if (listUsers.SelectedIndex != -1)
            {
                for (int i = selectedItems.Count - 1; i >= 0; i--)
                    listUsers.Items.Remove(selectedItems[i]);
            }
            else
                MessageBox.Show("Kérem jelölje ki melyik sort szeretné törölni");
        }
    }
}
