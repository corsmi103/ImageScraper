using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Data.SQLite; // For SQLite database interactions
using System.Security.Cryptography; // For hashing operations

namespace ImageScraper
{
    class ISDatabase
    {
        // Allowed file types for images
        private readonly string[] allowedFiles = { ".jpg", ".jpeg", ".png", ".bmp", ".gif" };

        /// <summary>
        /// Check images against the database of hashes
        /// </summary>
        /// <param name="scraperParams">Dictionary list of settings</param>
        public void CheckImages(Dictionary<string, string> scraperParams)
        {
            // Import settings
            string inputFolder = scraperParams["input"];
            string dbFile = scraperParams["dbFile"];
            string collFolder = scraperParams["collisions"];
            string trashFolder = scraperParams["trash"];

            // Load input directory
            DirectoryInfo inputDir = new DirectoryInfo(inputFolder);

            // Pull list of files in input
            FileInfo[] fileList = inputDir.GetFiles("*.*", SearchOption.AllDirectories);

            // Check that any files were found
            if (fileList.Count() != 0)
            {
                // Initialize counters
                int imagesChecked = 0;
                int collisionsFound = 0;

                // Initialize SHA256 object
                SHA256 shaObj = SHA256Managed.Create();
                byte[] imageHash;

                // Connect to DB
                string dbLoc = "URI=file:" + dbFile;
                using (SQLiteConnection _db = new SQLiteConnection(dbLoc))
                {
                    // Open
                    _db.Open();

                    // Process images
                    foreach (FileInfo fInfo in fileList)
                    {
                        // Grab extenion of current file
                        string fileExt = fInfo.Extension.ToLower();

                        // Check if the file is NOT an image and move it to trash dir
                        if (!allowedFiles.Contains(fileExt))
                        {
                            // File was NOT of an allowed type

                            // Move file to trash dir
                            if (!Directory.Exists(trashFolder))
                                Directory.CreateDirectory(trashFolder);
                            string fileName = Path.GetFileName(fInfo.ToString());
                            string destination = Path.Combine(trashFolder, fileName);
                            if (!File.Exists(destination))
                                File.Move(inputFolder + fInfo.ToString(), destination);

                            // Skip this foreach loop step
                            continue;
                        }

                        // Check if image hash is in the DB
                        try
                        {
                            // Open file stream
                            FileStream fStream = fInfo.Open(FileMode.Open);
                            fStream.Position = 0;

                            // Compute hash of file stream
                            imageHash = shaObj.ComputeHash(fStream);

                            // Format hash into readable string
                            string hashOutput = "";
                            for (int i = 0; i < imageHash.Length; i++)
                            {
                                hashOutput += string.Format("{0:X2}", imageHash[i]);
                            }

                            // Close file
                            fStream.Close();

                            // Check database for hash
                            string sqlSelect = "SELECT * FROM images WHERE hash='" + hashOutput + "'";
                            using (SQLiteCommand sqlCmd = new SQLiteCommand(sqlSelect, _db))
                            {
                                // Create reader
                                using (SQLiteDataReader sqlRdr = sqlCmd.ExecuteReader())
                                {
                                    if (sqlRdr.HasRows)
                                    {
                                        // Hash was found, update found count
                                        collisionsFound++;

                                        // Assume first entry was correct one
                                        sqlRdr.Read();

                                        // Calculate new found count
                                        string readerFound = sqlRdr["found"].ToString();
                                        int newFoundCount;
                                        bool checkParse = int.TryParse(readerFound, out newFoundCount);
                                        if (checkParse)
                                        {
                                            newFoundCount++; // Previously found, add up
                                        }
                                        else
                                        {
                                            newFoundCount = 1;
                                        }

                                        // Update row with new found count
                                        string sqlUpdate = "UPDATE images SET found=" + newFoundCount
                                                         + " WHERE hash='" + hashOutput + "'";
                                        using (SQLiteCommand sqlUpdateCmd = new SQLiteCommand(_db))
                                        {
                                            sqlUpdateCmd.CommandText = sqlUpdate;
                                            sqlUpdateCmd.ExecuteNonQuery();
                                        }

                                        // Move file to collisions directory
                                        if (!Directory.Exists(collFolder))
                                            Directory.CreateDirectory(collFolder);
                                        string fileName = Path.GetFileName(fInfo.ToString());
                                        string destination = Path.Combine(collFolder, fileName);
                                        if (!File.Exists(destination))
                                            File.Move(inputFolder + fInfo.ToString(), destination);
                                    }
                                    else
                                    {
                                        // Hash was NOT found, add entry to DB
                                        using (SQLiteCommand sqlCmd2 = new SQLiteCommand(_db))
                                        {
                                            // Insert new record
                                            sqlCmd2.CommandText = "INSERT INTO images(hash, found) VALUES("
                                                                + "'" + hashOutput + "', "
                                                                + "1"
                                                                + ")";
                                            sqlCmd2.ExecuteNonQuery();
                                        }
                                    }

                                    // Update images checked counter
                                    imagesChecked++;
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            UpdateConsole("Failed to check image against DB: " + fInfo.Name
                                          + " Reason: " + ex.Message, "red");
                        }
                    }

                    // Close
                    _db.Close();
                }

                // Report on compeleted task
                UpdateConsole("Finished checking images against database: "
                              + imagesChecked + " images checked " + collisionsFound
                              + " collisions were found.", "grn");
            }
            else
            {
                UpdateConsole("No files found in input folder!", "red");
            }
        }

        /// <summary>
        /// (Re)create the database of hashes
        /// </summary>
        /// <param name="scraperParams">Dictionary list of settings</param>
        public void CreateDatabase(Dictionary<string, string> scraperParams)
        {
            try
            {
                // Format string for database file location
                string dbLoc = "URI=file:" + scraperParams["dbFile"];

                // Connect to DB (or force creation of a new DB)
                using (SQLiteConnection _dbConn = new SQLiteConnection(dbLoc))
                {
                    // Open
                    _dbConn.Open();

                    // Perform table create
                    using (SQLiteCommand sqlCmd = new SQLiteCommand(_dbConn))
                    {
                        // Attempt to drop old table
                        sqlCmd.CommandText = "DROP TABLE IF EXISTS images";
                        sqlCmd.ExecuteNonQuery();

                        // Create table
                        sqlCmd.CommandText = "CREATE TABLE images ("
                                           + "id INTEGER PRIMARY KEY, "
                                           + "hash TEXT, "
                                           + "found INTEGER"
                                           + ")";
                        sqlCmd.ExecuteNonQuery();
                    }

                    // Close
                    _dbConn.Close();
                }

                // Report success
                UpdateConsole("SQLite database (re)created!", "grn");
            }
            catch (Exception ex)
            {
                UpdateConsole(ex.ToString(), "red");
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
        /// Update the console on the main form using event, choose a color
        /// </summary>
        /// <param name="consoleMessage">Message to output to console</param>
        /// <param name="messageColor">Color chosen from list of: yel, grn, blu, red</param>
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
