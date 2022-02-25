using Core.Entities;
namespace Entities.DTOs.LicenceUser
{
    public class LicenceUserAddDto : IDto
    {
        public int UserId { get; set; }
        public int IsActive { get; set; }
    }
}
