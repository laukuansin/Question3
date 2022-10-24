using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.IO;
using Renci.SshNet;

namespace Question3
{
    public class DownloadUtility
    {
        private int numOfRetries;
        private string downloadLocation;
        private List<string> URIList;

        public DownloadUtility(int numOfRetries, string downloadLocation, List<string> URIList)
        {
            this.numOfRetries = numOfRetries;
            this.downloadLocation = downloadLocation;
            this.URIList = URIList;
        }

        public void downloadURIList()
        {
            //start parallel download
            using (var finished = new CountdownEvent(1))
            {
                foreach (string URI in URIList)
                {
                    finished.AddCount();// Indicate that there is another work item.
                    ThreadPool.QueueUserWorkItem(
                        (state) =>
                        {
                            try
                            {
                                downloadFileThread(URI,numOfRetries);
                            }
                            finally
                            {
                                finished.Signal();//Signal that the work item is complete.
                            }
                        },null);
                }
                finished.Signal();// Signal that queueing is complete.
                finished.Wait();// Wait for all work items to complete.
            }
        }

        private void downloadFileThread(string URI,int numOfRetries)
        {
            int indexOfColon = URI.IndexOf(':');
            string appProtocol = URI.Substring(0, indexOfColon);
            
            if (appProtocol.Equals("sftp"))
            {
                downloadURI(downloadLocation, numOfRetries, URI,true); 
            }
            else
            {
                downloadURI(downloadLocation, numOfRetries, URI,false);
            }
        }

        private void downloadURI(string downloadLocation, int numOfRetries, string URI, Boolean isSFTP)
        {
            string downloadLocationWithFileName = getFullPathFileName(downloadLocation, URI);
            string URIOnlyDirectory = splitURIToDirectory(URI);
            WebClient webClient = new WebClient();

            while (numOfRetries > 0)
            {
                numOfRetries--;
                try
                {
                    if(isSFTP)
                    {
                        //for the public sftp server that I found request for the username and password
                        using (var sftp = new SftpClient("test.rebex.net", 22, "demo", "password"))
                        {
                            sftp.Connect();
                            using (Stream fileStream = File.Create(downloadLocationWithFileName))
                            {
                                sftp.DownloadFile(URIOnlyDirectory, fileStream);
                            }
                            sftp.Disconnect();
                        }
                    }
                    else
                    {
                        webClient.DownloadFile(URI, downloadLocationWithFileName);
                    }
                    
                    Console.WriteLine(downloadLocationWithFileName + ":" + "Download Successfully");

                    return;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine($"Failed to download {URI}, {numOfRetries} attempts remaining");
                    
                    //if the file exist and it catch the exception mean the file is download partially, then just remove it
                    if(File.Exists(downloadLocationWithFileName))
                    {
                        File.Delete(downloadLocationWithFileName);
                    }
                }
            }
        }
        
        public string getFullPathFileName(string downloadLocation,string URI)
        {
            string DecodeURI = WebUtility.UrlDecode(URI);
            int lastIndexOfSlash = DecodeURI.LastIndexOf("/");
            string fileName = DecodeURI.Substring(lastIndexOfSlash + 1);
            return string.Format(@"{0}\{1}", downloadLocation, fileName);
        }

        public string splitURIToDirectory(string URI)
        {
            // from "sftp://demo@test.rebex.net/pub/example/KeyGenerator.png" to "/pub/example/KeyGenerator.png"
            int indexOfColon = URIList[0].IndexOf(':');
            string URIWithoutProtocol = URI.Substring(indexOfColon + 3);
            string[] splitURI = URIWithoutProtocol.Split('/');
            splitURI[0] = "";
            return string.Join("/", splitURI);
        }
    }
}
