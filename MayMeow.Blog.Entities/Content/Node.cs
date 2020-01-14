using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using MayMeow.Blog.Entities.Identity;
using MayMeow.Blog.Entities.Taxonomy;

namespace MayMeow.Blog.Entities.Content
{
    public class Node
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string FeaturedImage { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        
        public string AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public ApplicationUser Author { get; set; }
        
        public List<Label> Labels { get; set; }
    }
}