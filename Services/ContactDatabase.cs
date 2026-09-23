using SQLite;
using Contact = ContactBook.Models.Contact;

namespace ContactBook.Services
{
    public class ContactDatabase
    {
        private SQLiteAsyncConnection _database;

        public ContactDatabase()
        {
            var dbPath = Path.Combine(FileSystem.AppDataDirectory, "contacts.db3");
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Contact>().Wait();
        }

        public Task<List<Contact>> GetContactsAsync()
        {
            return _database.Table<Contact>().ToListAsync();
        }

        public Task<int> SaveContactAsync(Contact contact)
        {
            return _database.InsertAsync(contact);
        }

        public Task<int> UpdateContactAsync(Contact contact)
        {
            return _database.UpdateAsync(contact);
        }

        public Task<int> DeleteContactAsync(Contact contact)
        {
            return _database.DeleteAsync(contact);
        }
    }
}