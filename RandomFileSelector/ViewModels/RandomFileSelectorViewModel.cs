using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml.Serialization;

namespace RandomFileSelector
{
    class RandomFileSelectorViewModel : RandomFileSelectorModel
    {
        #region ICommands
        #region Private Commands
        private ICommand _newSettings_Command;
        private ICommand _openSettings_Command;
        private ICommand _saveSettings_Command;
        private ICommand _exportResults_Command;
        private ICommand _printResults_Command;

        private ICommand selectSourcePathCommand;
        private ICommand selectDestinationPathCommand;
        private ICommand copyFilesCommand;
        #endregion //Private ICommands
        #region Public Commands
        [XmlIgnore]
        public ICommand NewSettings_Command
        {
            get { return _newSettings_Command ?? (_newSettings_Command = new ICommandBase(() => NewSettings())); }
        }
        [XmlIgnore]
        public ICommand OpenSettings_Command
        {
            get { return _openSettings_Command ?? (_openSettings_Command = new ICommandBase(() => OpenSettings())); }
        }
        [XmlIgnore]
        public ICommand SaveSettings_Command
        {
            get { return _saveSettings_Command ?? (_saveSettings_Command = new ICommandBase(() => SaveSettings())); }
        }
        [XmlIgnore]
        public ICommand ExportResults_Command
        {
            get { return _exportResults_Command ?? (_exportResults_Command = new ICommandBase(() => ExportResults())); }
        }
        [XmlIgnore]
        public ICommand PrinResults_Command
        {
            get { return _printResults_Command ?? (_printResults_Command = new ICommandBase(() => PrintResults())); }
        }

        [XmlIgnore]
        public ICommand SelectSourcePathCommand
        {
            get { return selectSourcePathCommand ?? (selectSourcePathCommand = new ICommandBase(() => SelectSource())); }
        }
        [XmlIgnore]
        public ICommand SelectDestinationPathCommand
        {
            get { return selectDestinationPathCommand ?? (selectDestinationPathCommand = new ICommandBase(() => SelectDestination())); }
        }
        [XmlIgnore]
        public ICommand CopyFilesCommand
        {
            get { return copyFilesCommand ?? (copyFilesCommand = new ICommandBase(() => StartCopyFiles())); }
        }
        #endregion //Public Commands
        #endregion //ICommands

        #region Private Fields
        //RandomFileSelectorModel currentModel;
        #endregion //Private Fields

        #region Public Properties
        //RandomFileSelectorModel CurrentModel
        //{
        //    get { return currentModel; }
        //    set
        //    {
        //        currentModel = value;
        //        Notify(this, "CurrentModel");
        //    }
        //}
        #endregion // Public Properties

        #region Local Variables
        private long sourceSizeBytes;
        private long destinationSizeBytes;
        #endregion // Local Variables

        #region Constructor
        public RandomFileSelectorViewModel()
        {
            sourceSizeBytes = 0;
            destinationSizeBytes = 0;
        }
        #endregion //Constructor

        #region ToolBar Methods
        private void NewSettings()
        {
            // MessageBox.Show(this.ToString() + "  New");
            MessageBox.Show("This feature is not currently implemented");
        }
        private void OpenSettings()
        {
            //  MessageBox.Show(this.ToString() + "  Open");
            MessageBox.Show("This feature is not currently implemented");
        }
        private void SaveSettings()
        {
            // MessageBox.Show(this.ToString() + "  Save");
            MessageBox.Show("This feature is not currently implemented");
        }
        private void ExportResults()
        {
            // MessageBox.Show(this.ToString() + "  Export");
            MessageBox.Show("This feature is not currently implemented");
        }
        private void PrintResults()
        {
            //  MessageBox.Show(this.ToString() + "  Print");
            MessageBox.Show("This feature is not currently implemented");
        }
        #endregion

        #region Private Methods
        private void SelectSource()
        {
            Workspace.ResetColors();
            Workspace.ResetCopyright();
            //FolderBrowserDialog sucks. 
            //TODO: Make a custom file&folder browser to replace this with.
            System.Windows.Forms.FolderBrowserDialog FBD = new System.Windows.Forms.FolderBrowserDialog();
            FBD.ShowDialog();
            if (!string.IsNullOrWhiteSpace(FBD.SelectedPath))
            {
                SourcePath = FBD.SelectedPath;
                MeasureSourceSize();
            }
        }

        private void SelectDestination()
        {
            Workspace.ResetColors();
            Workspace.ResetCopyright();
            System.Windows.Forms.FolderBrowserDialog FBD = new System.Windows.Forms.FolderBrowserDialog();
            FBD.ShowDialog();
            if (!string.IsNullOrWhiteSpace(FBD.SelectedPath))
            {
                DestinationPath = FBD.SelectedPath;
                MeasureDestinationSize();
            }
        }

        private void StartCopyFiles()
        {
            //Change colors, check for errors, copy files
            if (CheckInputs())
            {
                Workspace.BackgroundColor = Workspace.GoodColor;
                Workspace.BorderColor = Workspace.GoodColor;

                CopyFiles();
            }
        }

        private void CopyFiles()
        {
            //TODO: make async process and add these features:
            /*
             * Display and select file types e.g. "*.mp3, *.mp4" etc
             * Build list of avalable files in source with the selected file type(s)
             * Measuere size avalible in destination
             * build new list of randomly selected files that total size is <= avalible/ allocated space
             * copy that new list
             */

        }
        private void MeasureSourceSize()
        {
            //Foreach *.mp3 in Source folder(s)
            //Add each .mp3 to an observable collection and measure the total size of those files
            //using random number generator select files from that list and add to new list that is smaller in size than destinationSizeBytes. 
            //Copy files in the randomlist to the destination folder.
            GetListOfSourceFiles();

        }
        private void MeasureDestinationSize()
        {
            destinationSizeBytes = GetAvailableFreeSpace(Path.GetPathRoot(DestinationPath));
            DestinationSize = ((destinationSizeBytes / 1024f) / 1024f).ToString() + " mb";
        }
        private void GetListOfSourceFiles()
        {
            string[] sourceFileList = Directory.GetFiles(SourcePath, FileExtensionType, SearchOption.AllDirectories);
            long totalSourceSize = 0;
            foreach (string sourceFile in sourceFileList)
            {
                FileInfo _fileInfo = new FileInfo(sourceFile);
                totalSourceSize = totalSourceSize + _fileInfo.Length;
            }
           // SourceSize = totalSourceSize.ToString();
            SourceSize = ((totalSourceSize / 1024f) / 1024f).ToString() + " mb";
        }
        private long GetAvailableFreeSpace(string driveName)
        {
            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady && drive.Name == driveName)
                {
                    return drive.AvailableFreeSpace;
                }
            }
            return -1;
        }
        private bool CheckInputs()
        {
            if (SourcePath == "")
            {
                Workspace.BackgroundColor = Workspace.ErrorColor;
                Workspace.BorderColor = Workspace.ErrorColor;
                Workspace.CopyrightLabel = "Error! Please select a Source Folder!";
                return false;
            }
            else if (DestinationPath == "")
            {
                Workspace.BackgroundColor = Workspace.ErrorColor;
                Workspace.BorderColor = Workspace.ErrorColor;
                Workspace.CopyrightLabel = "Error! Please select a Destination Folder!";
                return false;
            }
            return true;
        }
        #endregion //Private Methods
    }
}
