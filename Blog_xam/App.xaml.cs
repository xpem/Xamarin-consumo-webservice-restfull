using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using PCLExt.FileStorage;
using PCLExt.FileStorage.Folders;
using SQLite;

namespace Blog_xam
{
    public partial class App : Application
    {

        public SQLiteConnection Conexao { get; private set; }

        public App()
        {
            InitializeComponent();
            //Services.Data_acess da = new Services.Data_acess();
            //da.Consome_ws();

            var pasta = new LocalRootFolder();
            var arquivo = pasta.CreateFile("banco.db", CreationCollisionOption.OpenIfExists);
            Conexao = new SQLiteConnection(arquivo.Path, SQLiteOpenFlags.ReadWrite);

            //criação das tabelas de persistencia de dados
            Conexao.Execute("create table if not exists Postoffline (Id integer, userId text, title text, body text)");


        //         public int Id { get; set; }
        //public int userId { get; set; }
        //public string title { get; set; }
        //public string body { get; set; }

        MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
