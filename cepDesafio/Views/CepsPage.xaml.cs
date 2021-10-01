using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace cepDesafio.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CepsPage : TabbedPage
    {
        public CepsPage()
        {
            InitializeComponent();
        }

        public object Cep { get; internal set; }
    }
}