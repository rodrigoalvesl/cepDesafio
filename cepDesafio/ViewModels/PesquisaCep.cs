using cepDesafio.Models;
using cepDesafio.Services;
using Newtonsoft.Json;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace cepDesafio.ViewModels
{
    public class PesquisaCep : BaseViewModel
    {
        private string _CEP;
        public const string CEPPropName = "CEP";
        public string CEP
        {
            get { return this._CEP; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    this._CEP = Regex.Replace(value, "[^0-9]", string.Empty);

                    this._CEP = this._CEP.Substring(0, this._CEP.Length > 8 ? 8 : this._CEP.Length);


                }
                else
                    this._CEP = value;
            }
        }


        private Command _BuscarCep;
        public Command BuscarCep
        {
            get
            {
                return this._BuscarCep ?? (this._BuscarCep = new Command(async () => await BuscarCepExecute(), () => { return !this.IsBusy; }));
            }
        }

        public PesquisaCep()
        {
            _cepRepositorio = new CepRepositorio();
        }

        public async Task BuscarCepExecute()
        {
            try
            {
                if (this.IsBusy)
                    return;

                this.IsBusy = true;

                this.BuscarCep.ChangeCanExecute();

                if (string.IsNullOrWhiteSpace(this._CEP))
                    await Application.Current.MainPage.DisplayAlert("App Consulta", "Informe um CEP.", "Ok");
                else
                {

                    using (var _client = new System.Net.Http.HttpClient())
                    {
                        //Pesquisa o Cep digitado no webservice
                        using (var _resposta = await _client.GetAsync($"https://viacep.com.br/ws/{this._CEP}/json/"))
                        {

                            if (!_resposta.IsSuccessStatusCode)
                            {
                                await Application.Current.MainPage.DisplayAlert("App Consulta", "CEP inválido.\nTente novamente.", "Ok");
                                return;
                            }

                            var _respostaContent = await _resposta.Content.ReadAsStringAsync();

                            if (_respostaContent.Contains("\"erro\": true"))
                            {
                                await Application.Current.MainPage.DisplayAlert("App Consulta", "CEP inválido.\nTente novamente.", "Ok");
                                return;
                            }

                            var cepRetorno = JsonConvert.DeserializeObject<Ceps>(_respostaContent);

                            _respostaContent = _respostaContent.Replace("\"", string.Empty).Replace("{", string.Empty).Replace("}", string.Empty).Replace(",", string.Empty);


                            //Exibe o Cep encontrado e dá opção de gravar no banco local
                            bool gravar = await Application.Current.MainPage.DisplayAlert("CEP Encontrado!", _respostaContent, "Salvar", "Cancelar");

                            if (gravar)
                            {
                                var cepExite = _cepRepositorio.GetCepData(cepRetorno.Cep);

                                if (cepExite != null)
                                    await Application.Current.MainPage.DisplayAlert("App Consulta", "CEP já existente!\nTente novamente.", "Ok");
                                else
                                {
                                    _cepRepositorio.InsertCep(cepRetorno);
                                    await Application.Current.MainPage.DisplayAlert("App Consulta", "CEP foi salvo com sucesso!", "Ok");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                this.IsBusy = false;
                this.BuscarCep.ChangeCanExecute();
            }
        }
    }
}