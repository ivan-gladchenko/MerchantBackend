﻿using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
//using IdentityServer.Db;
using IdentityServer.Models;
using IdentityServer4.Services;
using Merchant.Core;
using Merchant.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityServer.Controllers
{
    public class OldAuthController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IIdentityServerInteractionService _interactionService;
        private readonly MerchantDbContext _merchantDbContext;

        public OldAuthController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IIdentityServerInteractionService interactionService, MerchantDbContext merchantDbContext)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _interactionService = interactionService;
            _merchantDbContext = merchantDbContext;
        }
        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            var viewModel = new LoginViewModel
           {
               ReturnUrl = returnUrl
           };
           return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var user = await _userManager.FindByNameAsync(viewModel.UserName);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "User not found");
                return View(viewModel);
            }

            var result = await _signInManager.PasswordSignInAsync(viewModel.UserName, viewModel.Password, false, false);
            if (result.Succeeded)
            {
                return Redirect(viewModel.ReturnUrl);
            }
            ModelState.AddModelError(string.Empty, "Login error");
            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Register(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl))
            {
                string referer = Request.Headers["Referer"].ToString();
                if (!string.IsNullOrEmpty(referer))
                {
                    var query = referer.ToLower().Split("returnurl");
                    if (query.Length > 2)
                    {
                        returnUrl = query[1];
                    }
                }
            }
            var viewModel = new RegisterViewModel
            {
                ReturnUrl = returnUrl
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel viewModel)
        {

            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            var user = new AppUser
            {
                UserName = viewModel.UserName,
                PhoneNumber = viewModel.PhoneNumber,
                Email = viewModel.Email,
                FullName =  viewModel.FullName,
                Uuid = Guid.NewGuid().ToString("D")
            };
            var checkUser = await _userManager.FindByNameAsync(viewModel.UserName);
            if (checkUser != null)
            {
                ModelState.AddModelError(string.Empty, "User with that username exists");
                return View(viewModel);
            }
            var result = await _userManager.CreateAsync(user, viewModel.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                var merchantUser = new MerchantUser(viewModel.UserName);
                _merchantDbContext.MerchantUsers.Add(merchantUser);
                await _merchantDbContext.SaveChangesAsync();
                return Redirect(viewModel.ReturnUrl);
            }
            ModelState.AddModelError(string.Empty, "Error occurred");
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Logout(string logoutId)
        {
            await _signInManager.SignOutAsync();
            var logoutRequest = await _interactionService.GetLogoutContextAsync(logoutId);
            return Redirect(logoutRequest.PostLogoutRedirectUri);
        }
    }
}
