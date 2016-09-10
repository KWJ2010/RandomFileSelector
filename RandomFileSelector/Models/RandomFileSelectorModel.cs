using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomFileSelector
{
    /// <summary>
    /// This Model stores the data types that will be used by this program
    /// </summary>
    public class RandomFileSelectorModel : INotifyBase
    {
        #region Private Fields
        private string sourcePath;
        private string destinationPath;
        private string sourceSize;
        private string destinationSize;
        private string fileExtensionType;
        #endregion //Private Fields

        #region Public Properties
        public string SourcePath
        {
            get { return sourcePath; }
            set
            {
                sourcePath = value;
                Notify(this, "SourcePath");
            }
        }
        public string DestinationPath
        {
            get { return destinationPath; }
            set
            {
                destinationPath = value;
                Notify(this, "DestinationPath");
            }
        }
        public string SourceSize
        {
            get { return sourceSize; }
            set
            {
                sourceSize = value;
                Notify(this, "SourceSize");
            }
        }
        public string DestinationSize
        {
            get { return destinationSize; }
            set
            {
                destinationSize = value;
                Notify(this, "DestinationSize");
            }
        }
        public string FileExtensionType
        {
            get { return fileExtensionType; }
            set
            {
                fileExtensionType = value;
                Notify(this, "FileExtensionTypes");
            }
        }
        public string[] SourceFileList { get; set; }
        #endregion // Public Properties

        #region Constructor
        public RandomFileSelectorModel()
        {
            SourcePath = "";
            DestinationPath = "";
            SourceSize = "";
            DestinationSize = "";
            FileExtensionType = "*.mp3";
        }
        #endregion //Constructor

        #region Private Methods

        #endregion
    }
}
