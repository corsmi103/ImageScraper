namespace ImageScraper
{
    partial class FrmMain
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
            this.TxtOutput = new System.Windows.Forms.RichTextBox();
            this.BtnClearConsole = new System.Windows.Forms.Button();
            this.TabFunctions = new System.Windows.Forms.TabControl();
            this.tabDownload = new System.Windows.Forms.TabPage();
            this.BtnUrlClear = new System.Windows.Forms.Button();
            this.BtnStartDownload = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RadSearchBoth = new System.Windows.Forms.RadioButton();
            this.RadSearchA = new System.Windows.Forms.RadioButton();
            this.RadSearchImg = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.TxtUrl = new System.Windows.Forms.TextBox();
            this.tabDatabase = new System.Windows.Forms.TabPage();
            this.BtnCreateDb = new System.Windows.Forms.Button();
            this.BtnImport = new System.Windows.Forms.Button();
            this.tabTools = new System.Windows.Forms.TabPage();
            this.NumImagesPerFolder = new System.Windows.Forms.NumericUpDown();
            this.TxtFolderNamePrefix = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnSplit = new System.Windows.Forms.Button();
            this.tabAbout = new System.Windows.Forms.TabPage();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.TabFunctions.SuspendLayout();
            this.tabDownload.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabDatabase.SuspendLayout();
            this.tabTools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumImagesPerFolder)).BeginInit();
            this.tabAbout.SuspendLayout();
            this.SuspendLayout();
            // 
            // TxtOutput
            // 
            this.TxtOutput.BackColor = System.Drawing.Color.Black;
            this.TxtOutput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.TxtOutput.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.TxtOutput.DetectUrls = false;
            this.TxtOutput.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtOutput.ForeColor = System.Drawing.Color.White;
            this.TxtOutput.Location = new System.Drawing.Point(274, 3);
            this.TxtOutput.Name = "TxtOutput";
            this.TxtOutput.ReadOnly = true;
            this.TxtOutput.Size = new System.Drawing.Size(507, 238);
            this.TxtOutput.TabIndex = 0;
            this.TxtOutput.Text = "";
            // 
            // BtnClearConsole
            // 
            this.BtnClearConsole.Location = new System.Drawing.Point(2, 211);
            this.BtnClearConsole.Name = "BtnClearConsole";
            this.BtnClearConsole.Size = new System.Drawing.Size(270, 30);
            this.BtnClearConsole.TabIndex = 3;
            this.BtnClearConsole.Text = "Clear Console";
            this.BtnClearConsole.UseVisualStyleBackColor = true;
            this.BtnClearConsole.Click += new System.EventHandler(this.BtnClearConsole_Click);
            // 
            // TabFunctions
            // 
            this.TabFunctions.Controls.Add(this.tabDownload);
            this.TabFunctions.Controls.Add(this.tabDatabase);
            this.TabFunctions.Controls.Add(this.tabTools);
            this.TabFunctions.Controls.Add(this.tabAbout);
            this.TabFunctions.Location = new System.Drawing.Point(2, 2);
            this.TabFunctions.Name = "TabFunctions";
            this.TabFunctions.SelectedIndex = 0;
            this.TabFunctions.Size = new System.Drawing.Size(270, 207);
            this.TabFunctions.TabIndex = 4;
            // 
            // tabDownload
            // 
            this.tabDownload.Controls.Add(this.BtnUrlClear);
            this.tabDownload.Controls.Add(this.BtnStartDownload);
            this.tabDownload.Controls.Add(this.groupBox1);
            this.tabDownload.Controls.Add(this.label1);
            this.tabDownload.Controls.Add(this.TxtUrl);
            this.tabDownload.Location = new System.Drawing.Point(4, 22);
            this.tabDownload.Name = "tabDownload";
            this.tabDownload.Padding = new System.Windows.Forms.Padding(3);
            this.tabDownload.Size = new System.Drawing.Size(262, 181);
            this.tabDownload.TabIndex = 0;
            this.tabDownload.Text = "Download";
            this.tabDownload.UseVisualStyleBackColor = true;
            // 
            // BtnUrlClear
            // 
            this.BtnUrlClear.Location = new System.Drawing.Point(230, 17);
            this.BtnUrlClear.Name = "BtnUrlClear";
            this.BtnUrlClear.Size = new System.Drawing.Size(26, 24);
            this.BtnUrlClear.TabIndex = 5;
            this.BtnUrlClear.Text = "X";
            this.BtnUrlClear.UseVisualStyleBackColor = true;
            this.BtnUrlClear.Click += new System.EventHandler(this.BtnUrlClear_Click);
            // 
            // BtnStartDownload
            // 
            this.BtnStartDownload.Location = new System.Drawing.Point(6, 144);
            this.BtnStartDownload.Name = "BtnStartDownload";
            this.BtnStartDownload.Size = new System.Drawing.Size(250, 30);
            this.BtnStartDownload.TabIndex = 3;
            this.BtnStartDownload.Text = "Start Download";
            this.BtnStartDownload.UseVisualStyleBackColor = true;
            this.BtnStartDownload.Click += new System.EventHandler(this.BtnStartDownload_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RadSearchBoth);
            this.groupBox1.Controls.Add(this.RadSearchA);
            this.groupBox1.Controls.Add(this.RadSearchImg);
            this.groupBox1.Location = new System.Drawing.Point(6, 45);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(250, 93);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Location";
            // 
            // RadSearchBoth
            // 
            this.RadSearchBoth.AutoSize = true;
            this.RadSearchBoth.Checked = true;
            this.RadSearchBoth.Location = new System.Drawing.Point(6, 65);
            this.RadSearchBoth.Name = "RadSearchBoth";
            this.RadSearchBoth.Size = new System.Drawing.Size(166, 17);
            this.RadSearchBoth.TabIndex = 2;
            this.RadSearchBoth.TabStop = true;
            this.RadSearchBoth.Text = "Both <img> tags and <a> tags";
            this.RadSearchBoth.UseVisualStyleBackColor = true;
            // 
            // RadSearchA
            // 
            this.RadSearchA.AutoSize = true;
            this.RadSearchA.Location = new System.Drawing.Point(6, 42);
            this.RadSearchA.Name = "RadSearchA";
            this.RadSearchA.Size = new System.Drawing.Size(149, 17);
            this.RadSearchA.TabIndex = 1;
            this.RadSearchA.Text = "<a> tags with image URLs";
            this.RadSearchA.UseVisualStyleBackColor = true;
            // 
            // RadSearchImg
            // 
            this.RadSearchImg.AutoSize = true;
            this.RadSearchImg.Location = new System.Drawing.Point(6, 19);
            this.RadSearchImg.Name = "RadSearchImg";
            this.RadSearchImg.Size = new System.Drawing.Size(76, 17);
            this.RadSearchImg.TabIndex = 0;
            this.RadSearchImg.Text = "<img> tags";
            this.RadSearchImg.UseVisualStyleBackColor = true;
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
            // TxtUrl
            // 
            this.TxtUrl.Location = new System.Drawing.Point(6, 19);
            this.TxtUrl.Name = "TxtUrl";
            this.TxtUrl.Size = new System.Drawing.Size(218, 20);
            this.TxtUrl.TabIndex = 0;
            // 
            // tabDatabase
            // 
            this.tabDatabase.Controls.Add(this.BtnCreateDb);
            this.tabDatabase.Controls.Add(this.BtnImport);
            this.tabDatabase.Location = new System.Drawing.Point(4, 22);
            this.tabDatabase.Name = "tabDatabase";
            this.tabDatabase.Padding = new System.Windows.Forms.Padding(3);
            this.tabDatabase.Size = new System.Drawing.Size(262, 181);
            this.tabDatabase.TabIndex = 1;
            this.tabDatabase.Text = "Database";
            this.tabDatabase.UseVisualStyleBackColor = true;
            // 
            // BtnCreateDb
            // 
            this.BtnCreateDb.BackColor = System.Drawing.Color.Red;
            this.BtnCreateDb.ForeColor = System.Drawing.Color.Orange;
            this.BtnCreateDb.Location = new System.Drawing.Point(6, 145);
            this.BtnCreateDb.Name = "BtnCreateDb";
            this.BtnCreateDb.Size = new System.Drawing.Size(250, 30);
            this.BtnCreateDb.TabIndex = 1;
            this.BtnCreateDb.Text = "(RE)CREATE DATABASE STRUCTURE";
            this.BtnCreateDb.UseVisualStyleBackColor = false;
            this.BtnCreateDb.Click += new System.EventHandler(this.BtnCreateDb_Click);
            // 
            // BtnImport
            // 
            this.BtnImport.Location = new System.Drawing.Point(6, 6);
            this.BtnImport.Name = "BtnImport";
            this.BtnImport.Size = new System.Drawing.Size(250, 30);
            this.BtnImport.TabIndex = 0;
            this.BtnImport.Text = "Import Input Folder to Database";
            this.BtnImport.UseVisualStyleBackColor = true;
            this.BtnImport.Click += new System.EventHandler(this.BtnImport_Click);
            // 
            // tabTools
            // 
            this.tabTools.Controls.Add(this.NumImagesPerFolder);
            this.tabTools.Controls.Add(this.TxtFolderNamePrefix);
            this.tabTools.Controls.Add(this.label3);
            this.tabTools.Controls.Add(this.label2);
            this.tabTools.Controls.Add(this.BtnSplit);
            this.tabTools.Location = new System.Drawing.Point(4, 22);
            this.tabTools.Name = "tabTools";
            this.tabTools.Padding = new System.Windows.Forms.Padding(3);
            this.tabTools.Size = new System.Drawing.Size(262, 181);
            this.tabTools.TabIndex = 2;
            this.tabTools.Text = "Tools";
            this.tabTools.UseVisualStyleBackColor = true;
            // 
            // NumImagesPerFolder
            // 
            this.NumImagesPerFolder.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.NumImagesPerFolder.Location = new System.Drawing.Point(103, 40);
            this.NumImagesPerFolder.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NumImagesPerFolder.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.NumImagesPerFolder.Name = "NumImagesPerFolder";
            this.NumImagesPerFolder.Size = new System.Drawing.Size(153, 20);
            this.NumImagesPerFolder.TabIndex = 4;
            this.NumImagesPerFolder.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            // 
            // TxtFolderNamePrefix
            // 
            this.TxtFolderNamePrefix.Location = new System.Drawing.Point(9, 19);
            this.TxtFolderNamePrefix.Name = "TxtFolderNamePrefix";
            this.TxtFolderNamePrefix.Size = new System.Drawing.Size(247, 20);
            this.TxtFolderNamePrefix.TabIndex = 3;
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
            // BtnSplit
            // 
            this.BtnSplit.Location = new System.Drawing.Point(6, 66);
            this.BtnSplit.Name = "BtnSplit";
            this.BtnSplit.Size = new System.Drawing.Size(250, 30);
            this.BtnSplit.TabIndex = 0;
            this.BtnSplit.Text = "Split Input Folder Into Smaller Folders";
            this.BtnSplit.UseVisualStyleBackColor = true;
            this.BtnSplit.Click += new System.EventHandler(this.BtnSplit_Click);
            // 
            // tabAbout
            // 
            this.tabAbout.Controls.Add(this.label8);
            this.tabAbout.Controls.Add(this.label7);
            this.tabAbout.Controls.Add(this.label6);
            this.tabAbout.Controls.Add(this.label5);
            this.tabAbout.Controls.Add(this.linkLabel1);
            this.tabAbout.Controls.Add(this.label4);
            this.tabAbout.Location = new System.Drawing.Point(4, 22);
            this.tabAbout.Name = "tabAbout";
            this.tabAbout.Padding = new System.Windows.Forms.Padding(3);
            this.tabAbout.Size = new System.Drawing.Size(262, 181);
            this.tabAbout.TabIndex = 3;
            this.tabAbout.Text = "About";
            this.tabAbout.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(219, 3);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(40, 13);
            this.linkLabel1.TabIndex = 1;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "GitHub";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Created by corsmi103";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(235, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Created with Visual Studio 2017 with extensions:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "HtmlAgilityPack";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 66);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "SQLite";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Entity Framework";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 244);
            this.Controls.Add(this.TabFunctions);
            this.Controls.Add(this.BtnClearConsole);
            this.Controls.Add(this.TxtOutput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Image Scraper";
            this.TabFunctions.ResumeLayout(false);
            this.tabDownload.ResumeLayout(false);
            this.tabDownload.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabDatabase.ResumeLayout(false);
            this.tabTools.ResumeLayout(false);
            this.tabTools.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumImagesPerFolder)).EndInit();
            this.tabAbout.ResumeLayout(false);
            this.tabAbout.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox TxtOutput;
        private System.Windows.Forms.Button BtnClearConsole;
        private System.Windows.Forms.TabControl TabFunctions;
        private System.Windows.Forms.TabPage tabDownload;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RadSearchBoth;
        private System.Windows.Forms.RadioButton RadSearchA;
        private System.Windows.Forms.RadioButton RadSearchImg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtUrl;
        private System.Windows.Forms.TabPage tabDatabase;
        private System.Windows.Forms.TabPage tabTools;
        private System.Windows.Forms.Button BtnStartDownload;
        private System.Windows.Forms.Button BtnCreateDb;
        private System.Windows.Forms.Button BtnImport;
        private System.Windows.Forms.NumericUpDown NumImagesPerFolder;
        private System.Windows.Forms.TextBox TxtFolderNamePrefix;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnSplit;
        private System.Windows.Forms.Button BtnUrlClear;
        private System.Windows.Forms.TabPage tabAbout;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
    }
}

