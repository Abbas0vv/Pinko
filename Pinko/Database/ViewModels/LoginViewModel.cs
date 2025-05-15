namespace Pinko.Database.ViewModels;

public class LoginViewModel
{
    public string UsernameOrEmail { get; set; }
    public string Password { get; set; }
    public bool IsPersistent { get; set; }
}
