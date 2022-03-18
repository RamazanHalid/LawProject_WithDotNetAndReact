using Core.Entities;
namespace Entities.DTOs.LicenceUserDtos
{
    public class LicenceUserAddDto : IDto
    {
        public int UserId { get; set; }
        public int IsActive { get; set; }
    }
}
