using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace cepDesafio.Models
{
    public class Database
    {
        private readonly SQLiteAsyncConnection _database;

        public Database()
        {
        }

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Ceps>();

        }
        public Task<List<Ceps>> GetCepsAsync()
        {
            return _database.Table<Ceps>().ToListAsync();
        }

        public Task<int> SaveCepsAsync(Ceps ceps)
        {
            return _database.InsertAsync(ceps);
        }

        internal void InsertCep(Ceps cep)
        {
            throw new NotImplementedException();
        }
    }
}
