using Core.Entities;

namespace Entities.DTOs.CaseIngonereUserDtos
{
    public class CaseIgnoreUserAddDto : IDto
    {
        public int UserId { get; set; }
        public int CaseeId { get; set; }
    }
}
