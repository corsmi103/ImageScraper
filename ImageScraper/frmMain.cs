using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

// Project-specific use statements
using System.IO;

namespace ImageScraper
{
    public partial class FrmMain : Form
    {
        // Parameters for scraper
        private Dictionary<string, string> scraperParams = new Dictionary<string, string>();

        // Object for processing downloads
        ISScraper scraper = new ISScraper();

        // Object for database actions
        ISDatabase dbActions = new ISDatabase();

        // Object for tool actions
        ISTools toolActions = new ISTools();

        /// <summary>
        /// Initialize the main form and bind events
        /// </summary>
        public FrmMain()
        {
            InitializeComponent();

            // Load parameters for scraper
            scraperParams.Add("dbFile", "images.sqlite");
            scraperParams.Add("input", @"input\");
            scraperParams.Add("output", @"output\");
            scraperParams.Add("temp", @"temp\");
            scraperParams.Add("collisions", @"output\collisions\");
            scraperParams.Add("trash", @"output\trash\");

            // Set parameters for scraper object
            scraper.SetProperties(scraperParams);

            // Generate folders as needed
            if (!Directory.Exists(scraperParams["input"]))
                Directory.CreateDirectory(scraperParams["input"]);
            if (!Directory.Exists(scraperParams["temp"]))
                Directory.CreateDirectory(scraperParams["temp"]);
            if (!Directory.Exists(scraperParams["output"]))
                Directory.CreateDirectory(scraperParams["output"]);

            // Add UpdateConsole event handlers
            scraper.ConsoleUpdated += new EventHandler<UpdatedConsoleEventArgs>(All_ConsoleUpdated);
            toolActions.ConsoleUpdated += new EventHandler<UpdatedConsoleEventArgs>(All_ConsoleUpdated);
            dbActions.ConsoleUpdated += new EventHandler<UpdatedConsoleEventArgs>(All_ConsoleUpdated);

            // Add ToggleDownloadStatus event handler
            scraper.ToggledDownloadStatus += new EventHandler<ToggleDownloadStatusEventArgs>(Scraper_ToggleDlStatus);
        }

        /// <summary>
        /// Handle updating of console
        /// </summary>
        void All_ConsoleUpdated(object sender, UpdatedConsoleEventArgs e)
        {
            if (e != null && e.MessageOutput != null && e.MessageColor != null)
                UpdateConsole(e.MessageOutput, e.MessageColor);
        }

        /// <summary>
        /// Handle updating of download status
        /// </summary>
        void Scraper_ToggleDlStatus(object sender, ToggleDownloadStatusEventArgs e)
        {
            if (e != null)
                ToggleDownloadStatus(e.ForceTrue, e.ForceFalse);
        }

        /// <summary>
        /// Start download process
        /// </summary>
        private void BtnStartDownload_Click(object sender, EventArgs e)
        {
            string startMessage = "";
            string tagChoice = "";

            // Determine which radio button is selected
            if (RadSearchImg.Checked)
            {
                startMessage = "Starting download of <img> tag URLs...";
                tagChoice = "img";
            }
            else if (RadSearchA.Checked)
            {
                startMessage = "Starting download of <a> tag URLs...";
                tagChoice = "a";
            }
            else if (RadSearchBoth.Checked)
            {
                startMessage = "Starting download of both <a> tag URLs and <img> tag URLs...";
                tagChoice = "both";
            }
            else
            {
                UpdateConsole("No tag selection made!", "red");
                return;
            }

            // Start downloading
            UpdateConsole(startMessage, "blu");
            scraper.StartDownload(tagChoice, TxtUrl.Text);
        }

        /// <summary>
        /// Add images from the input folder into the image hash database
        /// </summary>
        private void BtnImport_Click(object sender, EventArgs e)
        {
            // Confirm that non-images will be deleted
            var confirmDatabase = MessageBox.Show("Only image files (.JPG, .JPEG, .PNG, .GIF, .BMP) will remain "
                                                  + "after operation is completed. All non-image "
                                                  + "files will be moved to output trash directory! Continue?",
                                                  "Confirm Non-image Removal", MessageBoxButtons.YesNo);
            if (confirmDatabase == DialogResult.No)
            {
                // Exit
                UpdateConsole("Cancelled image checking.", "red");
                return;
            }

            // Announce start
            UpdateConsole("Starting check of images from input folder against database...", "blu");
            UpdateConsole("Note: All unique images will remain in the INPUT folder. "
                          + "All collisions are moved to OUTPUT collisions folder. "
                          + "All non-image files are moved to OUTPUT trash folder.");

            // Start DB check process
            dbActions.CheckImages(scraperParams);

            // Announce notice about being available to split
            UpdateConsole("Ready for splitting process!");
        }

        /// <summary>
        /// (Re)Create database from scratch if needed. Note: WILL DELETE EXISTING DB!
        /// </summary>
        private void BtnCreateDb_Click(object sender, EventArgs e)
        {
            // Confirm change
            var confirmDatabase = MessageBox.Show("Are you sure you want to wipe and remake the database?",
                                                  "Confirm Database Wipe", MessageBoxButtons.YesNo);
            if (confirmDatabase == DialogResult.No)
            {
                // Exit
                UpdateConsole("Cancelled database (re)creation.", "red");
                return;
            }

            // (Re)Create database
            dbActions.CreateDatabase(scraperParams);
        }
        
        /// <summary>
        /// Split input folder into separate folders
        /// </summary>
        private void BtnSplit_Click(object sender, EventArgs e)
        {
            // Announce start
            UpdateConsole("Starting image splitting process...", "blu");

            // Start splitting process
            toolActions.SplitOutput(scraperParams, TxtFolderNamePrefix.Text, NumImagesPerFolder.Value);

            // Announce notice about leftover folders
            UpdateConsole("Note that any folders in the input folder will need to be manually deleted!", "yel");
        }

        /// <summary>
        /// Launch GitHub link using system
        /// </summary>
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("https://github.com/corsmi103/");
            }
            catch (Exception ex)
            {
                UpdateConsole("Failed to launch web browser with GitHub link. Please manually visit: "
                              + "https://github.com/corsmi103/");
            }
        }

        /// <summary>
        /// Clear output console
        /// </summary>
        private void BtnClearConsole_Click(object sender, EventArgs e)
        {
            TxtOutput.Clear();
        }

        /// <summary>
        /// Clear URL textbox
        /// </summary>
        private void BtnUrlClear_Click(object sender, EventArgs e)
        {
            TxtUrl.Clear();
        }

        /// <summary>
        /// Toggle the status of the current download to prevent repeating during a download
        /// </summary>
        /// <param name="forceTrue"></param>
        /// <param name="forceFalse"></param>
        private void ToggleDownloadStatus(bool forceTrue, bool forceFalse)
        {
            if (forceFalse)
            {
                // Force disable the download button
                BtnStartDownload.Enabled = true;
            }
            else if (forceTrue)
            {
                // Force status to true
                BtnStartDownload.Enabled = false;
            }
            else
            {
                // Invert current status
                BtnStartDownload.Enabled = !BtnStartDownload.Enabled;
            }
        }

        /// <summary>
        /// Updates "console" with a message and default color of white
        /// </summary>
        /// <param name="updateMsg">Message to output to "console"</param>
        private void UpdateConsole(string updateMsg)
        {
            UpdateConsole(updateMsg, "whi");
        }

        /// <summary>
        /// Updates "console" with a message in a specific color
        /// </summary>
        /// <param name="updateMsg">Message to output to "console"</param>
        /// <param name="color">Color from list of: yel, grn, blu, red</param>
        private void UpdateConsole(string updateMsg, string color)
        {
            // Check color input against list of used colors
            Color textColor = new Color();
            switch (color)
            {
                case "yel": // Minor errors or important notices
                    textColor = Color.Yellow;
                    break;
                case "grn": // Completed steps/tasks
                    textColor = Color.Lime;
                    break;
                case "blu": // Started steps/tasks
                    textColor = Color.Aqua;
                    break;
                case "red": // Errors
                    textColor = Color.Red;
                    break;
                default:
                    textColor = Color.White;
                    break;
            }

            // Output message with color
            TxtOutput.AppendText(Environment.NewLine + DateTime.Now.ToString("HH:mm:ss") + " >> " + updateMsg, textColor);
            TxtOutput.SelectionStart = TxtOutput.Text.Length;
            TxtOutput.ScrollToCaret();
        }
    }
}
