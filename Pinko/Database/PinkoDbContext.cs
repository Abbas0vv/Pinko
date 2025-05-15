using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pinko.Database.Models;
using Pinko.Database.Models.Account;

namespace Pinko.Database;

public class PinkoDbContext : IdentityDbContext<PinkoUser, PinkoRole, int>
{
    public PinkoDbContext(DbContextOptions<PinkoDbContext> options) : base(options) { }

    public DbSet<Employee> Employees { get; set; }

}
