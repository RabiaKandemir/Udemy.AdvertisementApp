using Udemy.AdvertisementApp.Dtos.Interfaces;

namespace Udemy.AdvertisementApp.Dtos
{
    public class AppRoleUpdateDto : IDto
    {
        public int Id { get; set; }
        private string Definition { get; set; }
    }
}
