namespace ImageScraper
{
    partial class frmMain
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
            this.txtOutput = new System.Windows.Forms.RichTextBox();
            this.pbPrimary = new System.Windows.Forms.ProgressBar();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClearConsole = new System.Windows.Forms.Button();
            this.tabFunctions = new System.Windows.Forms.TabControl();
            this.tabDownload = new System.Windows.Forms.TabPage();
            this.btnUrlClear = new System.Windows.Forms.Button();
            this.btnTestDownload = new System.Windows.Forms.Button();
            this.btnStartDownload = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radSearchBoth = new System.Windows.Forms.RadioButton();
            this.radSearchA = new System.Windows.Forms.RadioButton();
            this.radSearchImg = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.tabDatabase = new System.Windows.Forms.TabPage();
            this.btnCreateDb = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.tabTools = new System.Windows.Forms.TabPage();
            this.numImagesPerFolder = new System.Windows.Forms.NumericUpDown();
            this.txtFolderNamePrefix = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSplit = new System.Windows.Forms.Button();
            this.tabFunctions.SuspendLayout();
            this.tabDownload.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabDatabase.SuspendLayout();
            this.tabTools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numImagesPerFolder)).BeginInit();
            this.SuspendLayout();
            // 
            // txtOutput
            // 
            this.txtOutput.BackColor = System.Drawing.Color.Black;
            this.txtOutput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtOutput.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.txtOutput.DetectUrls = false;
            this.txtOutput.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutput.ForeColor = System.Drawing.Color.White;
            this.txtOutput.Location = new System.Drawing.Point(274, 3);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.Size = new System.Drawing.Size(507, 264);
            this.txtOutput.TabIndex = 0;
            this.txtOutput.Text = "";
            // 
            // pbPrimary
            // 
            this.pbPrimary.Location = new System.Drawing.Point(2, 247);
            this.pbPrimary.Name = "pbPrimary";
            this.pbPrimary.Size = new System.Drawing.Size(270, 20);
            this.pbPrimary.TabIndex = 1;
            this.pbPrimary.Click += new System.EventHandler(this.pbPrimary_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(2, 211);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(130, 30);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel Operation";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClearConsole
            // 
            this.btnClearConsole.Location = new System.Drawing.Point(138, 211);
            this.btnClearConsole.Name = "btnClearConsole";
            this.btnClearConsole.Size = new System.Drawing.Size(130, 30);
            this.btnClearConsole.TabIndex = 3;
            this.btnClearConsole.Text = "Clear Console";
            this.btnClearConsole.UseVisualStyleBackColor = true;
            this.btnClearConsole.Click += new System.EventHandler(this.btnClearConsole_Click);
            // 
            // tabFunctions
            // 
            this.tabFunctions.Controls.Add(this.tabDownload);
            this.tabFunctions.Controls.Add(this.tabDatabase);
            this.tabFunctions.Controls.Add(this.tabTools);
            this.tabFunctions.Location = new System.Drawing.Point(2, 2);
            this.tabFunctions.Name = "tabFunctions";
            this.tabFunctions.SelectedIndex = 0;
            this.tabFunctions.Size = new System.Drawing.Size(270, 207);
            this.tabFunctions.TabIndex = 4;
            // 
            // tabDownload
            // 
            this.tabDownload.Controls.Add(this.btnUrlClear);
            this.tabDownload.Controls.Add(this.btnTestDownload);
            this.tabDownload.Controls.Add(this.btnStartDownload);
            this.tabDownload.Controls.Add(this.groupBox1);
            this.tabDownload.Controls.Add(this.label1);
            this.tabDownload.Controls.Add(this.txtUrl);
            this.tabDownload.Location = new System.Drawing.Point(4, 22);
            this.tabDownload.Name = "tabDownload";
            this.tabDownload.Padding = new System.Windows.Forms.Padding(3);
            this.tabDownload.Size = new System.Drawing.Size(262, 181);
            this.tabDownload.TabIndex = 0;
            this.tabDownload.Text = "Download";
            this.tabDownload.UseVisualStyleBackColor = true;
            // 
            // btnUrlClear
            // 
            this.btnUrlClear.Location = new System.Drawing.Point(230, 17);
            this.btnUrlClear.Name = "btnUrlClear";
            this.btnUrlClear.Size = new System.Drawing.Size(26, 23);
            this.btnUrlClear.TabIndex = 5;
            this.btnUrlClear.Text = "X";
            this.btnUrlClear.UseVisualStyleBackColor = true;
            // 
            // btnTestDownload
            // 
            this.btnTestDownload.Location = new System.Drawing.Point(6, 144);
            this.btnTestDownload.Name = "btnTestDownload";
            this.btnTestDownload.Size = new System.Drawing.Size(75, 30);
            this.btnTestDownload.TabIndex = 4;
            this.btnTestDownload.Text = "Test URL";
            this.btnTestDownload.UseVisualStyleBackColor = true;
            // 
            // btnStartDownload
            // 
            this.btnStartDownload.Location = new System.Drawing.Point(87, 144);
            this.btnStartDownload.Name = "btnStartDownload";
            this.btnStartDownload.Size = new System.Drawing.Size(169, 30);
            this.btnStartDownload.TabIndex = 3;
            this.btnStartDownload.Text = "Start Download";
            this.btnStartDownload.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radSearchBoth);
            this.groupBox1.Controls.Add(this.radSearchA);
            this.groupBox1.Controls.Add(this.radSearchImg);
            this.groupBox1.Location = new System.Drawing.Point(6, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 93);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Location";
            // 
            // radSearchBoth
            // 
            this.radSearchBoth.AutoSize = true;
            this.radSearchBoth.Location = new System.Drawing.Point(6, 65);
            this.radSearchBoth.Name = "radSearchBoth";
            this.radSearchBoth.Size = new System.Drawing.Size(166, 17);
            this.radSearchBoth.TabIndex = 2;
            this.radSearchBoth.TabStop = true;
            this.radSearchBoth.Text = "Both <img> tags and <a> tags";
            this.radSearchBoth.UseVisualStyleBackColor = true;
            // 
            // radSearchA
            // 
            this.radSearchA.AutoSize = true;
            this.radSearchA.Location = new System.Drawing.Point(6, 42);
            this.radSearchA.Name = "radSearchA";
            this.radSearchA.Size = new System.Drawing.Size(149, 17);
            this.radSearchA.TabIndex = 1;
            this.radSearchA.TabStop = true;
            this.radSearchA.Text = "<a> tags with image URLs";
            this.radSearchA.UseVisualStyleBackColor = true;
            // 
            // radSearchImg
            // 
            this.radSearchImg.AutoSize = true;
            this.radSearchImg.Location = new System.Drawing.Point(6, 19);
            this.radSearchImg.Name = "radSearchImg";
            this.radSearchImg.Size = new System.Drawing.Size(76, 17);
            this.radSearchImg.TabIndex = 0;
            this.radSearchImg.TabStop = true;
            this.radSearchImg.Text = "<img> tags";
            this.radSearchImg.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "URL:";
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(6, 19);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(218, 20);
            this.txtUrl.TabIndex = 0;
            // 
            // tabDatabase
            // 
            this.tabDatabase.Controls.Add(this.btnCreateDb);
            this.tabDatabase.Controls.Add(this.btnImport);
            this.tabDatabase.Location = new System.Drawing.Point(4, 22);
            this.tabDatabase.Name = "tabDatabase";
            this.tabDatabase.Padding = new System.Windows.Forms.Padding(3);
            this.tabDatabase.Size = new System.Drawing.Size(262, 181);
            this.tabDatabase.TabIndex = 1;
            this.tabDatabase.Text = "Database";
            this.tabDatabase.UseVisualStyleBackColor = true;
            // 
            // btnCreateDb
            // 
            this.btnCreateDb.BackColor = System.Drawing.Color.Red;
            this.btnCreateDb.ForeColor = System.Drawing.Color.Orange;
            this.btnCreateDb.Location = new System.Drawing.Point(6, 145);
            this.btnCreateDb.Name = "btnCreateDb";
            this.btnCreateDb.Size = new System.Drawing.Size(250, 30);
            this.btnCreateDb.TabIndex = 1;
            this.btnCreateDb.Text = "(RE)CREATE DATABASE STRUCTURE";
            this.btnCreateDb.UseVisualStyleBackColor = false;
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(6, 6);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(250, 30);
            this.btnImport.TabIndex = 0;
            this.btnImport.Text = "Import Input Folder to Database";
            this.btnImport.UseVisualStyleBackColor = true;
            // 
            // tabTools
            // 
            this.tabTools.Controls.Add(this.numImagesPerFolder);
            this.tabTools.Controls.Add(this.txtFolderNamePrefix);
            this.tabTools.Controls.Add(this.label3);
            this.tabTools.Controls.Add(this.label2);
            this.tabTools.Controls.Add(this.btnSplit);
            this.tabTools.Location = new System.Drawing.Point(4, 22);
            this.tabTools.Name = "tabTools";
            this.tabTools.Padding = new System.Windows.Forms.Padding(3);
            this.tabTools.Size = new System.Drawing.Size(262, 181);
            this.tabTools.TabIndex = 2;
            this.tabTools.Text = "Tools";
            this.tabTools.UseVisualStyleBackColor = true;
            // 
            // numImagesPerFolder
            // 
            this.numImagesPerFolder.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numImagesPerFolder.Location = new System.Drawing.Point(103, 40);
            this.numImagesPerFolder.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numImagesPerFolder.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numImagesPerFolder.Name = "numImagesPerFolder";
            this.numImagesPerFolder.Size = new System.Drawing.Size(153, 20);
            this.numImagesPerFolder.TabIndex = 4;
            this.numImagesPerFolder.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // txtFolderNamePrefix
            // 
            this.txtFolderNamePrefix.Location = new System.Drawing.Point(9, 19);
            this.txtFolderNamePrefix.Name = "txtFolderNamePrefix";
            this.txtFolderNamePrefix.Size = new System.Drawing.Size(247, 20);
            this.txtFolderNamePrefix.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Images per folder:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(211, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Folder name prefix (blank for numbers only):";
            // 
            // btnSplit
            // 
            this.btnSplit.Location = new System.Drawing.Point(6, 66);
            this.btnSplit.Name = "btnSplit";
            this.btnSplit.Size = new System.Drawing.Size(250, 30);
            this.btnSplit.TabIndex = 0;
            this.btnSplit.Text = "Split Input Folder Into Smaller Folders";
            this.btnSplit.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 269);
            this.Controls.Add(this.tabFunctions);
            this.Controls.Add(this.btnClearConsole);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.pbPrimary);
            this.Controls.Add(this.txtOutput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Image Scraper";
            this.tabFunctions.ResumeLayout(false);
            this.tabDownload.ResumeLayout(false);
            this.tabDownload.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabDatabase.ResumeLayout(false);
            this.tabTools.ResumeLayout(false);
            this.tabTools.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numImagesPerFolder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox txtOutput;
        private System.Windows.Forms.ProgressBar pbPrimary;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnClearConsole;
        private System.Windows.Forms.TabControl tabFunctions;
        private System.Windows.Forms.TabPage tabDownload;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radSearchBoth;
        private System.Windows.Forms.RadioButton radSearchA;
        private System.Windows.Forms.RadioButton radSearchImg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.TabPage tabDatabase;
        private System.Windows.Forms.TabPage tabTools;
        private System.Windows.Forms.Button btnTestDownload;
        private System.Windows.Forms.Button btnStartDownload;
        private System.Windows.Forms.Button btnCreateDb;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.NumericUpDown numImagesPerFolder;
        private System.Windows.Forms.TextBox txtFolderNamePrefix;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSplit;
        private System.Windows.Forms.Button btnUrlClear;
    }
}

