using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Pinko.Database.ViewModels;

public class UpdateEmployeeViewModel
{
    [MinLength(3)]
    public string Name { get; set; }
    [MinLength(3)]
    public string Surname { get; set; }
    [MinLength(5)]
    public string About { get; set; }
    public string Position { get; set; }
    [NotMapped]
    public IFormFile? File { get; set; }
}
