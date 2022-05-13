using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogFactsSamples.Models; 
using SQLite;

namespace DogFactsSamples.Data
{
    public class DogFactsSamplesDatabase
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public DogFactsSamplesDatabase()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(MyFact).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(MyFact)).ConfigureAwait(false);
                }
                initialized = true;
            }
        }

        public Task<List<MyFact>> GetItemsAsync()
        {
            return Database.Table<MyFact>().ToListAsync();
        }

        public Task<MyFact> GetItemAsync(int id)
        {
            return Database.Table<MyFact>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(MyFact item)
        {
            if (item.ID != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }

        public Task<int> InsertList(IEnumerable<MyFact> items)
        {
            return Database.InsertAllAsync(items);
        }

        public Task<int> DeleteItemAsync(MyFact item)
        {
            return Database.DeleteAsync(item);
        }
        public Task<int> ClearAllAsync()
        {
            return Database.DeleteAllAsync<MyFact>();
        }
    }
}
