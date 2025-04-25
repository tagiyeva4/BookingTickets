using BookingTickets.Business.Services.Abstractions;
using BookingTickets.Business.Services.Implementations;
using BookingTickets.Core.Entities;
using BookingTickets.Core.ViewModels.UserSystemViewModels;
using BookingTickets.DataAccess.Data.Contexts;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace BookingTickets.Presentation.Controllers
{
    public class AccountController(
        UserManager<AppUser> _userManager,
        SignInManager<AppUser> _signInManager,
        BookingTicketsDbContext _dbContext,
        IEmailService _emailService
        ) : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(UserRegisterVm userRegisterVm)
        {
            if (!ModelState.IsValid) return View();
            AppUser? user = await _userManager.FindByNameAsync(userRegisterVm.UserName);

            if (user != null)
            {
                ModelState.AddModelError("", "This username is already exist");
                return View();
            }
            user = new()
            {
                UserName = userRegisterVm.UserName,
                Email = userRegisterVm.Email,
                FullName = userRegisterVm.FullName,
            };
            var result = await _userManager.CreateAsync(user, userRegisterVm.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View();
            }
            await _userManager.AddToRoleAsync(user, "Member");

            if (userRegisterVm.Subscribe == true)
            {
                if (_dbContext.SubscribeEmails.Any(e => e.Email == userRegisterVm.Email))
                {
                    return View();
                }
                SubscribeEmail subscribeEmail = new()
                {
                    Email = userRegisterVm.Email,
                };
                _dbContext.SubscribeEmails.Add(subscribeEmail);
                _dbContext.SaveChanges();
            }
            //send email
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var url = Url.Action("VerifyEmail", "Account", new { email = user.Email, token }, Request.Scheme);

            //send email
            using StreamReader reader = new StreamReader("wwwroot/templates/emailconfirm.html");
            var body = reader.ReadToEnd();
            body = body.Replace("{{{url}}}", url);
           //body = body.Replace("{{{username}}}", user.UserName);
            _emailService.SendEmail(user.Email, "Verify Email Address for BookingTickets", body);
            TempData["Succsess"] = "Email successfully sended to" + user.Email;

            return RedirectToAction("Login");
        }

        public async Task<IActionResult> VerifyEmail(string email, string token)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null || !await _userManager.IsInRoleAsync(user, "Member")) return RedirectToAction("notfound", "error");
            await _userManager.ConfirmEmailAsync(user, token);
            return RedirectToAction("Login");
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserLoginVm userLoginVm, string? returnUrl)
        {
            TempData["Succsess"] = "Email successfully sended to";
            if (!ModelState.IsValid) return View();
            AppUser? user = await _userManager.FindByNameAsync(userLoginVm.UserNameOrEmail);
            if (user == null || !await _userManager.IsInRoleAsync(user, "Member"))
            {
                user = await _userManager.FindByEmailAsync(userLoginVm.UserNameOrEmail);
                if (user == null)
                {
                    ModelState.AddModelError("", "Username or email is invalid..");
                    return View();
                }
            }

            var result = await _signInManager.PasswordSignInAsync(user, userLoginVm.Password, userLoginVm.RememberMe, true);
            if (!user.EmailConfirmed)
            {
                ModelState.AddModelError("", "Email is not confirmed..");
                return View();
            }
            if (result.IsLockedOut)
            {
                ModelState.AddModelError("", "Account is locked out..");
                return View();
            }
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Username or email or password is invalid..");
                return View();
            }
           // HttpContext.Response.Cookies.Append("basket", "");

            if (!string.IsNullOrEmpty(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");

        }
        [Authorize(Roles = "Member")]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordVm forgotPasswordVm)
        {
            if (!ModelState.IsValid) return View();
            var user = await _userManager.FindByEmailAsync(forgotPasswordVm.Email);
            if (user == null || !await _userManager.IsInRoleAsync(user, "Member")) return RedirectToAction("notfound", "error");
            var token = await _userManager.GeneratePasswordResetTokenAsync(user);
            var url = Url.Action("VerifyPassword", "Account", new { email = user.Email, token }, Request.Scheme);

            //send email
            using StreamReader reader = new StreamReader("wwwroot/templates/resetpassword.html");
            var body = reader.ReadToEnd();
            body = body.Replace("{{{url}}}", url);
           // body = body.Replace("{{{username}}}", user.UserName);
            _emailService.SendEmail(user.Email, "Reset Password for Login", body);
            TempData["Succsess"] = "Email successfully sended to " + user.Email;
            return View();
        }
        public async Task<IActionResult> VerifyPassword(string token, string email)
        {
            TempData["token"] = token;
            TempData["email"] = email;
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null || !await _userManager.IsInRoleAsync(user, "Member")) return RedirectToAction("notfound", "error");
            if (!await _userManager.VerifyUserTokenAsync(user, _userManager.Options.Tokens.PasswordResetTokenProvider, "ResetPassword", token))
            {
                return RedirectToAction("notfound", "error");
            }

            return RedirectToAction("ResetPassword");
        }

        public IActionResult ResetPassword()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(PasswordResetVm passwordResetVm)
        {
            TempData["token"] = passwordResetVm.Token;
            TempData["email"] = passwordResetVm.Email;
            if (!ModelState.IsValid) return View();
            var user = await _userManager.FindByEmailAsync(passwordResetVm.Email);

            if (user == null || !await _userManager.IsInRoleAsync(user, "Member")) return View();

            if (!await _userManager.VerifyUserTokenAsync(user, _userManager.Options.Tokens.PasswordResetTokenProvider, "ResetPassword", passwordResetVm.Token))
            {
                return RedirectToAction("notfound", "error");
            }

            var result = await _userManager.ResetPasswordAsync(user, passwordResetVm.Token, passwordResetVm.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(" ", error.Description);
                }
                return View();
            }
            return RedirectToAction("Login");
        }

        public IActionResult GoogleLogin()
        {
            var redirectUrl = Url.Action("GoogleResponse", "Account");
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(GoogleDefaults.AuthenticationScheme, redirectUrl);
            return new ChallengeResult(GoogleDefaults.AuthenticationScheme, properties);
        }

        public async Task<IActionResult> GoogleResponse()
        {
            var result = await _signInManager.GetExternalLoginInfoAsync();
            if (result == null)
            {
                return RedirectToAction("Login", "Account"); // Əgər Google-dan məlumat gəlməyibsə, Login səhifəsinə yönləndir
            }

            var email = result.Principal.FindFirstValue(ClaimTypes.Email);
            if (email == null)
            {
                return View("Error"); // Email tapılmayıbsa, səhv səhifəsinə yönləndir
            }

            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                user = new AppUser
                {
                    Email = email,
                    UserName = email,
                    FullName = result.Principal.FindFirstValue(ClaimTypes.Name)
                };

                var createResult = await _userManager.CreateAsync(user);
                if (!createResult.Succeeded)
                {
                    return View("Error", createResult.Errors); // Əgər user yaratmaqda səhv olarsa, error səhifəsi göstər
                }

                await _userManager.AddToRoleAsync(user, "Member");
            }

            await _signInManager.SignInAsync(user, isPersistent: false);
            return RedirectToAction("Index", "Home");
        }


    }
}
