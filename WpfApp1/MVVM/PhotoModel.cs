using System;
using System.ComponentModel;
using System.Windows.Input;

namespace WpfApp1
{
    public class PhotoModel : INotifyPropertyChanged
    {
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private string _sourceURL;
        public string SourceURL
        {
            get { return _sourceURL; }
            set
            {
                _sourceURL = value;
                OnPropertyChanged(nameof(SourceURL));
            }
        }
        public DateTime AddedTime { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
