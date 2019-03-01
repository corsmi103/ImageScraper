using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO; // For file operations
using System.Net; // For WebClient
using HtmlAgilityPack; // For parsing HTML page

namespace ImageScraper
{
    class ISScraper
    {
        // Imported settings storage
        private string dbFile = "";
        private string inputFolder = "";
        private string outputFolder = "";
        private string tempFolder = "";
        private string tagChoice = "";
        private string dlPageUrl = "";

        // Settings
        private readonly string userAgent = "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0) "
                                          + "(compatible; MSIE 6.0; Windows NT 5.1; "
                                          + ".NET CLR 1.1.4322; .NET CLR 2.0.50727)";
        private readonly string tempFile = "temp";
        private readonly string outputFilePrefix = "img-urls-";

        /// <summary>
        /// Set properties before performing download
        /// </summary>
        /// <param name="scraperParams">Properties in dictionary variable</param>
        public void SetProperties(Dictionary<string, string> scraperParams)
        {
            // Import settings from main form
            dbFile = scraperParams["dbFile"];
            inputFolder = scraperParams["input"];
            outputFolder = scraperParams["output"];
            tempFolder = scraperParams["temp"];
        }

        /// <summary>
        /// Start download of image URLs
        /// </summary>
        /// <param name="tagChoice"></param>
        /// <param name="dlUrl"></param>
        public void StartDownload(string tagChosen, string dlUrl)
        {
            tagChoice = tagChosen;
            ToggleDownloadStatus();
            dlPageUrl = dlUrl;
            DownloadTempPage(dlUrl);
        }

        /// <summary>
        /// Download a single page to temporary file
        /// </summary>
        /// <param name="pageUrl">Full URL of page to download</param>
        private void DownloadTempPage(string pageUrl)
        {
            try
            {
                // Create web client connection
                using (WebClient wClient = new WebClient())
                {
                    // Set user agent
                    wClient.Headers["User-Agent"] = userAgent;

                    // Add async hooks for download completion
                    wClient.DownloadFileCompleted += PageDownloaded;

                    // Perform download
                    Uri pageUri = new Uri(pageUrl);
                    wClient.DownloadFileAsync(pageUri, tempFolder + tempFile);
                }
            }
            catch (Exception ex)
            {
                UpdateConsole("Error downloading page to temp file: " + ex.Message, "red");
                CleanUp();
            }
        }

        /// <summary>
        /// Action triggered after completed download from DownloadTempPage method
        /// </summary>
        private void PageDownloaded(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null)
                    throw e.Error;
                if (e.Cancelled)
                    throw new Exception("Page download cancelled!");

                // Finished download, report progress
                UpdateConsole("Finished download page!", "grn");

                // Go to next step
                ParseTempPage();
            }
            catch (Exception ex)
            {
                UpdateConsole("Failed to download page: " + ex.Message, "red");
                CleanUp();
            }
        }

        /// <summary>
        /// Parse temp page after download completed
        /// </summary>
        private void ParseTempPage()
        {
            try
            {
                // Storage for URL list
                List<string> imgUrls = new List<string>();

                // Report
                UpdateConsole("Starting extraction of URLs...", "blu");

                // Extract URLs from temp page
                imgUrls = ExtractImageUrls();

                // Check result
                if (imgUrls.Count > 0)
                {
                    UpdateConsole("Extracted " + imgUrls.Count.ToString() 
                                  + " image URLs from temp page!", "grn");
                }
                else
                {
                    throw new Exception("Failed to find any image URLs on temp page!");
                }

                // Parse URLs into output file
                ParseFoundUrls(imgUrls);
            }
            catch (Exception ex)
            {
                UpdateConsole("Failed to parse temp page: " + ex.Message, "red");
                CleanUp();
            }
        }

        /// <summary>
        /// Extracts list of image URLs from temp file
        /// </summary>
        /// <returns>List of image URLs extracted from temp file</returns>
        private List<string> ExtractImageUrls()
        {
            try
            {
                using (FileStream fs = File.OpenRead(tempFolder + tempFile))
                {
                    // URL list for output
                    List<string> imageUrls = new List<string>();

                    // Create new HtmlDocument for using HtmlAgilityPack
                    HtmlDocument htmlDoc = new HtmlDocument();
                    htmlDoc.Load(fs);

                    // Generate collection of nodes and format for output
                    HtmlNodeCollection htmlNodes;

                    // Grab all <img> tag SRC URLs
                    string nodeValue = "";
                    if ((tagChoice == "img") || (tagChoice == "both")) 
                    {
                        htmlNodes = htmlDoc.DocumentNode.SelectNodes("//img");
                        foreach (HtmlNode node in htmlNodes)
                        {
                            // Attempt to format the image URL using the originally passed URL
                            nodeValue = node.GetAttributeValue("src", "URL Not Found");
                            if (nodeValue == "URL Not Found")
                                continue;

                            // Format the output using an URI object
                            if (Uri.TryCreate(new Uri(dlPageUrl), nodeValue, out Uri result))
                            {
                                imageUrls.Add(result.ToString());
                            }
                            else
                            {
                                imageUrls.Add(nodeValue);
                            }
                        }
                    }
                    
                    // Grab all <a> tag HREF URLs with image file extensions
                    if ((tagChoice == "a") || (tagChoice == "both"))
                    {
                        htmlNodes = htmlDoc.DocumentNode.SelectNodes("//a");
                        foreach (HtmlNode node in htmlNodes)
                        {
                            // Take out the HREF value and check if it contains an image file extension
                            nodeValue = node.GetAttributeValue("href", "URL Not Found");
                            if (nodeValue == "URL Not Found")
                                continue;
                            nodeValue = nodeValue.ToLower();
                            if (nodeValue.Contains(".jpg") || nodeValue.Contains(".jpeg") 
                                || nodeValue.Contains(".png") || nodeValue.Contains(".bmp")
                                || nodeValue.Contains(".gif"))
                            {
                                // Format the output using an URI object
                                if (Uri.TryCreate(new Uri(dlPageUrl), nodeValue, out Uri result))
                                {
                                    imageUrls.Add(result.ToString());
                                }
                                else
                                {
                                    imageUrls.Add(nodeValue);
                                }
                            }
                        }
                    }

                    return imageUrls;
                }
            }
            catch (Exception ex)
            {
                UpdateConsole("Error extracting image URLs from temp page: " 
                              + ex.Message, "red");
                CleanUp();
                return new List<string>();
            }
        }

        /// <summary>
        /// Parse the list of found image URLs and add them to the output file
        /// </summary>
        /// <param name="imageUrls">List of image URLs found in ExtractImageUrls</param>
        private void ParseFoundUrls(List<string> imageUrls)
        {
            try
            {
                // Report progress
                UpdateConsole("Starting output of image URLs to file...", "blu");

                // Create output folder if needed
                if (!Directory.Exists(outputFolder))
                    Directory.CreateDirectory(outputFolder);

                // Determine output file name based on day of operation
                string outputFile = outputFilePrefix + DateTime.UtcNow.ToString(@"MM-dd-yyyy") + ".txt";

                // Write list to file
                using (StreamWriter file = new StreamWriter(outputFolder + outputFile, true))
                {
                    foreach (string line in imageUrls)
                        file.WriteLine(line);
                }

                // Report completion of task
                UpdateConsole("Finished writing image URLs to text file " + outputFile + "!", "grn");
                CleanUp();
            }
            catch (Exception ex)
            {
                UpdateConsole("Failed to output image URLs to text file: " + ex.ToString(), "red");
                CleanUp();
            }
        }

        /// <summary>
        /// Clean up temp files and toggle download status to false
        /// </summary>
        private void CleanUp()
        {
            // Delete temp file
            if (File.Exists(tempFolder + tempFile))
                File.Delete(tempFolder + tempFile);

            // Force toggle download status false
            ToggleDownloadStatus(false, true);
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
        /// <param name="consoleMessage">Message to output to console</param>
        /// <param name="messageColor">Color from list of: yel, grn, blu, red, whi</param>
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

        /// <summary>
        /// Toggle download status without forcing a state
        /// </summary>
        public void ToggleDownloadStatus()
        {
            ToggleDownloadStatus(false, false);
        }

        /// <summary>
        /// Toggle download status with option to force
        /// </summary>
        /// <param name="forceTrue">Force download status to true</param>
        /// <param name="forceFalse">Force download status to false</param>
        public void ToggleDownloadStatus(bool forceTrue, bool forceFalse)
        {
            ToggleDownloadStatusEventArgs tdsea = new ToggleDownloadStatusEventArgs
            {
                ForceTrue = forceTrue,
                ForceFalse = forceFalse
            };
            OnToggleDlStatus(tdsea);
        }
        public event EventHandler<ToggleDownloadStatusEventArgs> ToggledDownloadStatus;
        protected virtual void OnToggleDlStatus(ToggleDownloadStatusEventArgs e)
        {
            ToggledDownloadStatus?.Invoke(this, e);
        }
    }
}
