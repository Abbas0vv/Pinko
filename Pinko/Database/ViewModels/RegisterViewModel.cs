using System.ComponentModel.DataAnnotations;

namespace Pinko.Database.ViewModels;

public class RegisterViewModel
{
    [MinLength(3)]
    public string Name { get; set; }

    [MinLength(3)]
    public string Surname { get; set; }

    public string Username { get; set; }

    [MinLength(3), DataType(DataType.EmailAddress), RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
    public string Email { get; set; }

    [DataType(DataType.Password)]
    public string Password { get; set; }

    [DataType(DataType.Password), Compare(nameof(Password))]
    public string ConfirmPassword { get; set; }
}
