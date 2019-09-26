using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml.Serialization;

namespace RandomFileSelector
{
    /// <summary>
    /// 
    ///This dosn't seem to be an actual singleton, its looks like it is just a static class for this UI components.
    ///Need to read more about what that is and how to solve this problem better...
    /// 
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

        #region ICommands
        private static ICommand activateWindowCommand;
        private static ICommand deactivateWindowCommand;
        public static ICommand ActivateWindowCommand
        {
            get { return activateWindowCommand ?? (activateWindowCommand = new CommandHelper(() => ActivateWindow())); }
        }
        public static ICommand DeactivateWindowCommand
        {
            get { return deactivateWindowCommand ?? (deactivateWindowCommand = new CommandHelper(() => DeactivateWindow())); }
        }
        #endregion // ICommand

        #region Interface Variables
        private static SolidColorBrush _warningColor;
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

        private static SolidColorBrush deactivateBorderColorBrush;
        public static SolidColorBrush DeactivateBorderColorBrush
        {
            get { return deactivateBorderColorBrush; }
            set
            {
                if (value != deactivateBorderColorBrush)
                {
                    deactivateBorderColorBrush = value;
                    NotifyStaticPropertyChanged("DeactivateBorderColorBrush");
                };
            }
        }

        private static SolidColorBrush previousBorderColorBrush;
        public static SolidColorBrush PreviousBorderColorBrush
        {
            get { return previousBorderColorBrush; }
            set
            {
                if (value != previousBorderColorBrush)
                {
                    previousBorderColorBrush = value;
                    NotifyStaticPropertyChanged("PreviousBorderColorBrush");
                };
            }
        }

        private static Thickness windowBorderThickness;
        public static Thickness WindowBorderThickness
        {
            get { return windowBorderThickness; }
            set
            {
                if (value != windowBorderThickness)
                {
                    windowBorderThickness = value;
                    NotifyStaticPropertyChanged("WindowBorderThickness");
                };
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
            get { return _windowTitle; }
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
            DeactivateBorderColorBrush = new SolidColorBrush(Color.FromArgb(255, 186, 186, 186));
            PreviousBorderColorBrush = new SolidColorBrush(Color.FromArgb(255, 62, 120, 179));

            BackgroundColor = NormalColor;
            BorderColor = NormalColor;
            ForegroundColor = new SolidColorBrush(Color.FromArgb(255, 252, 252, 252));

            WindowTitle = "Random File Copier";
            CopyrightLabel = "Provided by: KWJ2010, All rights Reserved";
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
            WindowBorderThickness = new Thickness(1, 1, 1, 1);
        }
        public async static void ResetColors(int resetTimer)
        {
            await Task.Delay(resetTimer);
            ResetColors();
        }
        /// <summary>
        /// Resets the Copyright text
        /// </summary>
        public static void ResetCopyright()
        {
            CopyrightLabel = "Provided by: KWJ2010, All rights Reserved";
        }
        #region Window Activated and Deactivated
        public static void DeactivateWindow()
        {
            PreviousBorderColorBrush = BorderColor;
            BorderColor = DeactivateBorderColorBrush;
            BackgroundColor = DeactivateBorderColorBrush;
        }

        public static void ActivateWindow()
        {
            BorderColor = PreviousBorderColorBrush;
            BackgroundColor = PreviousBorderColorBrush;
        }
        #endregion //Window Activated and Deactivated
        #endregion //Public Methods
    }
}
