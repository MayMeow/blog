using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MayMeow.Blog.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
         public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
                    : base(options)
                {
                }
    }
}