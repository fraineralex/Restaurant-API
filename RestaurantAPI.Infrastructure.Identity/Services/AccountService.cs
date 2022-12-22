using InternetBanking.Core.Application.Dtos.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using RestaurantAPI.Core.Application.Dtos.Account;
using RestaurantAPI.Core.Application.Interfaces.Services;
using RestaurantAPI.Infrastructure.Identity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAPI.Infrastructure.Identity.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountService(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<AuthenticationResponse> AuthenticationAsync(AuthenticationRequest req)
        {
            AuthenticationResponse res = new();

            var user = await _userManager.FindByEmailAsync(req.Email);
            if (user == null)
            {
                res.HasError = true;
                res.Error = $"No Accounts registered with {req.Email}.";
                return res;
            }

            var result = await _signInManager.PasswordSignInAsync(user.UserName, req.Password, false, lockoutOnFailure: false);
            if (!result.Succeeded)
            {
                res.HasError = true;
                res.Error = $"Invalid Credentials for {req.Email}.";
                return res;
            }
           

            res.Id = user.Id;
            res.FirstName = user.FirstName;
            res.LastName = user.LastName;
            res.Email = user.Email;
            res.UserName = user.UserName;
            var listRoles = await _userManager.GetRolesAsync(user).ConfigureAwait(false);
            res.Roles = listRoles.ToList();

            return res;
        }

        //method for signout
        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        //method for create a new basic user
        public async Task<RegisterResponse> RegisterBasicUserAsync(RegisterRequest req, string origin)
        {
            RegisterResponse res = new();
            res.HasError = false;

            var userNameExist = await _userManager.FindByNameAsync(req.UserName);
            if (userNameExist != null)
            {
                res.HasError = true;
                res.Error = $"User '{req.UserName}' already exist.";
                return res;
            }

            var emailExist = await _userManager.FindByEmailAsync(req.Email);
            if (emailExist != null)
            {
                res.HasError = true;
                res.Error = $"Email '{req.Email}' already registered.";
                return res;
            }

            var user = new ApplicationUser
            {
                Email = req.Email,
                FirstName = req.FirstName,
                LastName = req.LastName,
                UserName = req.UserName,
                PhoneNumber = req.PhoneNumber,
                TypeUser = req.TypeUser
                
            };

            var result = await _userManager.CreateAsync(user, req.Password);
            if (!result.Succeeded)
            {
                res.HasError = true;
                res.Error = $"An error occurred when trying to register the user.";
                return res;
            }

            //if (user.TypeUser == 1)
            //{
            //    await _userManager.AddToRoleAsync(user, Roles.Admin.ToString());
                
            //} else
            //{
            //    await _userManager.AddToRoleAsync(user, Roles.Basic.ToString());
            //} 

            return res;
        }

        //method for update an user
        public async Task<UpdateResponse> UpdateUserAsync(UpdateRequest req, string id)
        {
            UpdateResponse res = new();
            res.HasError = false;
            ApplicationUser user = await _userManager.FindByIdAsync(id);
            //if (user != null)
            //{
            //    if (user.TypeUser == (int)Roles.Admin)
            //    {
            //        user.FirstName = req.FirstName;
            //        user.LastName = req.LastName;
            //        user.UserName = req.UserName;
            //        user.Email = req.Email;
            //        user.PhoneNumber = req.PhoneNumber;
            //        user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, req.Password);

            //        var userUpdated = await _userManager.UpdateAsync(user);
            //        if (!userUpdated.Succeeded)
            //        {
            //            res.HasError = true;
            //            res.Error = "Error when trying update the user";
            //            return res;

            //        }
            //        return res;
            //    }
            //    else
            //    {
            //        user.FirstName = req.FirstName;
            //        user.LastName = req.LastName;
            //        user.UserName = req.UserName;
            //        user.Email = req.Email;
            //        user.PhoneNumber = req.PhoneNumber;
            //        user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, req.Password);

            //        var userUpdated = await _userManager.UpdateAsync(user);
            //        if (!userUpdated.Succeeded)
            //        {
            //            res.HasError = true;
            //            res.Error = "Error when trying update the user";
            //            return res;
            //        }
            //        //await _productSvc.AddAmountSavingAccount(user.Id, req.Amount);
            //        return res;
            //    }

            //}
            //else
            //{
            //    res.HasError = true;
            //    res.Error = $"No accounts exists with this id: {id}";
            //    return res;
            //}
            return res;
        }
        public async Task<List<AuthenticationResponse>> GetAllUsers()
        {
            var users = await _userManager.Users.ToListAsync();

            List<AuthenticationResponse> res = new();

            foreach (var user in users)
            {
                var rol = await _userManager.GetRolesAsync(user).ConfigureAwait(false);

                AuthenticationResponse user_res = new()
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserName = user.UserName,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Roles = rol.ToList(),
                };

                res.Add(user_res);
            };

            return res;
        }

        //Method to get all users
        public async Task<AuthenticationResponse> GetUserById(string id)
        {
            AuthenticationResponse res = new();
            ApplicationUser user = new();
            user = await _userManager.FindByIdAsync(id);

            if (user != null)
            {
                res.Id = user.Id;
                res.Email = user.Email;
                res.FirstName = user.FirstName;
                res.LastName = user.LastName;
                res.UserName = user.UserName;
                res.PhoneNumber = user.PhoneNumber;

                return res;
            }

            res.HasError = true;
            res.Error = $"Not user exists with this id: {id}";
            return res;
        }

    }
}
