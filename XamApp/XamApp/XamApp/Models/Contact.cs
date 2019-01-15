using SQLite;

namespace XamApp.Models
{
    
    public class Contact
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(50)]
        public string PhoneNumber { get; set; }
    }
}
