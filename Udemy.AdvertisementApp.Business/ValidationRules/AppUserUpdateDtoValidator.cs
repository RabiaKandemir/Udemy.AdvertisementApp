using FluentValidation;
using Udemy.AdvertisementApp.Dtos;

namespace Udemy.AdvertisementApp.Business.ValidationRules
{
    public class AppUserUpdateDtoValidator : AbstractValidator<AppUserUpdateDto>
    {
        public AppUserUpdateDtoValidator()
        {
            RuleFor(x=>x.UserName).NotEmpty();
            RuleFor(x=>x.FirstName).NotEmpty();
            RuleFor(x=>x.SurName).NotEmpty();
            RuleFor(x=>x.GenderId).NotEmpty();
            RuleFor(x=>x.Password).NotEmpty();
            RuleFor(x=>x.PhoneNumber).NotEmpty();
            RuleFor(x=>x.Id).NotEmpty();

        }
    }
}
