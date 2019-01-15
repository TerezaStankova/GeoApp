using SQLite;
using System.ComponentModel;

namespace XamApp.Models
{
    [Table("Contact")]
    public class Contact : INotifyPropertyChanged
    {
        private int Id;
        [PrimaryKey, AutoIncrement]
        public int ID
        {
            get
            {
                return Id;
            }
            set
            {
                this.Id = value;
                OnPropertyChanged(nameof(ID));
            }
        }
        private string _Name;
        [NotNull, MaxLength(100)]
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                this._Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        private string _phoneNumber;
        [NotNull, MaxLength(50)]
        public string PhoneNumber
        {
            get
            {
                return _phoneNumber;
            }
            set
            {
                this._phoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this,
              new PropertyChangedEventArgs(propertyName));
        }
    }
}
