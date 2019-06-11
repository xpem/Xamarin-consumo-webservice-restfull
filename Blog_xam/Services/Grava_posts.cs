using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;
using Xamarin.Forms;


namespace Blog_xam.Services
{
    public class Grava_posts
    {
        public void Cadastra_posts(ObservableCollection<Modelos.Posts.Post> lista)
        {

            ((App)Application.Current).Conexao.Execute("delete from Postoffline");//

            foreach (Modelos.Posts.Post post in lista)
            {
                var query = $"insert into Postoffline(Id,userId,title,body) values ('" + post.Id + "','" + post.userId + "','" + post.title + "','" + post.body + "')";
                ((App)Application.Current).Conexao.Execute(query);//
            }

        }

        public ObservableCollection<Modelos.Posts.Post> Seleciona_post(out bool recuperou_dados)
        {
            recuperou_dados = true;
            ObservableCollection<Modelos.Posts.Post> lista = new ObservableCollection<Modelos.Posts.Post>();
            List<Modelos.Posts.Post> ret_lista = ((App)Application.Current).Conexao.Query<Modelos.Posts.Post>("select Id,userId,title,body from Postoffline");//((App)Application.Current).

            if (ret_lista.Count > 0)
            {
                foreach (Modelos.Posts.Post posts in ret_lista)
                {
                    lista.Add(posts);
                }
            }
            else recuperou_dados = false;

            return lista;

        }
    }
}
