using cepDesafio.Models;
using System.Collections.Generic;
namespace cepDesafio.Services
{
    public class CepRepositorio : ICepRepositorio
    {
        DatabaseHelper _databaseHelper;
        public CepRepositorio()
        {
            _databaseHelper = new DatabaseHelper();
        }

        public List<Ceps> GetAllCepsData()
        {
            return _databaseHelper.GetAllCepsData();
        }
        public Ceps GetCepData(string cep)
        {
            return _databaseHelper.GetCepData(cep);
        }
        public void InsertCep(Ceps cep)
        {
            _databaseHelper.InsertCep(cep);
        }
    }
}