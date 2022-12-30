using Cyberpalata.DataProvider.Interfaces;
using Cyberpalata.DataProvider.Models.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cyberpalata.DataProvider.Repositories
{
    internal class ApiUserRepository : IApiUserRepository
    {

        private readonly UserManager<ApiUser> _userManager;
        private readonly SignInManager<ApiUser> _signInManager;

        public ApiUserRepository(UserManager<ApiUser> userManager, SignInManager<ApiUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task CreateAsync(ApiUser user, string password)
        {
            if (user == null)
                throw new ArgumentNullException(nameof(user));
            var result = await _userManager.CreateAsync(user, password);
            if (!result.Succeeded)
                throw new InvalidOperationException();
        }

        public async Task LoginAsync(string username, string password, bool isPersistent)
        {
            var result = await _signInManager.PasswordSignInAsync(username, password, isPersistent,false);
        }

        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
