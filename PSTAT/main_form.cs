using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Renci.SshNet; //The ssh library in use

namespace PSTAT
{
    public partial class Main_Form : Form
    {
        //Start code for RPI authentication as well as printing
        private RPI_Auth rpiCode;
        private RPI_Print PrintingCode;

        //Startup main window
        public Main_Form()
        {
            InitializeComponent();
            PrintGroup.Visible = false; //hide these options till after authentication
            setableUsername.Select();
        }

        /*
         *  Check that the user has access to RPI servers, but this isnt checking if they actually have pstat access
         */
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
        
        /*
         * Go get printer logs 
         */
        private void update()
        {
            setableUpdated.Text = "Fetching";
            doFetchUpdate(comboBox1.Text);
            setableUpdated.Text = DateTime.Now.TimeOfDay.ToString();
        }

        /*
         *  This actually goes and gets logs, then parses them
         */
        private void doFetchUpdate(string passed_text)
        {
            PrintingCode = new RPI_Print();
            printJob[] jobs = PrintingCode.get_prints_printer(passed_text, rpiCode);
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

        #region Actions
        /*
         * 
         */
        private void loginbutton_click(object sender, EventArgs e)
        {
            do_auth(); // When the user clicks login do the login
        }

        private void setablePassword_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                do_auth(); // if the user hits enter while typing password start authentcation
            }

        }

        private void setableSearchUser_Enter(object sender, EventArgs e)
        {
            setableSearchUser.Text = "";//When the field is clicked, empty the box
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem.ToString() != "")
            {
                update(); // when the priner box is not blank, go get printer log
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            update();
        }

        private void setableSearchUser_TextChanged(object sender, EventArgs e)
        {
            doFetchUpdate(setableSearchUser.Text);
        }

        private void comboBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                update(); // if enter is hit then use that printer name
        }
        #endregion
    }
}
