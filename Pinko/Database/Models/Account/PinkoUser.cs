using Microsoft.AspNetCore.Identity;

namespace Pinko.Database.Models.Account;

public class PinkoUser : IdentityUser<int>
{
    public string Name { get; set; }
    public string Surname { get; set; }
}
