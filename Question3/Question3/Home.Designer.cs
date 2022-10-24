using System.Windows.Forms;

namespace Question3
{
    partial class Home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.downloadButton = new System.Windows.Forms.Button();
            this.numberPicker = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.browseButton = new System.Windows.Forms.Button();
            this.downloadLocationLabel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.fileURITextBox = new System.Windows.Forms.TextBox();
            this.addButton = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.URIListBox = new System.Windows.Forms.ListBox();
            this.removeButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numberPicker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // downloadButton
            // 
            this.downloadButton.Location = new System.Drawing.Point(471, 703);
            this.downloadButton.Name = "downloadButton";
            this.downloadButton.Size = new System.Drawing.Size(242, 49);
            this.downloadButton.TabIndex = 0;
            this.downloadButton.Text = "Download";
            this.downloadButton.UseVisualStyleBackColor = true;
            this.downloadButton.Click += new System.EventHandler(this.downloadButtonClick);
            // 
            // numberPicker
            // 
            this.numberPicker.Location = new System.Drawing.Point(705, 164);
            this.numberPicker.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numberPicker.Name = "numberPicker";
            this.numberPicker.Size = new System.Drawing.Size(146, 22);
            this.numberPicker.TabIndex = 1;
            this.numberPicker.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(700, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(167, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Number of Retires";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "Download Location";
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(17, 80);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(79, 34);
            this.browseButton.TabIndex = 6;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButtonClick);
            // 
            // downloadLocationLabel
            // 
            this.downloadLocationLabel.AutoSize = true;
            this.downloadLocationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.downloadLocationLabel.Location = new System.Drawing.Point(13, 45);
            this.downloadLocationLabel.MaximumSize = new System.Drawing.Size(1100, 0);
            this.downloadLocationLabel.Name = "downloadLocationLabel";
            this.downloadLocationLabel.Size = new System.Drawing.Size(0, 23);
            this.downloadLocationLabel.TabIndex = 5;
            this.downloadLocationLabel.UseCompatibleTextRendering = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 25);
            this.label4.TabIndex = 8;
            this.label4.Text = "File URI";
            // 
            // fileURITextBox
            // 
            this.fileURITextBox.Location = new System.Drawing.Point(18, 164);
            this.fileURITextBox.Name = "fileURITextBox";
            this.fileURITextBox.Size = new System.Drawing.Size(631, 22);
            this.fileURITextBox.TabIndex = 9;
            this.fileURITextBox.Validating += new System.ComponentModel.CancelEventHandler(this.fileTextBoxValidating);
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(18, 192);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(78, 34);
            this.addButton.TabIndex = 10;
            this.addButton.Text = "Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButtonClick);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // URIListBox
            // 
            this.URIListBox.FormattingEnabled = true;
            this.URIListBox.HorizontalScrollbar = true;
            this.URIListBox.ItemHeight = 16;
            this.URIListBox.Location = new System.Drawing.Point(18, 232);
            this.URIListBox.Name = "URIListBox";
            this.URIListBox.Size = new System.Drawing.Size(1083, 452);
            this.URIListBox.TabIndex = 11;
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(112, 192);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(78, 34);
            this.removeButton.TabIndex = 12;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1126, 764);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.URIListBox);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.fileURITextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.browseButton);
            this.Controls.Add(this.downloadLocationLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numberPicker);
            this.Controls.Add(this.downloadButton);
            this.MaximumSize = new System.Drawing.Size(1144, 811);
            this.MinimumSize = new System.Drawing.Size(1144, 811);
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.formClosedHandle);
            ((System.ComponentModel.ISupportInitialize)(this.numberPicker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button downloadButton;
        private System.Windows.Forms.NumericUpDown numberPicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Label downloadLocationLabel;
        private Label label4;
        private TextBox fileURITextBox;
        private Button addButton;
        private ErrorProvider errorProvider1;
        private ListBox URIListBox;
        private Button removeButton;
    }
}

