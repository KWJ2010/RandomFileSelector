using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Xml.Serialization;

namespace RandomFileSelector
{
    /// <summary>
    /// Yes, static classes are not recomended over the Singleton pattern due to possible memory leaks among other reasons. 
    /// This class is different in that as long as this program is running, it will need the variables stored here as the MainWindow is bound to these properties.
    /// This is overkill for this program, but is a template I am using for a much larger program with many views and user controls that need to update features on
    /// the main interface to provide visual feedback to the user. A static workspace allows for that in a very simple and straightforward way.
    /// </summary>
    public static class Workspace
    {
        #region Static INotify Event
        public static event EventHandler<PropertyChangedEventArgs> StaticPropertyChanged;

        private static void NotifyStaticPropertyChanged(string propertyName)
        {
            StaticPropertyChanged?.Invoke(null, new PropertyChangedEventArgs(propertyName));
        }
        #endregion // Static INotify Event

        #region Interface Variables
        private static SolidColorBrush _warningColor;
        [XmlIgnore]
        public static SolidColorBrush WarningColor
        {
            get { return _warningColor; }
            set
            {
                if (value != _warningColor)
                {
                    _warningColor = value;
                    NotifyStaticPropertyChanged("WarningColor");
                }
            }
        }

        private static SolidColorBrush _errorColor;
        [XmlIgnore]
        public static SolidColorBrush ErrorColor
        {
            get
            {
                return _errorColor;
            }
            set
            {
                if (value != _errorColor)
                {
                    _errorColor = value;
                    NotifyStaticPropertyChanged("ErrorColor");
                }
            }
        }

        private static SolidColorBrush _normalColor;
        [XmlIgnore]
        public static SolidColorBrush NormalColor
        {
            get
            {
                return _normalColor;
            }
            set
            {
                if (value != _normalColor)
                {
                    _normalColor = value;
                    NotifyStaticPropertyChanged("NormalColor");
                }
            }
        }

        private static SolidColorBrush _goodColor;
        [XmlIgnore]
        public static SolidColorBrush GoodColor
        {
            get { return _goodColor; }
            set
            {
                if (value != _goodColor)
                {
                    _goodColor = value;
                    NotifyStaticPropertyChanged("GoodColor");
                }
            }
        }

        private static SolidColorBrush _backgroundColor;
        [XmlIgnore]
        public static SolidColorBrush BackgroundColor
        {
            get { return _backgroundColor; }
            set
            {
                if (value != _backgroundColor)
                {
                    _backgroundColor = value;
                    NotifyStaticPropertyChanged("BackgroundColor");
                }
            }
        }

        private static SolidColorBrush _borderColor;
        [XmlIgnore]
        public static SolidColorBrush BorderColor
        {
            get { return _borderColor; }
            set
            {
                if (value != _borderColor)
                {
                    _borderColor = value;
                    NotifyStaticPropertyChanged("BorderColor");
                }
            }
        }

        private static SolidColorBrush _foregroundColor;
        [XmlIgnore]
        public static SolidColorBrush ForegroundColor
        {
            get { return _foregroundColor; }
            set
            {
                if (value != _foregroundColor)
                {
                    _foregroundColor = value;
                    NotifyStaticPropertyChanged("ForegroundColor");
                }
            }
        }

        private static string _copyrightLabel;
        public static string CopyrightLabel
        {
            get { return _copyrightLabel; }
            set
            {
                if (value != _copyrightLabel)
                {
                    _copyrightLabel = value;
                    NotifyStaticPropertyChanged("CopyrightLabel");
                }
            }
        }

        private static string _windowTitle;
        public static string WindowTitle
        {
            get { return _copyrightLabel; }
            set
            {
                if (value != _windowTitle)
                {
                    _windowTitle = value;
                    NotifyStaticPropertyChanged("WindowTitle");
                }
            }
        }
        #endregion //Interface Variables

        #region Public Fields
        public static Random RandomNumber = new Random();
        #endregion // Public Fields

        public static void SetDefaultWorkspace()
        {
            WarningColor = new SolidColorBrush(Color.FromArgb(255, 238, 150, 25));
            ErrorColor = new SolidColorBrush(Color.FromArgb(255, 233, 136, 5));
            NormalColor = new SolidColorBrush(Color.FromArgb(255, 62, 120, 179));
            GoodColor = new SolidColorBrush(Color.FromArgb(255, 58, 165, 121));

            BackgroundColor = NormalColor;
            BorderColor = NormalColor;
            ForegroundColor = new SolidColorBrush(Color.FromArgb(255, 252, 252, 252));

            CopyrightLabel = "Provided by: KWJ2010, All rights Reserved";
            WindowTitle = "Randomized File Selector";
        }

        #region Public Methods
        /// <summary>
        /// Resets Interface colors to the default
        /// </summary>
        public static void ResetColors()
        {
            BackgroundColor = NormalColor;
            BorderColor = NormalColor;
            ForegroundColor = new SolidColorBrush(Color.FromArgb(255, 252, 252, 252));
        }
        /// <summary>
        /// Resets the Copyright text
        /// </summary>
        public static void ResetCopyright()
        {
            CopyrightLabel = "Provided by: KWJ2010, All rights Reserved";
        }
        #endregion //Public Methods
    }
}
