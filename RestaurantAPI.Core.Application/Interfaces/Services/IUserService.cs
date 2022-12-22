using InternetBanking.Core.Application.Dtos.Account;
using InternetBanking.Core.Application.ViewModels.User;
using RestaurantAPI.Core.Application.Dtos.Account;
using RestaurantAPI.Core.Application.ViewModels.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RestaurantAPI.Core.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<string> ConfirmEmailAsync(string userId, string token);
        Task<ForgotPasswordResponse> ForgotPasswordAsync(ForgotPassViewModel vm, string origin);
        Task<RegisterResponse> RegisterAsync(UserSaveViewModel vm, string origin);
        Task<UpdateResponse> UpdateUserAsync(UserSaveViewModel vm, string id);
        Task<UpdateResponse> ActivedUserAsync(string id);
        Task<UserSaveViewModel> GetUserById(string id);
        Task<ResetPasswordResponse> ResetPasswordAsync(ResetPassViewModel vm);
        Task SignOutAsync();

        Task<List<UserViewModel>> GetAllVm();
    }
}