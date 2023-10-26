#pragma warning disable CS8612
#pragma warning disable CS8618
using System.ComponentModel;

namespace Task2.Model
{
    public class Notifier : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnPropertyChanged(string[] propertyNames)
        {
            foreach (string propertyName in propertyNames)
                OnPropertyChanged(propertyName);
        }
    }
}
