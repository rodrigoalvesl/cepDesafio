using cepDesafio.Services;
using cepDesafio.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Ceps = cepDesafio.Models.Ceps;

namespace cepDesafio.ViewModels
{
    public class ListaCepVM : BaseViewModel
    {
        private Ceps _selectedCep;
        public Command<Ceps> CepTapped { get; }

        public Ceps SelectedCep
        {
            get => _selectedCep;
            set
            {
                SetProperty(ref _selectedCep, value);
                OnItemSelected(value);
            }
        }

        public ListaCepVM()
        {
            _cepRepositorio = new CepRepositorio();
            _listaCeps = new List<Ceps>();

            CepTapped = new Command<Ceps>(OnItemSelected);
        }

        public void OnAppearing()
        {
            try
            {
                SelectedCep = null;

                _listaCeps.Clear();
                var listaBD = _cepRepositorio.GetAllCepsData();

                if (listaBD.Count > 0)
                {
                    listaBD = listaBD.OrderByDescending(x => x.Id).ToList();
                    _listaCeps.AddRange(listaBD);
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        async void OnItemSelected(Ceps item)
        {
            try
            {
                if (item == null)
                    return;

                await Shell.Current.GoToAsync($"{nameof(DetalhesListaCep)}?{nameof(DetalheListaCep.ItemCep)}={item.Cep}");
            }
            catch (Exception )
            {
                throw;
            }

        }
    }
}
