using System;
using Question3;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Question3Tests
{
    [TestClass]
    public class DownloadUtilityTest
    {
        [TestMethod]
        public void testFullPathName()
        {
            string downloadLocation = @"C:\Users\kuanlau3\Downloads";
            DownloadUtility downloadUtility = new DownloadUtility(3, downloadLocation, new List<string>() { "https://filesamples.com/samples/video/mov/sample_2560x1440.mov" });

            string actualFullPathName = downloadUtility.getFullPathFileName(downloadLocation, "https://filesamples.com/samples/video/mov/sample_2560x1440.mov");
            string expectedFullPathName = @"C:\Users\kuanlau3\Downloads\sample_2560x1440.mov";
            Console.WriteLine(actualFullPathName);
            Assert.AreEqual(expectedFullPathName, actualFullPathName);
        }

        [TestMethod]
        public void testSplitURIToDirectory()
        {
            string downloadLocation = @"C:\Users\kuanlau3\Downloads";
            DownloadUtility downloadUtility = new DownloadUtility(3, downloadLocation, new List<string>() { "sftp://demo@test.rebex.net/pub/example/mail-editor.png" });

            string actualFullPathName = downloadUtility.splitURIToDirectory("sftp://demo@test.rebex.net/pub/example/mail-editor.png");
            string expectedFullPathName = "/pub/example/mail-editor.png";
            Console.WriteLine(actualFullPathName);
            Assert.AreEqual(expectedFullPathName, actualFullPathName);
        }
    }
}
