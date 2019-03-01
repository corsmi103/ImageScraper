using System;
using System.Collections.Generic;
using System.Linq;
using System.IO; // For file operations

namespace ImageScraper
{
    class ISTools
    {
        /// <summary>
        /// Split input folder into separate folders
        /// </summary>
        /// <param name="toolParams">Dictionary list of settings</param>
        /// <param name="folderPrefix">Prefix used for naming output folders</param>
        /// <param name="splitAmount">Number of images per directory</param>
        public void SplitOutput(Dictionary<string, string> toolParams, string folderPrefix, decimal splitAmount)
        {
            // Import dictionary of settings
            string inputFolder = toolParams["input"];
            string outputFolder = toolParams["output"];
            int splitCount = (int)splitAmount;

            // Variables
            int imageCount = 0;
            int totalImageCount = 0;
            int folderCount = 1;

            // Check if the folder prefix was passed or not and append a space
            if (folderPrefix != "")
                folderPrefix += " ";
            string outputLocation = outputFolder + folderPrefix;

            // Check that output folder exists and make it if needed
            if (!Directory.Exists(outputFolder))
                Directory.CreateDirectory(outputFolder);

            // Get list of files from input folder
            List<string> inputFiles = Directory.GetFiles(inputFolder, 
                                                         "*.*", SearchOption.AllDirectories).ToList();

            // Check that any files were found
            if (inputFiles.Count() != 0)
            {
                // Pre-create the folders for output
                int numberOfFiles = inputFiles.Count();
                int numberOfFolders = numberOfFiles / splitCount;
                numberOfFolders++;
                for (int i = 1; i <= numberOfFolders; i++)
                {
                    // Format output folder name
                    string tempNewFolderName = outputLocation + i + @"\";

                    // Create directory if it doesn't already exist
                    if (!Directory.Exists(tempNewFolderName))
                        Directory.CreateDirectory(tempNewFolderName);
                }

                // Set baseline output folder
                string outputSubDir = outputLocation + @"1\";

                // Setup random number if needed for renaming
                Random newRand = new Random();

                // Scan files and move to new directories
                foreach (string file in inputFiles)
                {
                    // Determine which directory will be output to
                    if (imageCount == splitCount)
                    {
                        // Push folder counter further and use new name
                        folderCount++;
                        imageCount = 0;
                        outputSubDir = outputLocation + folderCount + @"\";
                    }

                    // Open file for moving
                    string fileName = Path.GetFileName(file);
                    string destination = Path.Combine(outputSubDir, fileName);
                    if (!File.Exists(destination))
                    {
                        File.Move(file, destination);
                    }
                    else
                    {
                        // Name collision found, generate time + random number to rename
                        string randNum = newRand.Next(1000, 10000).ToString();
                        string newFileName = DateTime.UtcNow.ToString(@"yyyyMMddHHmmssffff")
                                           + "-" + randNum + "_" + fileName;
                        destination = Path.Combine(outputSubDir, newFileName);
                        if (!File.Exists(destination))
                        {
                            File.Move(file, destination);
                        }
                        else
                        {
                            UpdateConsole("Failed to move (even renamed) image: "
                                          + newFileName + " originally " + fileName, "red");
                        }
                    }

                    // Increment image counters
                    imageCount++;
                    totalImageCount++;
                }

                // Report completion
                UpdateConsole("Finished image splitting operation! Moved "
                              + totalImageCount + " images and generated "
                              + folderCount + " folders!", "grn");
            }
            else
            {
                UpdateConsole("Found no files to split!", "red");
            }
        }

        /// <summary>
        /// Update the console on the main form using event, default color
        /// </summary>
        /// <param name="consoleMessage">Message to output to console</param>
        public void UpdateConsole(string consoleMessage)
        {
            UpdateConsole(consoleMessage, "whi");
        }

        /// <summary>
        /// Update the console on the main form using event, choose color
        /// </summary>
        /// <param name="consoleMessage">Messsage to output to console</param>
        /// <param name="messageColor">Color from list of: yel, grn, blu, red</param>
        public void UpdateConsole(string consoleMessage, string messageColor)
        {
            UpdatedConsoleEventArgs ucea = new UpdatedConsoleEventArgs
            {
                MessageOutput = consoleMessage,
                MessageColor = messageColor
            };
            OnConsoleUpdated(ucea);
        }

        /// <summary>
        /// Event handler for updating console on main form
        /// </summary>
        public event EventHandler<UpdatedConsoleEventArgs> ConsoleUpdated;
        protected virtual void OnConsoleUpdated(UpdatedConsoleEventArgs e)
        {
            ConsoleUpdated?.Invoke(this, e);
        }
    }
}
