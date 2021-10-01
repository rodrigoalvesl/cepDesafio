using cepDesafio.Models;
using PCLExt.FileStorage;
using PCLExt.FileStorage.Folders;
using SQLite;
using System.Collections.Generic;
using System.Linq;

namespace cepDesafio.Models

{
    public class DatabaseHelper
    {
        static SQLiteConnection sqliteconnection;
        public const string DbFileName = "people.db3";

        public DatabaseHelper()
        {
            var pasta = new LocalRootFolder();
            var arquivo = pasta.CreateFile(DbFileName, CreationCollisionOption.OpenIfExists);
            sqliteconnection = new SQLiteConnection(arquivo.Path);
            sqliteconnection.CreateTable<Ceps>();
        }

        public List<Ceps> GetAllCepsData()
        {
            return (from data in sqliteconnection.Table<Ceps>()
                    select data).ToList();
        }

        public Ceps GetCepData(string cep)
        {
            return sqliteconnection.Table<Ceps>().FirstOrDefault(t => t.Cep == cep);
        }

        public void InsertCep(Ceps Cep)
        {
            sqliteconnection.Insert(Cep);
        }
    }
}