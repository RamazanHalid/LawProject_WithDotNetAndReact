using Entities.Concrete;
using Entities.DTOs.CourtOfficeTypeDtos;

namespace Entities.DTOs.CourtOfficeDtos
{
    public class CourtOfficeGetDto
    {
        public int CourtOfficeId { get; set; }
        public  CourtOfficeTypeGetDto CourtOfficeTypeGetDto { get; set; }
        public string CourtOfficeName { get; set; }
        public string Adderess { get; set; }
        public City City { get; set; }
        public string PhoneNumber { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
