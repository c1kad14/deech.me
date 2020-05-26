using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace deech.me.idp.data
{
    public class DeechIdentityDbContext : IdentityDbContext<IdentityUser>
    {
        public DeechIdentityDbContext(DbContextOptions<DeechIdentityDbContext> options) : base(options)
        {

        }
    }
}