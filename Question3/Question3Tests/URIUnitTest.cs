using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Question3;

namespace Question3Tests
{
    [TestClass]
    public class URIUnitTest
    {
        [TestMethod]
        public void testEmptyURI()
        {
            Home home = new Home();

            string ErrorMessage = "";
            string EmptyURI = "";
            Boolean expected = false;

            Boolean actual = home.validURI(EmptyURI, ref ErrorMessage);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void testURIWithoutColon()
        {
            Home home = new Home();

            string ErrorMessage = "";
            string URIWithoutColon = "http//filesamples.com/samples/video/mov/sample_2560x1440.mov";
            Boolean expected = false;

            Boolean actual = home.validURI(URIWithoutColon,ref ErrorMessage);

            Assert.AreEqual(expected,actual);
        }
        
        [TestMethod]
        public void testURIApplicationProtocol()
        {
            Home home = new Home();

            string ErrorMessage = "";
            string URIWithInvalidProtocol = "abcttp://filesamples.com/samples/video/mov/sample_2560x1440.mov";
            Boolean expected = false;

            Boolean actual = home.validURI(URIWithInvalidProtocol, ref ErrorMessage);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void testURIDoubleSplash()
        {
            Home home = new Home();

            string ErrorMessage = "";
            string URIWithOneSplash = "https:/filesamples.com/samples/video/mov/sample_2560x1440.mov";
            Boolean expected = false;

            Boolean actual = home.validURI(URIWithOneSplash, ref ErrorMessage);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void testURIDoubleSplashFollowByExtension()
        {
            Home home = new Home();

            string ErrorMessage = "";
            string URIWithDoubleSplashFollowByExtension = "https://.mov";
            Boolean expected = false;

            Boolean actual = home.validURI(URIWithDoubleSplashFollowByExtension, ref ErrorMessage);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void testURIDot()
        {
            Home home = new Home();

            string ErrorMessage = "";
            string URIWithoutDot = "https://filesamples";
            Boolean expected = false;

            Boolean actual = home.validURI(URIWithoutDot, ref ErrorMessage);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void testURIExtension()
        {
            Home home = new Home();

            string ErrorMessage = "";
            string URIWithoutDot = "https:/filesamples.com/samples/video/mov/sample_2560x1440.abcd";
            Boolean expected = false;

            Boolean actual = home.validURI(URIWithoutDot, ref ErrorMessage);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void testURIOnlyApplicationProtocol()
        {
            Home home = new Home();

            string ErrorMessage = "";
            string URIWithOnlyApplicationProtocol = "http://";
            Boolean expected = false;

            Boolean actual = home.validURI(URIWithOnlyApplicationProtocol, ref ErrorMessage);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void testURIOnlyApplicationProtocolFollowByDot()
        {
            Home home = new Home();

            string ErrorMessage = "";
            string URIWithOnlyApplicationProtocolFollowByDot = "http://.";
            Boolean expected = false;

            Boolean actual = home.validURI(URIWithOnlyApplicationProtocolFollowByDot, ref ErrorMessage);

            Assert.AreEqual(expected, actual);
        }
    }
}
