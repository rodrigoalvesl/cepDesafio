using cepDesafio.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace cepDesafio.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Mapa: ContentPage
    {
        MapaCep _viewModel;

        public Mapa()
        {
            InitializeComponent();
            BindingContext = _viewModel = new MapaCep();
            
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}