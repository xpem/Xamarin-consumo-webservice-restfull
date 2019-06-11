using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using Plugin.Connectivity;

namespace Blog_xam
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {

            InitializeComponent();
                       
            carrega_lista();

            //para atualizar a lista com o push
            Lst_posts.RefreshCommand = new Command(() =>
            {
                carrega_lista();
                Lst_posts.IsRefreshing = false;
            });


        }


        public void carrega_lista()
        {

            //caso esteja off, montar a lista com o que tem no banco de dados off line.
            ObservableCollection<Modelos.Posts.Post> lista = new ObservableCollection<Modelos.Posts.Post>();
            //definições
            Services.Grava_posts da_grava_dados = new Services.Grava_posts();
            Services.Data_acess da = new Services.Data_acess();

            Lst_posts.ItemsSource = null;
            if (!CrossConnectivity.Current.IsConnected)
            {
                lista = da_grava_dados.Seleciona_post(out bool recuperacao_dados);
            }
            else
            {

                lista = da.Consome_posts();
                //cadastro dos dados offline
                da_grava_dados.Cadastra_posts(lista);
            }

            Lst_posts.ItemsSource = lista;
        }

        private void Lst_posts_ItemSelected_1(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                if (!CrossConnectivity.Current.IsConnected)
                {
                    DisplayAlert("Aviso", "Sem conexão com a internet", null, "Ok");
                }
                else
                {
                    Modelos.Posts.Post selectedItem = e.SelectedItem as Modelos.Posts.Post;
                    Lst_posts.SelectedItem = null;

                    Post page = new Post(selectedItem);
                    Navigation.PushModalAsync(page);
                }
            }
        }
    }
}
