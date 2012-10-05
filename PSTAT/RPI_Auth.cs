using System;
using System.Collections.Generic;
using System.Text;
using Renci.SshNet;

namespace PSTAT
{
    class RPI_Auth
    {
        private string username = "";
        private string password = "";
        public bool rpi_authent(string passedUsername, string passedPassword)
        {
            SshClient AuthClient = new SshClient("rcs.rpi.edu", passedUsername, passedPassword);

            try
            {
                AuthClient.Connect();
                AuthClient.Disconnect();
                AuthClient.Dispose();
                username = passedUsername;
                password = passedPassword;
                return true;
            }
            catch {
                return false;
            }
        }

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
