using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Collections.ObjectModel;
using Plugin.Connectivity;

namespace Blog_xam
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Post : ContentPage
    {

        public string title { get; set; }
        public string body { get; set; }

        public Post(Modelos.Posts.Post post_selecionado)
        {
            BindingContext = this;

            title = post_selecionado.title;
            body = post_selecionado.body;

            Services.Data_acess da = new Services.Data_acess();
            //cria a lista de comentários
            ObservableCollection<Modelos.Posts.Comments> lista = da.Consome_comments(post_selecionado.Id);

            InitializeComponent();

            Lst_com.ItemsSource = lista;
        

        }

    }
}