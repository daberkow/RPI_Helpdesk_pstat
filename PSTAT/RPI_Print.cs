using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PSTAT
{
    class RPI_Print
    {
        private string printer = "";
        private printJob[] STORAGE;
        public printJob[] get_prints_printer(string passedPrinter, RPI_Auth passedAuth)
        {
            printer = passedPrinter;
            List<printJob> returnData = new List<printJob>();
            string print_info = passedAuth.returnSSH("lpc stat " + passedPrinter);
            int startOfString = print_info.IndexOf("sends to") + 9;
            int endOfString = print_info.IndexOf(")", startOfString);
            if (print_info.Contains("unknown printer"))
                return returnData.ToArray();
            string printServer = print_info.Substring(startOfString, endOfString - startOfString);

            string returnedLog = passedAuth.returnSSHFrom("cat /var/adm/lpd/" + passedPrinter + "/log", printServer);

            string[] returnedBroken = returnedLog.Split('\n');
            returnedLog = "";
            printJob tempJob = new printJob();
            for (int i = 0; i < returnedBroken.Length; i++)
            {
                if (tempJob.JobStart == "")
                {
                    //look for start
                    if (returnedBroken[i].Contains("papif: Starting"))
                    {
                        if (returnedBroken[i].Contains("papif: Starting job"))
                            startOfString = returnedBroken[i].IndexOf(" for ") + 5;
                        else
                            startOfString = returnedBroken[i].IndexOf(" Starting ") + 10;
                        endOfString = returnedBroken[i].IndexOf(':', startOfString);
                        int secondEnd = returnedBroken[i].IndexOf('@', startOfString);
                        if (secondEnd != -1 && secondEnd < endOfString)
                            endOfString = secondEnd;
                        tempJob.JobUser = returnedBroken[i].Substring(startOfString, endOfString - startOfString).TrimStart();
                        startOfString = endOfString;
                        startOfString = returnedBroken[i].IndexOf(" at ",startOfString) + 4;
                        endOfString = returnedBroken[i].IndexOf(" on ", startOfString);
                        tempJob.JobStart = returnedBroken[i].Substring(startOfString, endOfString - startOfString);
                    }
                }
                else
                {
                    //look for end
                    if (returnedBroken[i].Contains("papif: Finished"))
                    {
                        startOfString = returnedBroken[i].IndexOf(" at ") + 4;
                        endOfString = returnedBroken[i].IndexOf("(", startOfString);
                        tempJob.JobStop = returnedBroken[i].Substring(startOfString, endOfString - startOfString);
                        startOfString = returnedBroken[i].IndexOf(" bytes, ") + 8;
                        endOfString = returnedBroken[i].IndexOf("pages", startOfString);
                        tempJob.JobPages = int.Parse(returnedBroken[i].Substring(startOfString, endOfString - startOfString).Trim());
                        returnData.Add(tempJob);
                        tempJob = new printJob();
                    }
                }
                if (i == returnedBroken.Length)
                {
                    returnData.Add(tempJob);
                }
            }
            STORAGE = returnData.ToArray();
            return STORAGE;
        }
        public printJob[] filter_printers(string passedFilter)
        {
            List<printJob> returnData = new List<printJob>();
            foreach (printJob JOB in STORAGE)
            {
                if (JOB.JobUser.Contains(passedFilter))
                {
                    returnData.Add(JOB);
                }
            }
            return returnData.ToArray();
        }
    }

    class printJob
    {
        private string username;
        private int pages;
        private string startTime;
        private string stopTime;

        public string JobUser
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }
        public int JobPages
        {
            get
            {
                return pages;
            }
            set
            {
                pages = value;
            }
        }
        public string JobStart
        {
            get
            {
                return startTime;
            }
            set
            {
                startTime = value;
            }
        }
        public string JobStop
        {
            get
            {
                return stopTime;
            }
            set
            {
                stopTime = value;
            }
        }

        public printJob()
        {
            username = "";
            pages = 0;
            startTime = "";
            stopTime = "";
        }
        public printJob(string passedUser, int passedPage, string passedStart, string passedStop)
        {
            username = passedUser;
            pages = passedPage;
            startTime = passedStart;
            stopTime = passedStop;
        }
    }
}
