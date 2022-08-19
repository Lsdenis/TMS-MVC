using System.ComponentModel.DataAnnotations;

namespace TestMVCApplication.Web.Models;

public class LoginViewModel
{
    [Required]
    public string Username { get; set; }
}