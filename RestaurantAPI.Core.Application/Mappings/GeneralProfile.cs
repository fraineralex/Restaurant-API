using AutoMapper;
using InternetBanking.Core.Application.Dtos.Account;
using InternetBanking.Core.Application.ViewModels.User;
using RestaurantAPI.Core.Application.Dtos.Account;
using RestaurantAPI.Core.Application.ViewModels.Ingredient;
using RestaurantAPI.Core.Application.ViewModels.Order;
using RestaurantAPI.Core.Application.ViewModels.Plates;
using RestaurantAPI.Core.Application.ViewModels.PlateIngredient;
using RestaurantAPI.Core.Application.ViewModels.Table;
using RestaurantAPI.Core.Application.ViewModels.User;
using RestaurantAPI.Core.Domain.Models;

namespace RestaurantAPI.Core.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            #region mappings

            #region user

            CreateMap<AuthenticationRequest, LoginViewModel>()
                .ForMember(x => x.HasError, opt => opt.Ignore())
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<AuthenticationResponse, UserSaveViewModel>()
                .ReverseMap()
                .ForMember(x => x.Roles, opt => opt.Ignore());

            CreateMap<AuthenticationResponse, UserViewModel>()
                .ReverseMap()
                .ForMember(x => x.Roles, opt => opt.Ignore());

            CreateMap<RegisterRequest, UserSaveViewModel>()
                .ForMember(x => x.HasError, opt => opt.Ignore())
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<UpdateRequest, UserSaveViewModel>()
                .ForMember(x => x.HasError, opt => opt.Ignore())
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<ForgotPasswordRequest, ForgotPassViewModel>()
                .ForMember(x => x.HasError, opt => opt.Ignore())
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ReverseMap();

            CreateMap<ResetPasswordRequest, ResetPassViewModel>()
                .ForMember(x => x.HasError, opt => opt.Ignore())
                .ForMember(x => x.Error, opt => opt.Ignore())
                .ReverseMap();

            #endregion

            #region Ingredient

            CreateMap<Ingredient, IngredientViewModel>()
                .ReverseMap();

            CreateMap<Ingredient, IngredientSaveViewModel>()
                .ReverseMap();

            #endregion

            #region Plate

            CreateMap<Plate, PlateSaveViewModel>()
                //.ForMember(x => x.Ingredinets, x => x.Ignore())
                .ReverseMap();
            //.ForMember(x => x.Ingredinets, x => x.Ignore());

            CreateMap<Plate, PlateViewModel>()
                //.ForMember(x => x.Ingredinets, x => x.Ignore())
                .ReverseMap();
                //.ForMember(x => x.Ingredinets, x => x.Ignore());

            #endregion

            #region PlateIngredient

            CreateMap<PlateIngredient, PlateIngredientSaveViewModel>()
                .ReverseMap();

            CreateMap<Plate, PlateIngredientViewModel>()
                .ReverseMap();

            #endregion

            #region Order

            CreateMap<Order, OrderSaveViewModel>()
                .ReverseMap();

            CreateMap<Order, OrderViewModel>()
                .ReverseMap();

            #endregion

            #region Table

            CreateMap<Table, TableSaveViewModel>()
                .ReverseMap();

            CreateMap<Table, TableViewModel>()
                .ReverseMap();

            #endregion

            #endregion
        }
    }
}
