using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Datos;
using Microsoft.AspNetCore.Identity;
using Entity;
using exposoftwaredotnet.Models;
using exposoftwaredotnet.Services;

namespace ExpoSoftware.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ITokenGenerator _tokenGenerator;

        public UsersController(UserManager<User> userManager,
            SignInManager<User> signInManager, ITokenGenerator tokenGenerator)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenGenerator = tokenGenerator;
        }
        //[User/Post]
        [HttpPost]
        [AllowAnonymous]

        public async Task<ActionResult<UsuarioViewModel>> PostApplicationUser([FromBody]UsuarioInputModel applicationUser)
        {
            var user = new User
            {
                UserName = applicationUser.NombreUser,
                Email = applicationUser.Mail,
                Rol = applicationUser.Rol
            };

            var result = await _userManager.CreateAsync(user, applicationUser.Password);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("UsuarioYaTomado", "El usuario ya esta tomado po otra persona");
                return Conflict(ModelState);
            }

            return new UsuarioViewModel

            {
                NombreUser = user.UserName,
                Mail = user.Email,
                Token = _tokenGenerator.GenerateToken(user.UserName, user.Rol),
                Rol = user.Rol
            };

        }

        [HttpPost("[action]")]
        [AllowAnonymous]

        public async Task<ActionResult<UsuarioViewModel>> Login([FromBody] LoginRequest login)
        {
            var user = await _userManager.FindByNameAsync(login.NombreUser);

            if (user is null)
            {
                user = await _userManager.FindByEmailAsync(login.NombreUser);

                if (user is null)
                    return BadRequest();
            }

            var result = await _signInManager.PasswordSignInAsync(user, login.Password, false, false);

            if (!result.Succeeded)
            {
                ModelState.AddModelError("ContraseñaInvalida", "La contraseña digitada no es correcta");
                return BadRequest(ModelState);
            }

            return new UsuarioViewModel
            {
                NombreUser = user.UserName,
                Mail = user.Email,
                Token = _tokenGenerator.GenerateToken(user.UserName, user.Rol),
                Rol = user.Rol
            };
        }

    }
}