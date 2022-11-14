using EFBlogPost.Models;
using System;
using System.Linq;

namespace EFBlogPost
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int id;

            Console.WriteLine("1. Display Blogs");
            Console.WriteLine("2. Add Blog");
            Console.WriteLine("3. Display Posts");
            Console.WriteLine("4. Add Post");

            var input = Console.ReadLine();

            switch (input)
            {   
                case "1":
                    // display blog

                    using (var db = new BlogContext())
                    {
                        foreach (var b in db.Blogs)
                        {
                            System.Console.WriteLine($"Blog: {b.BlogId}: {b.Name}");
                        }
                    }
                    
                    break;

                case "2":
                    // add a blog to database
            Console.WriteLine("Enter your Blog name");
                    var blogName = Console.ReadLine();


                    var blog = new Blog();
                    blog.Name = blogName;

                    // save blog to database
                    using (var db = new BlogContext())
                    {
                        db.Blogs.Add(blog);
                        db.SaveChanges();
                    }
                    break;

                    case "3":
                    using (var db = new BlogContext())
                    {
                        // get blog id from user
                        Console.WriteLine("Enter Blog ID");
                        id = Convert.ToInt32(Console.ReadLine());

                        blog = db.Blogs.Where(x => x.BlogId == id).FirstOrDefault();

                        Console.WriteLine($"Posts for Blog {blog.Name}");

                        foreach (var p in blog.Posts)
                        {
                            System.Console.WriteLine($"\tPost {p.PostId} {p.Title} \n {p.Content}");

                        }
                    }
                    break;

                    case "4":
                    

                    Console.WriteLine("Enter the title of your post");
                    var postTitle = Console.ReadLine();

                    var post = new Post();
                    post.Title = postTitle;

                    Console.WriteLine("Enter your post");
                    var postContent = Console.ReadLine();
                    post.Content = postContent;

                    Console.WriteLine("Enter the Blog ID of the blog you want to add the post to");
                    id = Convert.ToInt32(Console.ReadLine());

                    post.BlogId = id;

                    using (var db = new BlogContext())
                    {
                        db.Posts.Add(post);
                        db.SaveChanges();
                    }
                    break;

                  


            }





        }
    }
}
