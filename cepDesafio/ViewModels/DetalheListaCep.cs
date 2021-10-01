using cepDesafio.Services;
using System;
using Xamarin.Forms;

namespace cepDesafio.ViewModels
{
    [QueryProperty(nameof(ItemCep), nameof(ItemCep))]
    public class DetalheListaCep : BaseViewModel
    {
        private string itemcep;
        private string cep;
        private string logradouro;
        private string complemento;
        private string bairro;
        private string localidade;
        private string uf;
        private string ibge;
        private string ddd;

        public string Cep
        {
            get => cep;
            set => SetProperty(ref cep, value);
        }

        public string Logradouro
        {
            get => logradouro;
            set => SetProperty(ref logradouro, value);
        }

        public string Complemento
        {
            get => complemento;
            set => SetProperty(ref complemento, value);
        }

        public string Bairro
        {
            get => bairro;
            set => SetProperty(ref bairro, value);
        }

        public string Localidade
        {
            get => localidade;
            set => SetProperty(ref localidade, value);
        }

        public string UF
        {
            get => uf;
            set => SetProperty(ref uf, value);
        }
        public string Ibge
        {
            get => ibge;
            set => SetProperty(ref ibge, value);
        }
        public string DDD
        {
            get => ddd;
            set => SetProperty(ref ddd, value);
        }

        public string ItemCep
        {
            get
            {
                return itemcep;
            }
            set
            {
                itemcep = value;
                LoadCep(value);
            }
        }

        public DetalheListaCep()
        {
            this._cepRepositorio = new CepRepositorio();
        }

        public void LoadCep(string itemcep)
        {
            try
            {
                var item = _cepRepositorio.GetCepData(itemcep);

                Cep = item.Cep;
                Logradouro = item.Logradouro;
                Bairro = item.Bairro;
                Localidade = item.Localidade;

            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}