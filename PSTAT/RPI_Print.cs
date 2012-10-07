/*  RPI helpdesk PSTAT
 *  Dan Berkowitz October 2012
 *  This code is for printer handling
 */

using System;
using System.Collections.Generic;
using System.Text;

namespace PSTAT
{
    class RPI_Print
    {
        private string printer = ""; //The printer name that is being worked on
        private printJob[] STORAGE;  //This stores all the printer data

        /*
         *  This code goes and returns a arrray of print jobs, give it a printer name and the authorication object
         */
        public printJob[] get_prints_printer(string passedPrinter, RPI_Auth passedAuth)
        {
            printer = passedPrinter; // store the data in hte private object
            List<printJob> returnData = new List<printJob>(); // we start with a list then transfer to a array
            string print_info = passedAuth.returnSSH("lpc stat " + passedPrinter); // check which server handles that printer
            int startOfString = print_info.IndexOf("sends to") + 9;
            int endOfString = print_info.IndexOf(")", startOfString);
            if (print_info.Contains("unknown printer"))
                return returnData.ToArray();
            string printServer = print_info.Substring(startOfString, endOfString - startOfString);

            //go and get the log for that printer from the server
            string returnedLog = passedAuth.returnSSHFrom("cat /var/adm/lpd/" + passedPrinter + "/log", printServer);

            //split up the log by line
            string[] returnedBroken = returnedLog.Split('\n');

            //null out the string, for the tiny memory savings!
            returnedLog = "";

            //Create a temporary job that will be our object to add to the array
            printJob tempJob = new printJob();
            //go line by line through log
            for (int i = 0; i < returnedBroken.Length; i++)
            {
                if (tempJob.JobStart == "") //are we finding the start of a job or the end
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
                if (i == returnedBroken.Length) // if we are at the end, and the job hasnt finished
                {
                    returnData.Add(tempJob);
                }
            }
            STORAGE = returnData.ToArray();
            return STORAGE; // return the array of data
        }

        /*
         *  Filter the stored printer information with a filter that is passed in
         */
        public printJob[] filter_printers(string passedFilter)
        {
            List<printJob> returnData = new List<printJob>();
            foreach (printJob JOB in STORAGE)
            {
                if (JOB.JobUser.Contains(passedFilter)) //Contains isnt most effiecnt way of doing this, but for our use its ok
                {
                    returnData.Add(JOB);
                }
            }
            return returnData.ToArray();
        }
    }

    /*
     *   Setup the pritner job type
     */
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
