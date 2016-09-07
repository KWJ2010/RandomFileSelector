using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomFileSelector
{
    /// <summary>
    /// This Model stores the data types that will be used by this program
    /// </summary>
    class RandomFileSelectorModel : INotifyBase
    {
        #region Private Fields
        private string sourcePath;
        private string destinationPath;
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
        #endregion // Public Properties

            #region Constructor
        public RandomFileSelectorModel()
        {
            SourcePath = "This is a sourcepath test";
            DestinationPath = "DestinationPath Test!";
        }
        #endregion //Constructor

        #region Private Methods

        #endregion
    }
}
