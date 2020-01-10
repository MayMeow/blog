using MayMeow.Blog.Entities.Content;
using MayMeow.Blog.Entities.Identity;
using MayMeow.Blog.Entities.Taxonomy;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MayMeow.Blog.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
         public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
         
         public DbSet<Node> Nodes { get; set; }
         public DbSet<Label> Labels { get; set; }
         public DbSet<LabelNode> LabelNodes { get; set; }
    }
}