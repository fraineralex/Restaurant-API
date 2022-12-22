using InternetBanking.Core.Application.Dtos.Account;
using RestaurantAPI.Core.Application.Dtos.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAPI.Core.Application.Interfaces.Services
{
    public interface IAccountService
    {
        Task<AuthenticationResponse> AuthenticationAsync(AuthenticationRequest req);
        Task SignOutAsync();
        Task<RegisterResponse> RegisterBasicUserAsync(RegisterRequest req, string origin);
        Task<UpdateResponse> UpdateUserAsync(UpdateRequest req, string id);
        Task<List<AuthenticationResponse>> GetAllUsers();
        Task<AuthenticationResponse> GetUserById(string id);
    }
}
