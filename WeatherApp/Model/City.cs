using System.ComponentModel;

namespace WeatherApp.Model
{
    public class Area : INotifyPropertyChanged
    {
        private string id;

        public string ID
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("ID");
            }
        }

        private string localizedName;

        public string LocalizedName
        {
            get { return localizedName; }
            set
            {
                localizedName = value;
                OnPropertyChanged("LocalizedName");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    public class City : INotifyPropertyChanged
    {
        private string key;

        public string Key
        {
            get { return key; }
            set
            {
                key = value;
                OnPropertyChanged("Key");
            }
        }

        private string localizedName;

        public string LocalizedName
        {
            get { return localizedName; }
            set
            {
                localizedName = value;
                OnPropertyChanged("LocalizedName");
            }
        }
        private Area country;

        public Area Country
        {
            get { return country; }
            set
            {
                country = value;
                OnPropertyChanged("Country");
            }
        }

        private Area administrativeArea;

        public Area AdministrativeArea
        {
            get { return administrativeArea; }
            set
            {
                administrativeArea = value;
                OnPropertyChanged("AdministrativeArea");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
