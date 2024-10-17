using FluentValidation;
using Udemy.AdvertisementApp.UI.Models;

namespace Udemy.AdvertisementApp.UI.ValidationRules
{
    public class UserCreateModelValidator:AbstractValidator<UserCreateModel>
    {
        //[Obsolete]
        public UserCreateModelValidator()
        {
            //CascadeMode = CascadeMode.StopOnFirstFailure;
            RuleFor(x=>x.Password).NotEmpty().WithMessage("Parola boş olamaz.").MinimumLength(3).WithMessage("Parola min 3 karakter olmalıdır.").Equal(x=>x.ConfirmPassword).WithMessage("Parolalar eşleşmiyor.");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Kullanıcı adı min 3 karakter olmalıdır.").NotEmpty().WithMessage("Kullanıcı adı boş olamaz.");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("Ad boş olamaz.");
            RuleFor(x => x.SurName).NotEmpty().WithMessage("Soyad boş olamaz.");
            RuleFor(x => new
            {
                x.UserName,x.FirstName
            }).Must(x=>CannotFirstname(x.UserName,x.FirstName)).WithMessage("Kullanıcı adı adınızı içeremez.").When(x=>x.UserName!=null && x.FirstName!=null);
            RuleFor(x => x.GenderId).NotEmpty().WithMessage("Cinsiyet seçimi zorunludur.");

        }

        private bool CannotFirstname(string username,string firstname)
        {
            return !username.Contains(firstname);
        }
    }
}
