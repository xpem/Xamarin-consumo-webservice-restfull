using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.ObjectModel;

namespace Blog_xam.Modelos
{
    public class Posts
    {
        public ObservableCollection<Post> Lista_posts;
        public class Post
        {
            public int Id { get; set; }
            public int userId { get; set; }
            public string title { get; set; }
            public string body { get; set; }
        }

        public ObservableCollection<Post> Lista_comments;

        public class Comments
        {
            public int postId { get; set; }
            public int id { get; set; }
            public string name { get; set; }
            public string email { get; set; }
            public string body { get; set; }
                
        }
    }
}
