using cepDesafio.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace cepDesafio.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaCep : ContentPage
    {
        ListaCepVM _viewModel;

        public ListaCep()
        {
            InitializeComponent();
            BindingContext = _viewModel = new ListaCepVM();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();

          
            this.ListCep.ItemsSource = _viewModel._listaCeps;
        }
    }
}