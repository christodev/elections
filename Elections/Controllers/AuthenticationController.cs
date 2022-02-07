using Elections.Models;
using Elections.Exceptions;
using Elections.Repositories;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Elections.Controllers
{
    public class AuthenticationController : Controller
    {
        private IUserRepository UserRepository;

        public AuthenticationController(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        #region SignUp
        //Method for route /authentication/signup
        [HttpGet] //to say that /authentication/signup is a route, and the method "public User SignUp([FromForm]User user)" is not.. otherwise it will confuse
        public IActionResult SignUp()
        { 
            return View();
        }

        //Method used to Sign Up new User
        [HttpPost]
        public IActionResult SignUp(User user) //binded in the SignUp.cshtml View with User Model
        {
            //Check if Validation is successful
            if (ModelState.IsValid)
            {
                //Try to Add User to DB
                try
                {
                    //Add User to DB (If Username already taken => throws Exception)
                    User tempUser = UserRepository.AddIfNewUser(user);
                    
                    //Authenticate User
                    AuthenticateUserAsync(tempUser);

                    //return to home page -- Returns to Index.cshtml view
                    return RedirectToAction("Index", "Home");
                }
                //If Username taken exception thrown => Display Error
                catch(FailedToSignInException)
                {
                    ViewData["Error"] = "Username is already taken!";
                    return View();
                }
                catch(Exception ex)
                {
                    ViewData["Error"] = ex.Message;
                    return View();
                }
            }

            //If Model Validation fails
            else
            {
                //Return Error
                return View();
            }
        }
        #endregion

        #region SignIn
        //Method to return SignIn View
        [HttpGet]
        public ViewResult SignIn()
        {
            return View();
        }

        //Method to signin registered user
        [HttpPost]
        public IActionResult SignIn(UserSignIn user, string ReturnUrl = null)
        {
            //If Input Validation is Successful
            if (ModelState.IsValid)
            {
                //Check if User Credentials are correct
                try
                {
                    //Search for the User by UserName
                    //TO BE CHANGED (KTIR SECURE :P)
                    User tempUser = UserRepository.GetUserByCreds(user.Email, user.Password);

                    //Authenticate User
                    AuthenticateUserAsync(tempUser);    

                    //Return to home page
                    if (ReturnUrl == null)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    //If ReturnUrl is present
                    return LocalRedirect(ReturnUrl);
                }

                //If Incorrect Creds or other exception thrown
                catch (FailedToSignInException ex)
                {
                    ViewData["Error"] = ex.Message;
                    return View();
                }
                catch
                {
                    ViewData["Error"] = "Unexpected Error Occured!";
                    return View();
                }
            }

            //else if Input Validation Failed
            ViewData["Error"] = "";
            return View();
        }
        #endregion

        #region SignOut

        [HttpPost]
        public async Task<IActionResult> SignOutAsync()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

        #endregion

        #region utils
        private async void AuthenticateUserAsync(User tempUser)
        {
            //Assign it to the singleton SignedInUser class
            SignedInUser.SetInstance(tempUser);

            //Authenticate the User
            //Create Claims and Identity
            var ClaimsIdentity = new ClaimsIdentity(
                                        new List<Claim>()
            {
                                                    new Claim("UserName", tempUser.UserName),
                                                    new Claim(ClaimTypes.Email, tempUser.Email),
                                                    new Claim(ClaimTypes.Role, "Voter")
            }, CookieAuthenticationDefaults.AuthenticationScheme);

            //Create Principal (chakhs)
            var ClaimsPrincipal = new ClaimsPrincipal(ClaimsIdentity);

            //Sign in User Officially
            //var authProperties = new AuthenticationProperties()
            //{
            //    IsPersistent = false
            //};

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                ClaimsPrincipal, new AuthenticationProperties()
                {
                    IsPersistent = false
                });
        }
        #endregion
    }
}
