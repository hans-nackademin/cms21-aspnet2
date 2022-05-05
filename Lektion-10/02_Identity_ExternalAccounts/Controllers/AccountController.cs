using _02_Identity_ExternalAccounts.Data;
using _02_Identity_ExternalAccounts.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace _02_Identity_ExternalAccounts.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ApplicationDbContext _db;

        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, ApplicationDbContext db)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _db = db;
        }

        #region Register 
        public IActionResult Register(string returnUrl = null!)
        {
            if (_signInManager.IsSignedIn(User))
                return RedirectToAction("Index", "Home");

            var form = new RegisterForm();

            if (returnUrl != null)
                form.ReturnUrl = returnUrl;

            return View(form);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterForm form)
        {
            if (ModelState.IsValid)
            {
                var identityUser = new IdentityUser() { UserName = form.Email, Email = form.Email };
                var result = await _userManager.CreateAsync(identityUser, form.Password);

                if (result.Succeeded)
                {
                    var userProfileEntity = new UserProfileEntity()
                    {
                        UserId = identityUser.Id,
                        FirstName = form.FirstName,
                        LastName = form.LastName
                    };
                    _db.UserProfiles.Add(userProfileEntity);
                    await _db.SaveChangesAsync();

                    await _signInManager.SignInAsync(identityUser, isPersistent: false);

                    if (form.ReturnUrl == null || form.ReturnUrl == "/")
                        return RedirectToAction("Index", "Home");
                    else
                        return LocalRedirect(form.ReturnUrl);
                }
            }

            return View(form);
        }
        #endregion

        #region Login
        public async Task<IActionResult> Login(string returnUrl = null!)
        {
            if (_signInManager.IsSignedIn(User))
                return RedirectToAction("Index", "Home");

            var form = new LoginForm();

            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            form.ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();

            if (returnUrl != null)
                form.ReturnUrl = returnUrl;

            return View(form);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginForm form)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(form.Email, form.Password, isPersistent: false, false);

                if (result.Succeeded)
                    if (form.ReturnUrl == null || form.ReturnUrl == "/")
                        return RedirectToAction("Index", "Home");
                    else
                        return LocalRedirect(form.ReturnUrl);
            }

            ViewData["ErrorMessage"] = "Incorrect email or password";
            form.Password = "";

            return View(form);
        }
        #endregion
    }
}
