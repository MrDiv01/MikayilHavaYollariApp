using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MikayilHavaYollari.Models;

namespace MikayilHavaYollari.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password, bool rememberMe = false)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
                {
                    ModelState.AddModelError("", "Email ve sifre gereklidir");
                    return View();
                }

                // Email ile user'ı bul
                var user = await _userManager.FindByEmailAsync(email);
                if (user == null)
                {
                    ModelState.AddModelError("", "Email yada sifre yanlis");
                    return View();
                }

                // Şifre ve email ile giriş yap
                var result = await _signInManager.PasswordSignInAsync(user.UserName, password, rememberMe, lockoutOnFailure: true);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else if (result.IsLockedOut)
                {
                    ModelState.AddModelError("", "Hesap kilitlendi. Lutfen 5 dakika sonra deneyin");
                }
                else
                {
                    ModelState.AddModelError("", "Email yada sifre yanlis");
                }

                return View();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Giris sirasinda hata olustu: " + ex.Message);
                return View();
            }
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(string firstName, string lastName, string email, string phone, string password, string confirmPassword, bool termsAccepted)
        {
            try
            {
                // Validasyon
                if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || 
                    string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(phone) || 
                    string.IsNullOrWhiteSpace(password))
                {
                    ModelState.AddModelError("", "Tum alanlar zorunludur");
                    return View();
                }

                if (password != confirmPassword)
                {
                    ModelState.AddModelError("confirmPassword", "Sifreler eslesmiyor");
                    return View();
                }

                if (password.Length < 6)
                {
                    ModelState.AddModelError("password", "Sifre en az 6 karakter olmalidir");
                    return View();
                }

                //if (!termsAccepted)
                //{
                //    ModelState.AddModelError("termsAccepted", "Sartlari kabul etmelisiniz");
                //    return View();
                //}

                // Email'in zaten kullanılıp kullanılmadığını kontrol et
                var existingUser = await _userManager.FindByEmailAsync(email);
                if (existingUser != null)
                {
                    ModelState.AddModelError("email", "Bu email adresi zaten kayitli");
                    return View();
                }

                // Yeni user oluştur
                var user = new AppUser
                {
                    UserName = firstName+lastName,
                    Email = email,
                    PhoneNumber = phone,
                    FirstName = firstName,
                    LastName = lastName
                };

                // User'ı database'e ekle
                var result = await _userManager.CreateAsync(user, password);

                if (result.Succeeded)
                {
                    // Otomatik giriş yap
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Kayit sirasinda hata olustu: " + ex.Message);
                return View();
            }
        }

        public IActionResult ForgotPassword()
        {
            return RedirectToAction("Login");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await _signInManager.SignOutAsync();
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Cikis sirasinda hata olustu: " + ex.Message);
                return RedirectToAction("Index", "Home");
            }
        }

        public async Task<IActionResult> Profile()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login");
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login");
            }

            return View(user);
        }
    }
}
