using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentInformation
{
    public partial class StudentInfo : Form
    {
        List<Student> students;
        ListViewItem viewItem;
        public StudentInfo()
        {
            InitializeComponent();
            //FillList();
        }

        public void FillList()
        {
            students = new List<Student>() { new Student() { Phone = "122222", Name = "Alshaimaa" } };
            foreach (Student item in students)
            {
                ListViewItem viewItem = new ListViewItem(item.Name);
                viewItem.SubItems.Add(item.Phone);
                viewItem.SubItems.Add(item.dateTime.ToString());

                lstvInfo.Items.Add(viewItem);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            students = new List<Student>() 
            { 
                new Student() { Name = txtName.Text, Phone = txtPhone.Text, dateTime = datebckerBirthD.Value } 
            };

            foreach (Student item in students)
            {
                viewItem = new ListViewItem(item.Name);
                viewItem.SubItems.Add(item.Phone);
                viewItem.SubItems.Add(item.dateTime.ToString());

                lstvInfo.Items.Add(viewItem);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            ListViewItem item = lstvInfo.SelectedItems[0];

            //fill the text boxes
            item.SubItems[0].Text = txtName.Text;
            item.SubItems[1].Text = txtPhone.Text;
            item.SubItems[2].Text = datebckerBirthD.Text;
        }

        private void lstvInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstvInfo.SelectedItems.Count == 0)
                return;

            ListViewItem item = lstvInfo.SelectedItems[0];

            //fill the text boxes
            txtName.Text = item.SubItems[0].Text;
            txtPhone.Text = item.SubItems[1].Text;
            datebckerBirthD.Text = item.SubItems[2].Text;
        }
    }
}
