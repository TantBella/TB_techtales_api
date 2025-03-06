using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using tb_techtales_api.Models;
using System.Threading.Tasks;

namespace tb_techtales_api.Controllers
{
    [Route("Admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }


        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] PostUser postUser)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = postUser.Username, Email = postUser.Email };
                var result = await _userManager.CreateAsync(user, postUser.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return Ok("Användaren skapades och inloggades.");
                }
                else
                {
                    return BadRequest("Kunde inte skapa användaren: " + string.Join(", ", result.Errors));
                }
            }
            return BadRequest("Ogiltiga data.");
        }
    


[HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.Username);
                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
                    if (result.Succeeded)
                    {
                        return Ok("Inloggning lyckades.");
                    }
                    else
                    {
                        return Unauthorized("Fel lösenord.");
                    }
                }
                else
                {
                    return NotFound("Användaren finns inte.");
                }
            }
            return BadRequest("Felaktig inloggningsdata.");
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok("Utloggning lyckades.");
        }
    }
}
