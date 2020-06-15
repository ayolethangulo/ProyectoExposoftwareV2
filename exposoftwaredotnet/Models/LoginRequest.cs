using System.Diagnostics;
using System.Reflection.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Linq;
using System.Threading.Tasks;
using Entity;

namespace exposoftwaredotnet.Models
{
    public class LoginRequest
    {
        public string NombreUser { get; set; }
        public string Password { get; set; }
    }
}