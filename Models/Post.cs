﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFBlogPost.Models
{
    public class Post
    {
       public int PostId { get; set; }          
       public string Title { get; set; }
       
       public string Content { get; set; }

       public int BlogId { get; set; }

       //enity framework navigation property

       public virtual Blog Blog { get; set; } 
    }
}