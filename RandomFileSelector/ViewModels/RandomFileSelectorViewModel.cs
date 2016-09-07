using System;
using System.Collections.Generic;
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

        #region Constructor
        public RandomFileSelectorViewModel()
        {
           // CurrentModel = new RandomFileSelectorModel();
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

    }
}
