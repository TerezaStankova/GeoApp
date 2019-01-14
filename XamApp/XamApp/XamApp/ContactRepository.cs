using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XamApp.Models;
using SQLite;

namespace XamApp
{
    public class ContactRepository
    {
        SQLiteAsyncConnection conn;
        public string StatusMessage { get; set; }

        public ContactRepository(string dbPath)
        {
            conn = new SQLiteAsyncConnection(dbPath);
            conn.CreateTableAsync<Contact>().Wait();
        }

        public async Task AddNewContactAsync(string name)
        {
            int result = 0;
            try
            {
                //basic validation to ensure a name was entered
                if (string.IsNullOrEmpty(name))
                    throw new Exception("Valid name required");

                result = await conn.InsertAsync(new Contact { Name = name });

                StatusMessage = string.Format("{0} record(s) added [Name: {1})", result, name);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", name, ex.Message);
            }
        }

        public async Task<List<Contact>> GetAllContactsAsync()
        {
            try
            {
                return await conn.Table<Contact>().ToListAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<Contact>();
        }
    }
}
