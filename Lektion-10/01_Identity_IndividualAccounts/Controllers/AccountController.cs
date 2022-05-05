using _01_Identity_IndividualAccounts.Data;
using _01_Identity_IndividualAccounts.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace _01_Identity_IndividualAccounts.Controllers
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

        public IActionResult Register(string returnUrl = null!)
        {
            if (_signInManager.IsSignedIn(User))
                return RedirectToAction("Index", "Home");

            var form = new RegisterForm();

            if(returnUrl != null)
                form.ReturnUrl = returnUrl;

            return View(form);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterForm form)
        {
            if(ModelState.IsValid)
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
    }
}
