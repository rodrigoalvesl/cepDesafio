using cepDesafio.Models;
using System.Collections.Generic;


namespace cepDesafio.Services
{
    public interface ICepRepositorio
    {
        List<Ceps> GetAllCepsData();
        Ceps GetCepData(string cep);
        void InsertCep(Ceps cep);
    }
}