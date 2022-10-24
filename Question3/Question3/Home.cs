using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Question3
{
    public partial class Home : Form
    {
        private string filePath;
        private Extensions extensions;
        public Home()
        {
            InitializeComponent();
            initializeConfiguration();
            initializeExtensionList();
        }

        public Boolean validateUIElement(Decimal numOfRetries,string downloadLocation,int URIListCount,ref string errorMessage)
        {
            //validation for number of retries
            if (numOfRetries <= 0)
            {
                errorMessage = "Number of Retries cannot be less than 1!";
                return false;
            }
            if (numOfRetries % 1 != 0)
            {
                errorMessage = "Number of Retries cannot be decimal point!";
                return false;
            }

            //validation for download location
            if (string.IsNullOrEmpty(downloadLocation))
            {
                errorMessage = "Download location cannot be empty!";
                return false;
            }
            if (!Directory.Exists(downloadLocation))
            {
                errorMessage = "Download location does not exist. Please check again.";
                return false;
            }

            if(URIListCount<1)
            {
                errorMessage = "Please add URI before start download";
                return false;
            }

            return true;
        }
        private void downloadButtonClick(object sender, EventArgs e)
        {
            string errorMessage = "";
            if(!validateUIElement(numberPicker.Value,downloadLocationLabel.Text,URIListBox.Items.Count,ref errorMessage))
            {
                ErrorMessageBox.popOutDialog(errorMessage);
                return;
            }
            
            Console.WriteLine("---Start Execute---");
            using (ProgressBar form = new ProgressBar(callDownloadUtility))
            {
                form.ShowDialog(this);
            }
            Console.WriteLine("---End Execute---");
            MessageBox.Show("Task Execute finish.");
            URIListBox.Items.Clear();
        }

        private void callDownloadUtility()
        {
            //validation for URI list box
            List<string> URIList = new List<string>(URIListBox.Items.Cast<string>());
            
            DownloadUtility downloadUtility = new DownloadUtility(Convert.ToInt32(numberPicker.Value), downloadLocationLabel.Text, URIList);
            downloadUtility.downloadURIList();
        }

        private void browseButtonClick(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
            if (folderBrowser.ShowDialog() == DialogResult.OK)
            {
                downloadLocationLabel.Text = folderBrowser.SelectedPath;
            }
        }

        private void initializeConfiguration()
        {
            //Read file
            filePath = AppDomain.CurrentDomain.BaseDirectory + "/ConfigurationData.txt";
            if(File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);

                if(lines[0]==null)
                {
                    ErrorMessageBox.popOutDialog("Number of Retries is empty! It will be assigned to default value.");
                    numberPicker.Value = 1;
                }
                else
                {
                    numberPicker.Value = Int32.Parse(lines[0]);
                }
                if(lines[1]==null)
                {
                    ErrorMessageBox.popOutDialog("Download location is empty! It will be assigned to default value.");
                    downloadLocationLabel.Text = "C:\\";
                }
                else
                {
                    downloadLocationLabel.Text = lines[1];
                }
            }
            else
            {
                //Assign default value in the first time run
                numberPicker.Value = 1;
                downloadLocationLabel.Text = "C:\\";
            }
        }

        public void formClosedHandle(object sender, FormClosedEventArgs e) 
        {
            //write file
            string[] lines = new string[2];
            lines[0] = Math.Ceiling(numberPicker.Value).ToString();
            lines[1] = downloadLocationLabel.Text;

            File.WriteAllLines(filePath, lines);
        }

        private void addButtonClick(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                URIListBox.Items.Add(fileURITextBox.Text);
                fileURITextBox.Clear();
            }
        }

        private void fileTextBoxValidating(object sender, CancelEventArgs e)
        {
            string errorMessage = "";
            //validation for File URI text box
            if(string.IsNullOrEmpty(fileURITextBox.Text))
            {
                e.Cancel = true;
                fileURITextBox.Focus();
                errorProvider1.SetError(fileURITextBox, "File URI should not be left blank!");
            }
            else if (!validURI(fileURITextBox.Text,ref errorMessage))
            {
                e.Cancel = true;
                fileURITextBox.Focus();
                errorProvider1.SetError(fileURITextBox, errorMessage);
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(fileURITextBox, "");
            }
        }

        private void initializeExtensionList()
        {
            extensions = new Extensions();
            extensions.addExtension(".bmp");extensions.addExtension(".dib"); extensions.addExtension(".gif");
            extensions.addExtension(".ico");extensions.addExtension(".jpg"); extensions.addExtension(".jpeg");
            extensions.addExtension(".png"); extensions.addExtension(".svg"); extensions.addExtension(".tiff");
            extensions.addExtension(".tif"); extensions.addExtension(".webp"); extensions.addExtension(".doc");
            extensions.addExtension(".docx"); extensions.addExtension(".odp"); extensions.addExtension(".ods");
            extensions.addExtension(".odt"); extensions.addExtension(".pdf"); extensions.addExtension(".ppt");
            extensions.addExtension(".pptx"); extensions.addExtension(".txt"); extensions.addExtension(".xlsx");
            extensions.addExtension(".xls"); extensions.addExtension(".3pg"); extensions.addExtension(".3g2");
            extensions.addExtension(".avi"); extensions.addExtension(".mpeg"); extensions.addExtension(".ogv");
            extensions.addExtension(".mid"); extensions.addExtension(".aac"); extensions.addExtension(".midi");
            extensions.addExtension(".mp3"); extensions.addExtension(".oga"); extensions.addExtension(".wav");
            extensions.addExtension(".weba"); extensions.addExtension(".css"); extensions.addExtension(".html");
            extensions.addExtension(".htm"); extensions.addExtension(".js"); extensions.addExtension(".xml");
            extensions.addExtension(".json"); extensions.addExtension(".xhtml"); extensions.addExtension(".jpeg");
            extensions.addExtension(".gz"); extensions.addExtension(".tar"); extensions.addExtension(".zip");
            extensions.addExtension(".bin"); extensions.addExtension(".epub"); extensions.addExtension(".swf");
            extensions.addExtension(".mov"); extensions.addExtension(".mp4"); extensions.addExtension(".mp3");
            extensions.addExtension(".ogg"); extensions.addExtension(".webm"); extensions.addExtension(".bat");
            extensions.addExtension(".rtf"); extensions.addExtension(".tar"); extensions.addExtension(".zip");
            extensions.addExtension(".bin"); extensions.addExtension(".csv"); extensions.addExtension(".c");
            extensions.addExtension(".rm"); extensions.addExtension(".class"); extensions.addExtension(".cpp");
            extensions.addExtension(".cs"); extensions.addExtension(".go"); extensions.addExtension(".h");
            extensions.addExtension(".java"); extensions.addExtension(".kml"); extensions.addExtension(".php");
            extensions.addExtension(".pl"); extensions.addExtension(".py"); extensions.addExtension(".rb");
            extensions.addExtension(".sh"); extensions.addExtension(".sql"); extensions.addExtension(".swift");
            extensions.addExtension(".vb"); extensions.addExtension(".yaml"); extensions.addExtension(".rar");
            extensions.addExtension(".7z"); extensions.addExtension(".gzip"); extensions.addExtension(".bzip2");
        }

        public Boolean validURI(string URI,ref string errorMessage)
        {
            Regex regex = new Regex(@"^(http|https|ftp|sftp)(:\/\/)([a-z])(.*)");
            Match match = regex.Match(URI);
            if (match.Success)
            {
                //get the URI extension
                int indexOfLastDot = URI.LastIndexOf('.');
                if (indexOfLastDot == -1)
                {
                    errorMessage = "No dot found. Invalid URI!";
                    return false;
                }
                string URIExtension = URI.Substring(indexOfLastDot);

                //validate extension in URI
                if (!extensions.getExtensionList().Contains(URIExtension))
                {
                    errorMessage = "Invalid extension.";
                    return false;
                }

                return true;
            }
            else
            {
                errorMessage = "Invalid URI format.";
                return false;
            }

        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            
            var count = URIListBox.SelectedItems.Count;
            if (count == 0)
            {
                ErrorMessageBox.popOutDialog("Please select an URI before clicking Remove button");
                return;
            }
            
            var selectedItem = URIListBox.Items[URIListBox.SelectedIndex];
            URIListBox.Items.Remove(selectedItem);
                
        }
    }
}
