using MayMeow.Blog.Entities.Identity;
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
    }
}