using System.ComponentModel.DataAnnotations;

namespace TestMVCApplication.Web.Models;

public class CreateUserViewModel
{
    // https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations?view=net-6.0
    [Required]
    public string Username { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }
}