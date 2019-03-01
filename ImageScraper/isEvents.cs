using System;

namespace ImageScraper
{
    /// <summary>
    /// Event args for updating console event
    /// </summary>
    public class UpdatedConsoleEventArgs : EventArgs
    {
        public string MessageOutput { get; set; }
        public string MessageColor { get; set; }
    }

    /// <summary>
    /// Event args for toggling download status
    /// </summary>
    public class ToggleDownloadStatusEventArgs : EventArgs
    {
        public bool ForceTrue { get; set; }
        public bool ForceFalse { get; set; }
    }
}