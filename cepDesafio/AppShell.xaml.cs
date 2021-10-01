using cepDesafio.ViewModels;
using cepDesafio.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace cepDesafio
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(CepsPage), typeof(CepsPage));
            Routing.RegisterRoute(nameof(DetalhesListaCep), typeof(DetalhesListaCep));
        }

    }
}
