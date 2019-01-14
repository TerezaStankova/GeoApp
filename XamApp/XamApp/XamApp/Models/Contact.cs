using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace XamApp.Models
{
    class Contact
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(250), Unique]
        public string Name { get; set; }
        [MaxLength(250), Unique]
        public string PhoneNumber { get; set; }
    }
}
