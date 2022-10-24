using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Question3;
using System.Windows.Forms;

namespace Question3Tests
{
    [TestClass]
    public class UIElementUnitTest
    {
        [TestMethod]
        public void testZeroOrNegativeNumberPicker()
        {
            Home home = new Home();
            string ErrorMessage = "";
            decimal emptyNumberPicker = 0;
            Boolean expected = false;

            Boolean actual = home.validateUIElement(emptyNumberPicker, "", 0,ref ErrorMessage);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void testDecimalPointNumberPicker()
        {
            Home home = new Home();
            string ErrorMessage = "";
            decimal decimalPointNumberPicker = (decimal)4.8;
            Boolean expected = false;

            Boolean actual = home.validateUIElement(decimalPointNumberPicker, "", 0, ref ErrorMessage);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void testEmptyDownloadLocation()
        {
            Home home = new Home();
            string ErrorMessage = "";
            string emptyDownloadLocation = "";
            Boolean expected = false;

            Boolean actual = home.validateUIElement(1, emptyDownloadLocation, 0, ref ErrorMessage);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void testInvalidDownloadLocation()
        {
            Home home = new Home();
            string ErrorMessage = "";
            string invalidDownloadLocation = "C:\abcdefg";
            Boolean expected = false;

            Boolean actual = home.validateUIElement(1,invalidDownloadLocation , 0, ref ErrorMessage);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void testEmptyURIList()
        {
            Home home = new Home();
            string ErrorMessage = "";
            int emptyURIList = 0;
            Boolean expected = false;

            Boolean actual = home.validateUIElement(1, "C:\\", emptyURIList, ref ErrorMessage);

            Assert.AreEqual(expected, actual);
        }
    }
}
