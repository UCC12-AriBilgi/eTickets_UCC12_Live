using eTickets.Data;
using eTickets.Data.Static;
using eTickets.Models;
using eTickets.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace eTickets.Controllers
{
    public class AccountController : Controller
    {
        // 55.1
        private readonly AppDbContext _context;

        private readonly UserManager<ApplicationUser> _userManager;

        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, AppDbContext context)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }



        public async Task<IActionResult> Login()
        {
            var response = new LoginVM();

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid)
            {
                return View(loginVM);
            }

            var user = await _userManager.FindByEmailAsync(loginVM.EmailAddress);

            if (user != null)
            {
                // şifreyi kontrol etmem lazım
                var passwordCheck=await _userManager.CheckPasswordAsync(user, loginVM.Password);

                if (passwordCheck)
                {
                    // eğer password doğruysa
                    var result = await _signInManager.PasswordSignInAsync(user, loginVM.Password, false, false);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Movies");

                    }
                }

                TempData["Error"] = "Yanlış kullanıcı bilgileri...Lütfen kontrol ediniz...";

                return View(loginVM);
            }


            TempData["Error"] = "Yanlış kullanıcı bilgileri...Lütfen kontrol ediniz...";

            return View(loginVM);

        }

        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid)
            {
                return View(registerVM);
            }

            var user = await _userManager.FindByEmailAsync(registerVM.EmailAddress);

            if (user != null)
            {
                // demek ki benim kayıt etmek istediğim email bilgisi daha önceden kayıtlıymış.

                TempData["Error"] = "Bu mail adresi kullanımda. Lütfen başka bir mail adresi giriniz....";

                return View(registerVM);
            }

            var newUser = new ApplicationUser()
            {
                FullName = registerVM.FullName,
                Email = registerVM.EmailAddress,
                UserName = registerVM.EmailAddress
            };

            var newUserResponse = await _userManager.CreateAsync(newUser, registerVM.Password);

            if (newUserResponse.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, UserRoles.User);

            }

            return View("Kayıt işlemi başarılı");


        }


    }
}
