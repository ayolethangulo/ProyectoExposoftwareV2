using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Entity
{
    public class User:IdentityUser
    {
      public string  Rol { get; set; }
    }
}