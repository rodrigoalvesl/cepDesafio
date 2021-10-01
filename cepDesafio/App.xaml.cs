using cepDesafio.Services;
using System.IO;
using Xamarin.Forms;
using System;
using cepDesafio.Models;

namespace cepDesafio
{
    // Esse código define uma propriedade Database que cria uma nova instância de Database como um singleton. Um caminho de arquivo local e o nome de arquivo, que representa onde armazenar o banco de dados,
    // são passados como o argumento para o construtor da classe Database.



    public partial class Application : Xamarin.Forms.Application
    {
        private static Database database;
        public static Database Database
        {
            get
            {
                if(database == null)
                {
                    database = new Database(Path.Combine(Environment.GetFolderPath(folder: Environment.SpecialFolder.LocalApplicationData), "people.db3"));
                }
                return database;
            }
        }
        public Application()
        {
            InitializeComponent();

            DependencyService.Register<CepRepositorio>();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}