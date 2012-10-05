using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Renci.SshNet;

namespace PSTAT
{
    public partial class Main_Form : Form
    {
        private RPI_Auth rpiCode;
        private RPI_Print PrintingCode;
        public Main_Form()
        {
            InitializeComponent();
            PrintGroup.Visible = false;
            setableUsername.Select();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            do_auth();
        }

        private void setablePassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                do_auth();
            }

        }

        private void do_auth()
        {
            rpiCode = new RPI_Auth();
            if (rpiCode.rpi_authent(setableUsername.Text, setablePassword.Text))
            {
                Login.Visible = false;
                PrintGroup.Visible = true;
            }
            else
            {
                MessageBox.Show("Bad Username/Password");
            }
        }

        private void setableSearchUser_Enter(object sender, EventArgs e)
        {
            setableSearchUser.Text = "";
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() != "")
            {
                update();
            }
        }

        private void update()
        {
            setableUpdated.Text = "Fetching";
            PrintingCode = new RPI_Print();
            printJob[] jobs = PrintingCode.get_prints_printer(comboBox1.Text, rpiCode);
            setableListBox.Items.Clear();
            foreach (printJob JOB in jobs)
            {
                string temp = "";
                if (JOB.JobUser.Length < 8)
                    temp += JOB.JobUser + "\t\t";
                else
                    temp += JOB.JobUser + "\t";

                temp += JOB.JobStart + " --> ";

                if (JOB.JobStop != "")
                    temp += JOB.JobStop;
                else
                    temp += "ACTIVE";

                if (temp.Length < 50)
                    temp += "\t\t";
                else
                    temp += "\t";

                if (JOB.JobPages < 0)
                    temp += "ERROR";
                else
                    temp += JOB.JobPages + " pages";
                setableListBox.Items.Add(temp);
            }
            setableUpdated.Text = DateTime.Now.TimeOfDay.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            update();
        }

        private void setableSearchUser_TextChanged(object sender, EventArgs e)
        {
            printJob[] jobs = PrintingCode.filter_printers(setableSearchUser.Text);
            setableListBox.Items.Clear();
            foreach (printJob JOB in jobs)
            {
                string temp = "";
                if (JOB.JobUser.Length < 8)
                    temp += JOB.JobUser + "\t\t";
                else
                    temp += JOB.JobUser + "\t";

                temp += JOB.JobStart + " --> ";

                if (JOB.JobStop != "")
                    temp += JOB.JobStop;
                else
                    temp += "ACTIVE";

                if (temp.Length < 50)
                    temp += "\t\t";
                else
                    temp += "\t";

                if (JOB.JobPages < 0)
                    temp += "ERROR";
                else
                    temp += JOB.JobPages + " pages";
                setableListBox.Items.Add(temp);
            }
        }

        private void comboBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                update();
        }
    }
}
