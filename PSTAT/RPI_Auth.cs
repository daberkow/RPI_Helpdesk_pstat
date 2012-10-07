/*  RPI helpdesk PSTAT
 *  Dan Berkowitz October 2012
 *  Authentication code for RPI
 */

using System;
using System.Collections.Generic;
using System.Text;
using Renci.SshNet;

namespace PSTAT
{
    class RPI_Auth
    {
        private string username = ""; //private store for username and password
        private string password = "";

        //Authenticate users
        public bool rpi_authent(string passedUsername, string passedPassword)
        {
            SshClient AuthClient = new SshClient("rcs.rpi.edu", passedUsername, passedPassword);//Using Renci

            try
            {
                AuthClient.Connect();       //try to connect
                AuthClient.Disconnect();    //If that worked disconnect
                AuthClient.Dispose();       //Clean up connection
                username = passedUsername;  //Store data in private collection because it worked
                password = passedPassword;
                return true;
            }
            catch {
                return false;               //This failed, either server is bad, but thats public so username and password are bad
            }
        }

        //Use stored infor to run comamnds on a server
        public string returnSSH(string passedCommand)
        {
            SshClient AuthClient = new SshClient("rcs.rpi.edu", username, password);

            try
            {
                AuthClient.Connect();
                SshCommand RunCommand = AuthClient.RunCommand(passedCommand);
                AuthClient.Disconnect();
                return RunCommand.Result;
            }
            catch
            {
                return "";
            }
        }

        //Same as returnSSH, but specific a specific server isntead of a the generic RPI server
        public string returnSSHFrom(string passedCommand, string passedServer)
        {
            SshClient AuthClient = new SshClient(passedServer, username, password);

            try
            {
                AuthClient.Connect();
                SshCommand RunCommand = AuthClient.RunCommand(passedCommand);
                AuthClient.Disconnect();
                return RunCommand.Result;
            }
            catch
            {
                return "";
            }
        }
    }
}
