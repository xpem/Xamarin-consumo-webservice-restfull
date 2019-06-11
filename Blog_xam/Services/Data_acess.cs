using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;

namespace Blog_xam.Services
{
   public class Data_acess
    {

       

        public ObservableCollection<Modelos.Posts.Post> Consome_posts()
        {
            ObservableCollection<Modelos.Posts.Post> lista = new ObservableCollection<Modelos.Posts.Post>();

            var requisicaoWeb = System.Net.WebRequest.CreateHttp("http://jsonplaceholder.typicode.com/posts");
            requisicaoWeb.Method = "GET";
            requisicaoWeb.UserAgent = "RequisicaoWebDemo";
            using (var resposta = requisicaoWeb.GetResponse())
            {
                var streamDados = resposta.GetResponseStream();
                StreamReader reader = new StreamReader(streamDados);
                object objResponse = reader.ReadToEnd();

                lista = JsonConvert.DeserializeObject<ObservableCollection<Modelos.Posts.Post>>(objResponse.ToString());

                streamDados.Close();
                resposta.Close();
            }
            return lista;

        }


        public ObservableCollection<Modelos.Posts.Comments> Consome_comments(int id)
        {
            ObservableCollection<Modelos.Posts.Comments> lista = new ObservableCollection<Modelos.Posts.Comments>();

            var requisicaoWeb = System.Net.WebRequest.CreateHttp("https://jsonplaceholder.typicode.com/comments?postId="+id);
            requisicaoWeb.Method = "GET";
            requisicaoWeb.UserAgent = "RequisicaoWebDemo";
            using (var resposta = requisicaoWeb.GetResponse())
            {
                var streamDados = resposta.GetResponseStream();
                StreamReader reader = new StreamReader(streamDados);
                object objResponse = reader.ReadToEnd();

                lista = JsonConvert.DeserializeObject<ObservableCollection<Modelos.Posts.Comments>>(objResponse.ToString());

                streamDados.Close();
                resposta.Close();
            }
            return lista;

        }

    }
}
