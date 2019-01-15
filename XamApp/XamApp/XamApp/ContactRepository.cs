using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XamApp.Models;
using SQLite;
using System.Collections.ObjectModel;

namespace XamApp
{  

    public class ContactRepository
    {
        public static IList<Contact> Contacts { get; set; }
        SQLiteAsyncConnection database;
        public string StatusMessage { get; set; }

        public ContactRepository(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Contact>().Wait();
            Contacts = new ObservableCollection<Contact>();

            
            
        }

        public Task<List<Contact>> GetItemsAsync()
        {
            return database.Table<Contact>().ToListAsync();
        }

        public Task<List<Contact>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<Contact>("SELECT * FROM [Contact] WHERE [Done] = 0");
        }

        public Task<Contact> GetItemAsync(int id)
        {
            return database.Table<Contact>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Contact item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Contact item)
        {
            return database.DeleteAsync(item);
        }

        public async Task AddNewContactAsync(string name, string phoneNumber)
        {
            int result = 0;
            try
            {
                //basic validation to ensure a name was entered
                if (string.IsNullOrEmpty(name))
                    throw new Exception("Valid name required");

                if (string.IsNullOrEmpty(phoneNumber))
                    throw new Exception("Valid phone number required");

                Contact contact = new Contact { Name = name, PhoneNumber = phoneNumber };
                Contacts.Add(contact);

                result = await database.InsertAsync(contact);
                

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
                return await database.Table<Contact>().ToListAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }

            return new List<Contact>();
        }
    }
}
