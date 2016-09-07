using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomFileSelector
{
    public abstract class INotifyBase : INotifyPropertyChanged
    {
        #region Public Delegates
        //CA1009 says these events are out of compliance... I need to research that farther, and update this INotifyBase 
        public delegate void PropertyHistoryChangedEventHandler(object sender, PropertyChangingEventArgs e, object fromValue, object toValue);
        public delegate void PropertyValueChangedEventHandler(object sender, PropertyChangedEventArgs e, object value);
        #endregion

        #region Public Events
        public event PropertyHistoryChangedEventHandler PreviewPropertyHistoryChange;
        public event PropertyHistoryChangedEventHandler PropertyHistoryChanged;

        public event PropertyValueChangedEventHandler PreviewPropertyValueChange;
        public event PropertyValueChangedEventHandler PropertyValueChanged;

        public event PropertyChangedEventHandler PreviewPropertyChange;
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Notify Handlers
        public void PreviewNotify(object propertyObject, string propertyName, object fromValue, object toValue)
        {
            PreviewPropertyHistoryChange(propertyObject, new PropertyChangingEventArgs(propertyName), fromValue, toValue);
            PreviewNotify(propertyObject, propertyName, toValue);
        }

        public void Notify(object propertyObject, string propertyName, object fromValue, object toValue)
        {
            PropertyHistoryChanged(propertyObject, new PropertyChangingEventArgs(propertyName), fromValue, toValue);
            Notify(propertyObject, propertyName, toValue);
        }

        public void PreviewNotify(object propertyObject, string propertyName, object propertyValue)
        {
            PreviewPropertyValueChange?.Invoke(propertyObject, new PropertyChangedEventArgs(propertyName), propertyValue);
            PreviewNotify(propertyObject, propertyName);
        }

        public void Notify(object propertyObject, string propertyName, object propertyValue)
        {
            PropertyValueChanged?.Invoke(propertyObject, new PropertyChangedEventArgs(propertyName), propertyValue);
            Notify(propertyObject, propertyName);
        }

        public void PreviewNotify(object propertyObject, string propertyName)
        {
            PreviewPropertyChange?.Invoke(propertyObject, new PropertyChangedEventArgs(propertyName));
        }

        public void Notify(object propertyObject, string propertyName)
        {
            PropertyChanged?.Invoke(propertyObject, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
