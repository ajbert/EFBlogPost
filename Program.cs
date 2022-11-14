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
            string input;
            do
            {
                Console.WriteLine("1. Display Blogs");
                Console.WriteLine("2. Add Blog");
                Console.WriteLine("3. Display Posts");
                Console.WriteLine("4. Add Post");
                Console.WriteLine("Enter q for quit");
                input = Console.ReadLine();

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
                            
                            try
                            {
                                Console.WriteLine("Enter Blog ID of the blog you want displayed");
                                id = Convert.ToInt32(Console.ReadLine());
                                blog = db.Blogs.Where(x => x.BlogId == id).FirstOrDefault();

                                Console.WriteLine($"Posts for Blog {blog.Name}\n");

                                foreach (var p in blog.Posts)
                                {
                                    System.Console.WriteLine($"\tPost {p.PostId} {p.Title} \n {p.Content}\n");

                                }
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("There was an error with the Blog ID");
                               
                            }                          
                                                                                 

                        }
                        break;

                    case "4":

                        try
                        {
                            Console.WriteLine("Enter the Blog ID of the blog you want to add the post to");
                            id = Convert.ToInt32(Console.ReadLine());
                            var post = new Post();

                            post.BlogId = id;

                            Console.WriteLine("Enter the title of your post");
                            var postTitle = Console.ReadLine();


                            post.Title = postTitle;

                            Console.WriteLine("Enter your post");
                            var postContent = Console.ReadLine();
                            post.Content = postContent;



                            using (var db = new BlogContext())
                            {
                                db.Posts.Add(post);
                                db.SaveChanges();
                            }
                        }
                        catch (Exception)
                        {

                            Console.WriteLine("The was an error accessing the blog");
                        }
                        
                        break;
                }


            } while (input != "q");
            

        }
    }
}
